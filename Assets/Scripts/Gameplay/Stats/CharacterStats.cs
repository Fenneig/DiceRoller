namespace DiceRoller.Gameplay.Stats
{
    public class CharacterStats
    {
        public Stat Strength { get; } = new();
        public Stat Constitution { get; } = new();
        public Stat Agility { get; } = new();
        public Stat Wisdom { get; } = new();
        public Stat Intellect { get; } = new();
        public Stat Charisma { get; } = new();

        public Stat GetStatByName(StatType statType)
        {
            Stat stat = statType switch
            {
                StatType.Strength => Strength,
                StatType.Constitution => Constitution,
                StatType.Agility => Agility,
                StatType.Wisdom => Wisdom,
                StatType.Intellect => Intellect,
                StatType.Charisma => Charisma,
                _ => null
            };
            
            return stat;
        }
    }
}