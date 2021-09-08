using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace UIExtension
{
    public class Rotating : MonoBehaviour
    {
        [SerializeField] private bool _clockwise;
        [SerializeField] private float _duration;

        private void Start()
        {
            Execute();
        }

        private void Execute()
        {
            RectTransform rectTr = (RectTransform)transform;
            rectTr.DORotate(new Vector3(0, 0, _clockwise ? -360 : 360), _duration, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
        }
    }
}