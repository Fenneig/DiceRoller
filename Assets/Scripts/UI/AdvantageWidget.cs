using DiceRoller.Gameplay.Roll;
using UnityEngine;
using Zenject;

namespace DiceRoller.UI
{
    public class AdvantageWidget : MonoBehaviour
    {
        private RollBonuses _rollBonuses;

        [Inject]
        private void Construct(RollBonuses rollBonuses)
        {
            _rollBonuses = rollBonuses;
        }
        
        public void UpdateInfo(int dropdownState)
        {
            switch (dropdownState)
            {
                case 0:
                    _rollBonuses.SetAdvantageType(AdvantageType.None);
                    break;
                case 1:
                    _rollBonuses.SetAdvantageType(AdvantageType.Advantage);
                    break;
                case 2:
                    _rollBonuses.SetAdvantageType(AdvantageType.Disadvantage);
                    break;
                default:
                    Debug.LogError($"No rules for dropdown menu with {dropdownState} value!");
                    break;
            }
        }
    }
}