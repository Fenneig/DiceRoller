using UnityEngine;

namespace DiceRoller.UI
{
    public class AdvantageWidget : MonoBehaviour
    {
        public void UpdateAdvantageState(int dropdownState)
        {
            switch (dropdownState)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                default:
                    Debug.LogError($"No rules for dropdown menu with {dropdownState} value!");
                    break;
            }
        }
    }
}