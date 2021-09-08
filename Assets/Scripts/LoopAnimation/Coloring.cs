using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace UIExtension
{
    [RequireComponent(typeof(Graphic))]
    public class Coloring : MonoBehaviour
    {
        [SerializeField] private Color _targetValue = Color.white;
        [SerializeField] private float _duration;

        private void Start()
        {
            Execute();
        }

        private void Execute()
        {
            Graphic graphic = GetComponent<Graphic>();
            graphic.DOColor(_targetValue, _duration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        }
    }
}