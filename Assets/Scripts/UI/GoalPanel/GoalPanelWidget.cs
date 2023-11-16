using UnityEngine;

namespace DiceRoller.UI.GoalPanel
{
    public class GoalPanelWidget : MonoBehaviour
    {
        [SerializeField] private CheckResultWidget _resultWidget;
        [SerializeField] private SetupGoalWidget _goalWidget;

        public void ShowResult()
        {
            _resultWidget.gameObject.SetActive(true);
            _goalWidget.gameObject.SetActive(false);
        }

        public void ShowGoal()
        {
            _resultWidget.gameObject.SetActive(false);
            _goalWidget.gameObject.SetActive(true);
        }
    }
}