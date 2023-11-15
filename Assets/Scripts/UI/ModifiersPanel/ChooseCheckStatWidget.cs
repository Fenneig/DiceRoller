using System;
using DiceRoller.Gameplay.Roll;
using DiceRoller.Gameplay.Stats;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DiceRoller.UI.ModifiersPanel
{
    public class ChooseCheckStatWidget : MonoBehaviour
    {
        [SerializeField] private Button _previousButton;
        [SerializeField] private Button _nextButton;
        [SerializeField] private TextMeshProUGUI _selectedStatText;
        
        private int _currentStatIndex;
        private string[] _statTypes;
        private RollBonuses _rollBonuses;
        private CharacterStats _characterStats;

        [Inject]
        private void Construct(RollBonuses rollBonuses, CharacterStats characterStats)
        {
            _rollBonuses = rollBonuses;
            _characterStats = characterStats;
        }

        private void Awake()
        {
            _statTypes = Enum.GetNames(typeof(StatType));
            _currentStatIndex = 0;
            _previousButton.onClick.AddListener(PreviousStat);
            _previousButton.onClick.AddListener(UpdateInfo);
            _nextButton.onClick.AddListener(NextStat);
            _nextButton.onClick.AddListener(UpdateInfo);
            UpdateInfo();
        }

        private void PreviousStat() =>
            _currentStatIndex = (int) Mathf.Repeat(_currentStatIndex - 1, _statTypes.Length);

        private void NextStat() =>
            _currentStatIndex = (int) Mathf.Repeat(_currentStatIndex + 1, _statTypes.Length);

        private void UpdateInfo()
        {
            string statName = _statTypes[_currentStatIndex];
            var statType = Enum.Parse<StatType>(statName);
            _selectedStatText.text = statName.Substring(0, 3);
            _rollBonuses.SetStatBonus(statType, _characterStats.GetStatByName(statType));
        }

        private void OnDestroy()
        {
            _previousButton.onClick.RemoveAllListeners();
            _nextButton.onClick.RemoveAllListeners();
        }
    }
}