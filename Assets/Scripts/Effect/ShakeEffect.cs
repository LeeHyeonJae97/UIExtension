using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;

namespace UIExtension
{
	public enum ShakeEffectType { Position, AnchoredPosition, Scale, Rotation }

	public class ShakeEffect : UIEffect
	{		
		[SerializeField] private ShakeEffectType _type;
		[SerializeField] private float _duration = 1;
		[SerializeField] private Vector3 _strength = Vector3.one;
		[SerializeField] private int _vibrato = 10;
		[SerializeField] private float _randomness = 90;		
		[SerializeField] private bool _fadeOut = false;

		private RectTransform _target;

		private void Awake()
        {
			_target = (RectTransform)transform;
        }

        public override void Invoke()
		{
			switch (_type)
			{
				case ShakeEffectType.Position:
					_target.DOShakePosition(_duration, _strength, _vibrato, _randomness, fadeOut: _fadeOut);
					break;

				case ShakeEffectType.AnchoredPosition:
					_target.DOShakeAnchorPos(_duration, _strength, _vibrato, _randomness, fadeOut: _fadeOut);
					break;

				case ShakeEffectType.Scale:
					_target.DOShakeScale(_duration, _strength, _vibrato, _randomness, _fadeOut);
					break;

				case ShakeEffectType.Rotation:
					_target.DOShakeRotation(_duration, _strength, _vibrato, _randomness, _fadeOut);
					break;
			}
		}
	}
}
