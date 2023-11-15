using System;

namespace DiceRoller.Gameplay.Stats
{
    public class Stat
    {
        private int _value = 10;

        public event Action OnValueChanged;
        
        public int Value
        {
            get => _value;
            set
            {
                if (value == _value) return;

                _value = value;
                OnValueChanged?.Invoke();
            }
        }

        public int Mod => (_value - 10) / 2;
    }
}