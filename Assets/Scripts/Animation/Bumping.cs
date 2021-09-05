using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bumping : MonoBehaviour
{
    [SerializeField] private Vector2 _targetValue;
    [SerializeField] private float _duration;

    private void Start()
    {
        Execute();
    }

    private void Execute()
    {
        RectTransform rectTr = (RectTransform)transform;
        rectTr.DOSizeDelta(_targetValue, _duration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
}
