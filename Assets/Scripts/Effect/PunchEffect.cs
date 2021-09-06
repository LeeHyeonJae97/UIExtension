using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;

namespace UI.Animation
{
	public enum PunchEffectType { Position, AnchoredPosition, Scale, Rotation }

	public class PunchEffect : UIEffect
	{
		[SerializeField] private PunchEffectType _type;
		[SerializeField] private Vector3 _punch;
		[SerializeField] private float _duration;
		[SerializeField] private int _vibrato = 10;
		[SerializeField] private float _elasticity = 1;

		private RectTransform _target;

		private void Awake()
		{
			_target = (RectTransform)transform;
		}

		public override void Invoke()
		{
			switch (_type)
			{
				case PunchEffectType.Position:
					_target.DOPunchPosition(_punch, _duration, _vibrato, _elasticity);
					break;

				case PunchEffectType.AnchoredPosition:
					_target.DOPunchAnchorPos(_punch, _duration, _vibrato, _elasticity);
					break;

				case PunchEffectType.Scale:
					_target.DOPunchScale(_punch, _duration, _vibrato, _elasticity);
					break;

				case PunchEffectType.Rotation:
					_target.DOPunchRotation(_punch, _duration, _vibrato, _elasticity);
					break;
			}
		}
	}
}
