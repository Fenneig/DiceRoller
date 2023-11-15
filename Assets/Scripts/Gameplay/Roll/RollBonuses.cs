using DiceRoller.Gameplay.Stats;
using DiceRoller.UI;

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

        public RollBonuses()
        {
            _checkStat = new StatBonus();
            _advantageType = AdvantageType.None;
            _circumstanceBonus = new CircumstanceBonus();
        }

        public void SetStatBonus(StatType statType, Stat stat)
        {
            _checkStat.StatType = statType;
            _checkStat.Stat = stat;
        }

        public void SetAdvantageType(AdvantageType advantageType)
        {
            _advantageType = advantageType;
        }

        public void SetCircumstanceBonus(string name, int value)
        {
            _circumstanceBonus.Name = name;
            _circumstanceBonus.Value = value;
        }
    }
}