using DiceRoller.Gameplay;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DiceRoller.UI
{
    public class RollDiceWidget : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _tooltipText;
        [SerializeField] private Button _rollDiceButton;
        
        [Inject]
        private void Construct(GameLoop gameLoop)
        {
            _rollDiceButton.onClick.AddListener(gameLoop.StartRoll);
            _rollDiceButton.onClick.AddListener(() => TurnWidgetActive(false));
            gameLoop.OnRollComplete += () =>  TurnWidgetActive(true);
        }

        private void TurnWidgetActive(bool state)
        {
            _tooltipText.gameObject.SetActive(state);
            _rollDiceButton.interactable = state;
        }


        private void OnDestroy()
        {
            _rollDiceButton.onClick.RemoveAllListeners();
        }
    }
}