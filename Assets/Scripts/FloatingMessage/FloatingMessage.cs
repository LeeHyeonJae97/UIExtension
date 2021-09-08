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
            _messageText.text = message;
        }

        [Button]
        public void Test()
        {
            FloatingMessage.Show("Hello");
        }
    }
}