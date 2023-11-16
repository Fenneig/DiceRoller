using DiceRoller.UI.GoalPanel;
using UnityEngine;
using Zenject;

namespace DiceRoller.Installers
{
    public class GoalPanelWidgetInstaller : MonoInstaller
    {
        [SerializeField] private GoalPanelWidget _goalPanelWidget;
        public override void InstallBindings()
        {
            Container
                .Bind<GoalPanelWidget>()
                .FromInstance(_goalPanelWidget)
                .AsSingle();
        }
    }
}