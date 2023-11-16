using System;

namespace DiceRoller.Gameplay.Roll
{
    public class RollResult
    {
        private int _resultResultValue;
        private int _goalValue;

        public int ResultValue
        {
            get => _resultResultValue;
            set
            {
                if (_resultResultValue == value) return;
                _resultResultValue = value;
                OnResultChanged?.Invoke();
            }
        }
        
        public int GoalValue { get; set; }
        
        public event Action OnResultChanged;
    }
}