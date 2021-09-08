using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

namespace UIExtension
{
	public class AlertModal : MonoBehaviour
	{
		[SerializeField] private Image _iconImage;
		[SerializeField] private TextMeshProUGUI _messageText;

		private Canvas _canvas;

		private static UnityAction<string> _show;

		private void Start()
		{
			_canvas = GetComponent<Canvas>();
			_show += Show_Internal;
		}

		public static void Show(string message)
		{
			_show?.Invoke(message);
		}

		private void Show_Internal(string message)
		{
			_canvas.enabled = true;
			_messageText.text = message;
		}

		public void Hide()
		{
			_canvas.enabled = false;
		}
	}
}
