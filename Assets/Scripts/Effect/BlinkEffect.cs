using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.UI;
using DG.Tweening;

namespace UIExtension
{
	[RequireComponent(typeof(Graphic))]
	public class BlinkEffect : UIEffect
	{
		[SerializeField] private float _duration;
		[SerializeField] private int _vibrato = 1;

		private Graphic _target;

		private void Awake()
		{
			_target = GetComponent<Graphic>();
		}

		public override void Invoke()
		{
			Sequence sequence = DOTween.Sequence();
			Tweener tweener1, tweener2;

			for (int i = 0; i < _vibrato; i++)
			{
				tweener1 = _target.DOFade(0, _duration / 2);
				tweener2 = _target.DOFade(1, _duration / 2);

				sequence.Append(tweener1);
				sequence.Append(tweener2);
			}
		}
	}
}
