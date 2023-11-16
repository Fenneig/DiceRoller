using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DiceRoller.UI.BonusesPanel
{
    public class ModifierBonusWidget : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _bonusName;
        [SerializeField] private Image _bonusIcon;
        [SerializeField] private TextMeshProUGUI _bonusValue;

        public void UpdateWidget(string bonusName, Sprite bonusIcon, int bonusValue)
        {
            _bonusName.text = bonusName;
            if (bonusIcon != null) _bonusIcon.sprite = bonusIcon;
            _bonusValue.text = bonusValue.ToString();
            _bonusValue.gameObject.SetActive(bonusValue != 0);
        }
    }
}