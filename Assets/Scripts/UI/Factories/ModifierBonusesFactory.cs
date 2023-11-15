using DiceRoller.UI.ResultPanel;
using UnityEngine;
using Zenject;

namespace DiceRoller.UI.Factories
{
    public class ModifierBonusesFactory : IModifierBonusesFactory
    {
        private DiContainer _diContainer;
        
        private ModifierBonusesFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public ModifierBonusWidget GenerateWidget(ModifierBonusWidget modifierBonusWidgetPrefab, Transform resultPanelTransform)
            => _diContainer
                .InstantiatePrefab(modifierBonusWidgetPrefab, resultPanelTransform)
                .GetComponent<ModifierBonusWidget>();
    }
}