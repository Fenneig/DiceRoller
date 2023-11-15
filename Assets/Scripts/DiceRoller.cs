using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiceRoller : MonoBehaviour
{
    [SerializeField] private List<Transform> _sides;
    [SerializeField] private float _minRotation;
    [SerializeField] private float _maxRotation;
    [SerializeField] private float _rollDuration;
    [SerializeField] private Transform _diceTransform;
    [SerializeField] private Rigidbody _rigidbody;
    
    
    [ContextMenu("Roll")]
    private void Roll()
    {
        _rigidbody.isKinematic = true;
        
        Vector3 newSideRotation = new Vector3(Random.Range(_minRotation, _maxRotation), 
                                              Random.Range(_minRotation, _maxRotation), 
                                              Random.Range(_minRotation, _maxRotation));
        _diceTransform.DORotate(newSideRotation, _rollDuration, RotateMode.FastBeyond360);
        Vector3 randomPosition1 = CreateNewRandomPosition();
        Vector3 randomPosition2 = CreateNewRandomPosition();
        float sequenceStepAmount = 3f;
        DOTween.Sequence()
            .Append(transform.DOMove(randomPosition1, _rollDuration / sequenceStepAmount).SetEase(Ease.InOutSine))
            .Append(transform.DOMove(randomPosition2, _rollDuration / sequenceStepAmount).SetEase(Ease.InOutSine))
            .Append(transform.DOMove(new Vector3(0, 0, 0), _rollDuration / sequenceStepAmount).SetEase(Ease.InOutSine))
            .OnComplete(() =>
            {
                _rigidbody.isKinematic = false;
                DOTween.Sequence()
                    .PrependInterval(1f)
                    .Append(_rigidbody.transform.DOMove(Vector3.zero, 0.5f))
                    .OnComplete(Define);
            });
    }

    private Vector3 CreateNewRandomPosition() =>
        new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5)).normalized * 5f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) Roll();
    }

    [ContextMenu("Define Side")]
    private void Define()
    {
        Vector3 topPosition = _sides[0].position;
        int sideValue = 1;
        for (int i = 1; i < _sides.Count; i++)
        {
            if (_sides[i].position.y > topPosition.y)
            {
                topPosition = _sides[i].position;
                sideValue = i + 1;
            }
        }

        Debug.Log(sideValue);
    }
}
