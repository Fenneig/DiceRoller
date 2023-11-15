using DiceRoller.Gameplay.Roll;
using Zenject;

namespace DiceRoller.Installers
{
    public class RollBonusesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<RollBonuses>()
                .FromNew()
                .AsSingle();
        }
    }
}