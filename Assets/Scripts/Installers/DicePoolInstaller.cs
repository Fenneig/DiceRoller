using DiceRoller.Gameplay;
using UnityEngine;
using Zenject;

namespace DiceRoller.Installers
{
    public class DicePoolInstaller : MonoInstaller
    {
        [SerializeField] private DicePool _dicePool;
        public override void InstallBindings()
        {
            Container
                .Bind<DicePool>()
                .FromInstance(_dicePool)
                .AsSingle();
        }
    }
}