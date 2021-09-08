using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace UIExtension
{
	public class ConfirmModal : MonoBehaviour
	{
		[SerializeField] private Text _messageText;
		[SerializeField] private Text _yesButtonText;
		[SerializeField] private Text _noButtonText;

		private UnityAction _onYes;

		public static void Show(ConfirmModal prefab, string message, UnityAction onYes, string yesButtonText = null, string noButtonText = null)
		{
			ConfirmModal modal = Instantiate(prefab);

			modal.gameObject.SetActive(true);
			modal._messageText.text = message;
			if (yesButtonText != null)
				modal._yesButtonText.text = yesButtonText;
			if (noButtonText != null)
				modal._noButtonText.text = noButtonText;
			modal._onYes = onYes;
		}

		public void Yes()
		{
			_onYes?.Invoke();
			Destroy(gameObject);
		}

		public void No()
		{
			Destroy(gameObject);
		}
	}
}