using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using NaughtyAttributes;

namespace UIExtension
{
    public class DamageText : MonoBehaviour
    {
        [Header("Target")]
        [SerializeField] private RectTransform _targetRectTr;
        [SerializeField] private Graphic _targetGraphic;

        [Header("Settings")]
        [SerializeField] private float _duration;
        [SerializeField] private float _startY;
        [SerializeField] private float _endY;
        [SerializeField] private Color _startColor = Color.white;
        [SerializeField] private Color _endColor;
        [SerializeField] private Vector3 _punch;

        private Sequence _sequence;

        public void Spawn(Vector3 pos)
        {
            transform.position = pos;
            Invoke();
        }

        private void Invoke()
        {
            if (_sequence.IsActive()) _sequence.Kill();

            _sequence = DOTween.Sequence();

            _targetRectTr.localScale = Vector3.one;
            _targetRectTr.anchoredPosition = new Vector2(_targetRectTr.anchoredPosition.x, _startY);
            _targetGraphic.color = _startColor;

            _sequence.Join(_targetRectTr.DOPunchScale(_punch, _duration, 1, 1));
            _sequence.Join(_targetRectTr.DOAnchorPosY(_endY, _duration));
            _sequence.Join(_targetGraphic.DOColor(_endColor, _duration));
        }

        [Button]
        public void TestSpawn()
        {
            Vector3 pos = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), 0);
            Spawn(pos);
        }
    }
}
