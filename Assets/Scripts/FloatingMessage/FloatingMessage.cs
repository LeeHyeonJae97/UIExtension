using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using NaughtyAttributes;

namespace UIExtension
{
    public class FloatingMessage : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _messageText;
        [SerializeField] private UIAnimationController _controller;

        private static UnityAction<string> _show;

        private void Start()
        {
            _show += Show_Internal;
        }

        public static void Show(string message)
        {
            _show?.Invoke(message);
        }

        private void Show_Internal(string message)
        {
            if (_controller.IsPlaying) return;

            _messageText.text = message;
            _controller.Play();
        }
    }
}