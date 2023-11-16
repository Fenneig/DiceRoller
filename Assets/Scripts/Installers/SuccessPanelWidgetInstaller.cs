using DiceRoller.UI.SuccessPanel;
using UnityEngine;
using Zenject;

namespace DiceRoller.Installers
{
    public class SuccessWidgetInstaller : MonoInstaller
    {
        [SerializeField] private SuccessPanelWidget _successPanelWidget;
        public override void InstallBindings()
        {
            Container
                .Bind<SuccessPanelWidget>()
                .FromInstance(_successPanelWidget)
                .AsSingle();
        }
    }
}