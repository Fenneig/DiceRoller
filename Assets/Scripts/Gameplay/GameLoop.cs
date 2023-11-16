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
        
        public GameLoop(DicePool dicePool, GoalPanelWidget goalPanelWidget, RollResult rollResult, RollBonuses rollBonuses, SuccessPanelWidget successPanelWidget)
        {
            _dicePool = dicePool;
            _goalPanelWidget = goalPanelWidget;
            _rollResult = rollResult;
            _rollBonuses = rollBonuses;
            _successPanelWidget = successPanelWidget;

            OnRollComplete += _goalPanelWidget.ShowGoal;
        }
        
        public void StartRoll()
        {
            _rollResult.ResultValue = 0;
            _goalPanelWidget.ShowResult();
            _dicePool.RollDices(UpdateDiceResult);
        }

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

        private void SuccessCheck(bool criticalResult = false)
        {
            if (criticalResult)
            {
                _successPanelWidget.ShowWidget(_rollResult.ResultValue == 20);
            }
            else
            {
                _successPanelWidget.ShowWidget(_rollResult.ResultValue >= _rollResult.GoalValue);
            }
            
            OnRollComplete?.Invoke();
        }
    }
}