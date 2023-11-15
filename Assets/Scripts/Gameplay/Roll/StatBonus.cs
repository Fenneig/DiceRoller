using DiceRoller.Gameplay.Stats;
using DiceRoller.UI;

namespace DiceRoller.Gameplay.Roll
{
    public class StatBonus
    {
        public StatType StatType { get; set; }
        public Stat Stat { get; set; } = new();
    }
}