using System;
using DiceRoller.Gameplay.Roll;
using DiceRoller.UI.GoalPanel;
using DiceRoller.UI.SuccessPanel;

namespace DiceRoller.Gameplay
{
    public class GameLoop
    {
        private DicePool _dicePool;
        private GoalPanelWidget _goalPanelWidget;
        private RollResult _rollResult;
        private RollBonuses _rollBonuses;
        private SuccessPanelWidget _successPanelWidget;

        public event Action OnRollComplete;
        
        /// <summary>
        /// Прокидываю зависимости класса в конструкторе
        /// </summary>
        /// <param name="dicePool">Класс отвечающий за броски кубов и их положение на "столе"</param>
        /// <param name="goalPanelWidget">Виджет отвечающий за отображение текущего результата броска и сложности броска</param>
        /// <param name="rollResult">Класс содержащий в себе информацию по значению броска и сложности броска</param>
        /// <param name="rollBonuses">Класс содержащий в себе информацию по бонусам и штрафам к броску (проверяемая характеристика, преимущество, обстоятельства)</param>
        /// <param name="successPanelWidget">Виджет показывающий результат броска</param>
        public GameLoop(DicePool dicePool, GoalPanelWidget goalPanelWidget, RollResult rollResult, RollBonuses rollBonuses, SuccessPanelWidget successPanelWidget)
        {
            _dicePool = dicePool;
            _goalPanelWidget = goalPanelWidget;
            _rollResult = rollResult;
            _rollBonuses = rollBonuses;
            _successPanelWidget = successPanelWidget;

            OnRollComplete += _goalPanelWidget.ShowGoal;
        }
        
        /// <summary>
        /// Обнуляю результаты предыдущего броска, включаю нужные UI панели и запускаю процесс броска кубиков с колбэком при завершении броска вызвать следующий метод
        /// </summary>
        public void StartRoll()
        {
            _rollResult.ResultValue = 0;
            _goalPanelWidget.ShowResult();
            _dicePool.RollDices(UpdateDiceResult);
        }

        /// <summary>
        /// Высчитываю результат броска, определяю значение выпавшего на кубике, если выпали критические значения сразу запускаю функцию исхода,
        /// в ином случае подсчитываю модификаторы броска и добавляю в результат 
        /// </summary>
        private void UpdateDiceResult()
        {
            _rollResult.ResultValue = _dicePool.GetRollResult();
            
            if (_rollResult.ResultValue is 1 or 20)
            {
                SuccessCheck(true);
                return;
            }
            
            _rollBonuses.OnStatBonusCount?.Invoke(() =>
                _rollResult.ResultValue += _rollBonuses.CheckStat.Stat.Mod);

            _rollBonuses.OnCircumstanceBonusCount?.Invoke(() =>
            {
                _rollResult.ResultValue += _rollBonuses.CircumstanceBonus.Value;
                SuccessCheck();
            });
        }

        /// <summary>
        /// Сравниваю результат броска со значением сложности броска, показываю виджет с результатом,
        /// по окончанию показа виджета вызываются функции при окончании броска  
        /// </summary>
        /// <param name="criticalResult"></param>
        private void SuccessCheck(bool criticalResult = false)
        {
            if (criticalResult)
            {
                _successPanelWidget.ShowWidget(_rollResult.ResultValue == 20, OnRollComplete);
            }
            else
            {
                _successPanelWidget.ShowWidget(_rollResult.ResultValue >= _rollResult.GoalValue, OnRollComplete);
            }
        }
    }
}