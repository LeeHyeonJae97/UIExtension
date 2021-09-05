using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertModal : MonoBehaviour
{
	[SerializeField] private Image _iconImage;
	[SerializeField] private Text _messageText;

	public static void Show(AlertModal prefab, string message, Sprite icon = null)
	{
		AlertModal modal = Instantiate(prefab);

		modal.gameObject.SetActive(true);
		if (icon != null)
		{
			modal._iconImage.sprite = icon;
			modal._iconImage.SetNativeSize();
		}
		modal._messageText.text = message;
	}

	public void Hide()
	{
		Destroy(gameObject);
	}
}
