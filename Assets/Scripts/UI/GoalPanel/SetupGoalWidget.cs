using DiceRoller.Gameplay;
using DiceRoller.Gameplay.Roll;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DiceRoller.UI.GoalPanel
{
    public class SetupGoalWidget : MonoBehaviour
    {
        [SerializeField] private Button _addButton;
        [SerializeField] private Button _subtractButton;
        [SerializeField] private TextMeshProUGUI _goalValueText;

        private RollResult _rollResult;
        
        private const int DEFAULT_GOAL_VALUE = 10;
        
        [Inject]
        private void Construct(RollResult rollResult)
        {
            _rollResult = rollResult;
            _rollResult.GoalValue = DEFAULT_GOAL_VALUE;
        }

        private void Awake()
        {
            UpdateInfo();
            _addButton.onClick.AddListener(AddGoalValue);
            _addButton.onClick.AddListener(UpdateInfo);
            _subtractButton.onClick.AddListener(SubtractGoalValue);
            _subtractButton.onClick.AddListener(UpdateInfo);
        }

        private void AddGoalValue() => _rollResult.GoalValue++;
        private void SubtractGoalValue() => _rollResult.GoalValue--;
        private void UpdateInfo() => _goalValueText.text = _rollResult.GoalValue.ToString();
    }
}