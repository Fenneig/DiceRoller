using DiceRoller.UI;
using DiceRoller.UI.Factories;
using Zenject;

namespace DiceRoller.Installers
{
    public class ModifierBonusesFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IModifierBonusesFactory>()
                .To<ModifierBonusesFactory>().AsSingle();
        }
    }
}