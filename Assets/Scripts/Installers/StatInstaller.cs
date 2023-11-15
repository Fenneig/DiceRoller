using DiceRoller.Gameplay;
using DiceRoller.Gameplay.Stats;
using Zenject;

namespace DiceRoller.Installers
{
    public class StatInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<CharacterStats>()
                .AsSingle();
        }
    }
}