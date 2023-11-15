using DiceRoller.Gameplay.Roll;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DiceRoller.UI.ModifiersPanel
{
    public class CircumstanceBonusWidget : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _circumstanceNameTextField;
        [SerializeField] private TextMeshProUGUI _valueText;
        [SerializeField] private Button _addButton;
        [SerializeField] private Button _subtractButton;

        private int _currentValue;
        private RollBonuses _rollBonuses;

        [Inject]
        private void Construct(RollBonuses rollBonuses)
        {
            _rollBonuses = rollBonuses;
        }

        private void Awake()
        {
            _currentValue = 0;
            _valueText.text = _currentValue.ToString();
            _addButton.onClick.AddListener(AddValue);
            _addButton.onClick.AddListener(UpdateInfo);
            _subtractButton.onClick.AddListener(SubtractValue);
            _subtractButton.onClick.AddListener(UpdateInfo);
        }

        private void AddValue() => _currentValue++;
        private void SubtractValue() => _currentValue--;

        private void UpdateInfo()
        {
            _valueText.text = _currentValue.ToString();
            _rollBonuses.SetCircumstanceBonus(_circumstanceNameTextField.text, _currentValue);
        }
    }
}