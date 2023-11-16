using DG.Tweening;
using TMPro;
using UnityEngine;

namespace DiceRoller.UI.SuccessPanel
{
    public class SuccessPanelWidget : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _successText;
        [SerializeField] private GameObject _panel;
        [SerializeField] private string _textOnSuccess;
        [SerializeField] private string _textOnFail;
        [SerializeField] private float _timeToShowResult;
        
        private void Awake()
        {
            _panel.transform.localScale = Vector3.zero;
            _panel.SetActive(false);
        }

        public void ShowWidget(bool isWin)
        {
            _panel.SetActive(true);
            _successText.text = isWin ? _textOnSuccess : _textOnFail;
            DOTween.Sequence()
                .Append(_panel.transform.DOScale(Vector3.one, .2f))
                .OnComplete(() =>
                {
                    DOTween.Sequence()
                        .AppendInterval(_timeToShowResult)
                        .Append(_panel.transform.DOScale(Vector3.zero, .2f))
                        .OnComplete(() => _panel.SetActive(false));
                });
        }
    }
}