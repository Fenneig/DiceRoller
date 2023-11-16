using DiceRoller.Gameplay;
using Zenject;

namespace DiceRoller.Installers
{
    public class GameLoopInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<GameLoop>()
                .AsSingle();
        }
    }
}