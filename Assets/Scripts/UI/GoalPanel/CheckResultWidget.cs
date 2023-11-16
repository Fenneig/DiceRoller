using DiceRoller.Gameplay;
using DiceRoller.Gameplay.Roll;
using TMPro;
using UnityEngine;
using Zenject;

namespace DiceRoller.UI.GoalPanel
{
    public class CheckResultWidget : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _resultText;

        private RollResult _rollResult;

        [Inject]
        private void Construct(RollResult rollResult)
        {
            _rollResult = rollResult;
            rollResult.OnResultChanged += UpdateInfo;
        }

        private void UpdateInfo() => _resultText.text = _rollResult.ResultValue.ToString();

        private void OnDestroy()
        {
            _rollResult.OnResultChanged -= UpdateInfo;
        }
    }
}