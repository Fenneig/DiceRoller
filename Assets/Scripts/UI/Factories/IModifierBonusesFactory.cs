using DiceRoller.UI.BonusesPanel;
using UnityEngine;

namespace DiceRoller.UI.Factories
{
    public interface IModifierBonusesFactory
    {
        public ModifierBonusWidget GenerateWidget(ModifierBonusWidget modifierBonusWidgetPrefab, Transform resultPanelTransform);
    }
}