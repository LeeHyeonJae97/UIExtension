using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NaughtyAttributes;
using DG.Tweening;

namespace UI.Animation
{
	public class AnchoredPositionState : UIState
	{
		[Foldout("_stateName", true)]
		[SerializeField] private Vector3 _value;
		[Foldout("_stateName", true)]
		[Min(0)]
		[SerializeField] private float _duration;
		[Foldout("_stateName", true)]
		[SerializeField] private Ease _ease;

		private RectTransform _rectTr;

		private void OnValidate()
		{
			if (_rectTr == null) _rectTr = (RectTransform)transform;
		}

		public override Tween Transit(bool directly = false)
		{
			// Transit
			Tween tween = _rectTr.DOAnchorPos(_value, directly ? 0 : _duration).SetEase(_ease).SetDelay(_delay);
			return tween;
		}

		[Button("Save", upperSpace: 5)]
		public override void Save()
		{
			_value = _rectTr.anchoredPosition3D;
		}

		[Button("Load")]
		public override void Load()
		{
			Undo.RecordObject(_rectTr, "Load");
			_rectTr.anchoredPosition3D = _value;
		}
	}
}
