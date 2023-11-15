using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DiceRoller.UI
{
    public class ChooseCheckStatWidget : MonoBehaviour
    {
        [SerializeField] private Button _previousButton;
        [SerializeField] private Button _nextButton;
        [SerializeField] private TextMeshProUGUI _selectedStatText;
        
        private int _currentStat;
        private string[] _statTypes;

        private void Awake()
        {
            _statTypes = Enum.GetNames(typeof(StatType));
            _currentStat = 0;
            _previousButton.onClick.AddListener(PreviousStat);
            _previousButton.onClick.AddListener(UpdateText);
            _nextButton.onClick.AddListener(NextStat);
            _nextButton.onClick.AddListener(UpdateText);
        }

        private void PreviousStat() =>
            _currentStat = (int) Mathf.Repeat(_currentStat - 1, _statTypes.Length);

        private void NextStat() =>
            _currentStat = (int) Mathf.Repeat(_currentStat + 1, _statTypes.Length);

        private void UpdateText() => _selectedStatText.text = _statTypes[_currentStat].Substring(0, 3);

        private void OnDestroy()
        {
            _previousButton.onClick.RemoveAllListeners();
            _nextButton.onClick.RemoveAllListeners();
        }
    }
}