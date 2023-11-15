using DiceRoller.Gameplay.Stats;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DiceRoller.UI
{
    public class StatWidget : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _statValue;
        [SerializeField] private Button _addButton;
        [SerializeField] private Button _subtractButton;
        [SerializeField] private StatType _statType;
        
        private Stat _currentStat;

        [Inject]
        private void Construct(CharacterStats characterStats)
        {
            _currentStat = _statType switch
            {
                StatType.Strength => characterStats.Strength,
                StatType.Constitution => characterStats.Constitution,
                StatType.Agility => characterStats.Agility,
                StatType.Wisdom => characterStats.Wisdom,
                StatType.Intellect => characterStats.Intellect,
                StatType.Charisma => characterStats.Charisma,
                _ => _currentStat
            };
            
            _currentStat.OnValueChanged += UpdateInfo;
        }
        
        private void Awake()
        {
            _addButton.onClick.AddListener(AddValue);
            _subtractButton.onClick.AddListener(SubtractValue);
        }

        private void AddValue() => _currentStat.Value++;
        private void SubtractValue() => _currentStat.Value--;
        private void UpdateInfo()
        {
            _statValue.text = _currentStat.Value.ToString();
        }

        private void OnDestroy()
        {
            _currentStat.OnValueChanged -= UpdateInfo;
        }
    }
}