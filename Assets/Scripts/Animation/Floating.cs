using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Floating : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private float _duration;

    private void Start()
    {
        Execute();
    }

    private void Execute()
    {
        RectTransform rectTr = (RectTransform)transform;
        rectTr.anchoredPosition -= new Vector2(0, _range / 2);
        rectTr.DOAnchorPosY(rectTr.anchoredPosition.y + _range, _duration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
}
