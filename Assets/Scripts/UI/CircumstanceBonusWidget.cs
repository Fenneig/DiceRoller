using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DiceRoller.UI
{
    public class CircumstanceBonusWidget : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _circumstanceNameTextField;
        [SerializeField] private TextMeshProUGUI _valueText;
        [SerializeField] private Button _addButton;
        [SerializeField] private Button _subtractButton;

        private int _currentValue;
        
        private void Awake()
        {
            _currentValue = 0;
            _valueText.text = _currentValue.ToString();
            _addButton.onClick.AddListener(AddValue);
            _addButton.onClick.AddListener(UpdateWidget);
            _subtractButton.onClick.AddListener(SubtractValue);
            _subtractButton.onClick.AddListener(UpdateWidget);
        }

        private void AddValue() => _currentValue++;
        private void SubtractValue() => _currentValue--;
        private void UpdateWidget() => _valueText.text = _currentValue.ToString();
    }
}