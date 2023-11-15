using DG.Tweening;
using DiceRoller.Gameplay.Roll;
using DiceRoller.UI.Factories;
using UnityEngine;
using Zenject;

namespace DiceRoller.UI.ResultPanel
{
    public class BonusesPanel : MonoBehaviour
    {
        [SerializeField] private ModifierBonusWidget _modifierBonusWidgetPrefab;
        [SerializeField] private float _scaleTime = .5f;
        
        private IModifierBonusesFactory _modifierBonusesFactory;
        private RollBonuses _rollBonuses;

        private ModifierBonusWidget _statBonusWidget;
        private ModifierBonusWidget _advantageTypeWidget;
        private ModifierBonusWidget _circumstanceBonusWidget;

        [Inject]
        private void Construct(IModifierBonusesFactory modifierBonusesFactory, RollBonuses rollBonuses)
        {
            _modifierBonusesFactory = modifierBonusesFactory;
            _rollBonuses = rollBonuses;

            SetupWidgets();
        }

        private void SetupWidgets()
        {
            _statBonusWidget = _modifierBonusesFactory.GenerateWidget(_modifierBonusWidgetPrefab, transform);
            _advantageTypeWidget = _modifierBonusesFactory.GenerateWidget(_modifierBonusWidgetPrefab, transform);
            _circumstanceBonusWidget = _modifierBonusesFactory.GenerateWidget(_modifierBonusWidgetPrefab, transform);
            
            _rollBonuses.OnStatBonusChanged += UpdateStatBonusWidget;
            _rollBonuses.OnAdvantageTypeChanged += UpdateAdvantageTypeWidget;
            _rollBonuses.OnCircumstanceBonusChanged += UpdateCircumstanceBonusWidget;
            
            _statBonusWidget.transform.localScale = Vector3.zero;
            _advantageTypeWidget.transform.localScale = Vector3.zero;
            _circumstanceBonusWidget.transform.localScale = Vector3.zero;

            _statBonusWidget.gameObject.SetActive(false);
            _advantageTypeWidget.gameObject.SetActive(false);
            _circumstanceBonusWidget.gameObject.SetActive(false);
        }

        private void UpdateStatBonusWidget()
        {
            if (!_statBonusWidget.gameObject.activeSelf && _rollBonuses.CheckStat.Stat.Mod != 0)
            {
                ActivateWidget(_statBonusWidget);
            }

            if (_rollBonuses.CheckStat.Stat.Mod == 0)
            {
                DeactivateWidget(_statBonusWidget);
            }

            _statBonusWidget.UpdateWidget(_rollBonuses.CheckStat.StatType.ToString(), null, _rollBonuses.CheckStat.Stat.Mod);

        }

        private void UpdateAdvantageTypeWidget()
        {
            if (!_advantageTypeWidget.gameObject.activeSelf)
            {
                ActivateWidget(_advantageTypeWidget);
            }
            else
            {
                if (_rollBonuses.AdvantageType == AdvantageType.None)
                {
                    DeactivateWidget(_advantageTypeWidget);
                }
            }
            
            _advantageTypeWidget.UpdateWidget(_rollBonuses.AdvantageType.ToString(), null, 0);
        }

        private void UpdateCircumstanceBonusWidget()
        {
            if (!_circumstanceBonusWidget.gameObject.activeSelf && _rollBonuses.CircumstanceBonus.Value != 0)
            {
                ActivateWidget(_circumstanceBonusWidget);
            }

            if (_circumstanceBonusWidget.gameObject.activeSelf && _rollBonuses.CircumstanceBonus.Value == 0)
            {
                DeactivateWidget(_circumstanceBonusWidget);
            }

            _circumstanceBonusWidget.UpdateWidget(_rollBonuses.CircumstanceBonus.BonusName, _rollBonuses.CircumstanceBonus.Sprite, _rollBonuses.CircumstanceBonus.Value);
        }

        private void ActivateWidget(ModifierBonusWidget widget)
        {
            widget.gameObject.SetActive(true);
            widget.transform.DOScale(Vector3.one, _scaleTime);
        }

        private void DeactivateWidget(ModifierBonusWidget widget)
        {
            widget
                .transform.DOScale(Vector3.zero, _scaleTime)
                .OnComplete(() =>
                {
                    widget.gameObject.SetActive(false);
                });
        }

        private void OnDestroy()
        {
            _rollBonuses.OnStatBonusChanged -= UpdateStatBonusWidget;
            _rollBonuses.OnAdvantageTypeChanged -= UpdateAdvantageTypeWidget;
            _rollBonuses.OnCircumstanceBonusChanged -= UpdateCircumstanceBonusWidget;
        }
    }
}