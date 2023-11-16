using DiceRoller.Gameplay;
using DiceRoller.Gameplay.Roll;
using Zenject;

namespace DiceRoller.Installers
{
    public class RollResultInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<RollResult>()
                .AsSingle();
        }
    }
}