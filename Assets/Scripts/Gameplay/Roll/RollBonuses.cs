using System;
using DiceRoller.Gameplay.Stats;

namespace DiceRoller.Gameplay.Roll
{
    public class RollBonuses
    {
        private StatBonus _checkStat;
        private AdvantageType _advantageType;
        private CircumstanceBonus _circumstanceBonus;

        public StatBonus CheckStat => _checkStat;
        public AdvantageType AdvantageType => _advantageType;
        public CircumstanceBonus CircumstanceBonus => _circumstanceBonus;

        public event Action OnStatBonusChanged;
        public event Action OnAdvantageTypeChanged;
        public event Action OnCircumstanceBonusChanged;

        public RollBonuses()
        {
            _checkStat = new StatBonus();
            _advantageType = AdvantageType.None;
            _circumstanceBonus = new CircumstanceBonus();
        }

        public void UpdateStatBonus() => OnStatBonusChanged?.Invoke();

        public void SetStatBonus(StatType statType, Stat stat)
        {
            _checkStat.StatType = statType;
            _checkStat.Stat = stat;
            OnStatBonusChanged?.Invoke();
        }

        public void SetAdvantageType(AdvantageType advantageType)
        {
            if (_advantageType == advantageType) return;
            
            _advantageType = advantageType;
            OnAdvantageTypeChanged?.Invoke();
        }

        public void SetCircumstanceBonus(string name, int value)
        {
            _circumstanceBonus.BonusName = name;
            _circumstanceBonus.Value = value;
            OnCircumstanceBonusChanged?.Invoke();
        }
    }
}