﻿using System;
using DG.Tweening;
using DiceRoller.Gameplay.Roll;
using UnityEngine;
using Zenject;

namespace DiceRoller.Gameplay
{
    public class DicePool : MonoBehaviour
    {
        [Header("Dices")]
        [SerializeField] private Dice _mainDice;
        [SerializeField] private Dice _advantageDice;

        [Header("Dice positions")] 
        [SerializeField] private Transform _singleDiceTransform;
        [SerializeField] private Transform _firstPairDiceTransform;
        [SerializeField] private Transform _advantagePairDiceTransform;

        [Header("Tween settings"), Space]
        [SerializeField] private float _appearTime = .5f;
        
        private RollBonuses _rollBonuses;

        [Inject]
        private void Construct(RollBonuses rollBonuses)
        {
            _rollBonuses = rollBonuses;
            _rollBonuses.OnAdvantageTypeChanged += UpdateDicesOnField;
        }

        private void UpdateDicesOnField()
        {
            if (_rollBonuses.AdvantageType == AdvantageType.None)
            {
                _advantageDice.transform
                    .DOScale(Vector3.zero, _appearTime)
                    .OnComplete(() => _advantageDice.gameObject.SetActive(false));

                _mainDice.transform.DOMove(_singleDiceTransform.position, _appearTime);
            }
            else
            {
                _advantageDice.gameObject.SetActive(true);
                _advantageDice.transform.DOScale(Vector3.one, _appearTime);
                _advantageDice.transform.DOMove(_advantagePairDiceTransform.position, _appearTime);
                _mainDice.transform.DOMove(_firstPairDiceTransform.position, _appearTime);
            }
        }

        private void Awake()
        {
            _advantageDice.gameObject.SetActive(false);
        }
        
        public void RollDices(Action onRollComplete)
        {
            if (_rollBonuses.AdvantageType == AdvantageType.None)
            {
                _mainDice.Roll(_singleDiceTransform.position, onRollComplete);
            }
            else
            {
                _mainDice.Roll(_firstPairDiceTransform.position);
                _advantageDice.Roll(_advantagePairDiceTransform.position, onRollComplete);
            }
        }

        public int GetRollResult()
        {
            int result = 0;
            
            int mainDiceValue = _mainDice.GetTopSideValue();
            int advantageDiceValue = _advantageDice.GetTopSideValue();
            
            switch (_rollBonuses.AdvantageType)
            {
                case AdvantageType.None:
                    ShowWinDiceEffect(_mainDice);
                    result += _mainDice.GetTopSideValue();
                    break;
                case AdvantageType.Advantage:
                {
                    if (mainDiceValue > advantageDiceValue)
                    {
                        ShowWinDiceEffect(_mainDice);
                        result += mainDiceValue;
                    }
                    else
                    {
                        ShowWinDiceEffect(_advantageDice);
                        result += advantageDiceValue;
                    }

                    break;
                }
                case AdvantageType.Disadvantage:
                {
                    if (mainDiceValue < advantageDiceValue)
                    {
                        ShowWinDiceEffect(_mainDice);
                        result += mainDiceValue;
                    }
                    else
                    {
                        ShowWinDiceEffect(_advantageDice);
                        result += advantageDiceValue;
                    }
                    break;
                }
            }

            return result;
        }

        private void ShowWinDiceEffect(Dice dice)
        {
            DOTween.Sequence()
                .Append(dice.transform.DOScale(Vector3.one * 1.2f, 0.2f))
                .Append(dice.transform.DOScale(Vector3.one, 0.2f));
        }
    }
}