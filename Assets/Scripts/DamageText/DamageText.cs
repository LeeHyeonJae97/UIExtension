using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UIExtension;

public class DamageText : MonoBehaviour
{
    private TextMeshPro _text;
    private UIAnimationController _controller;

    private void Awake()
    {
        _text = GetComponentInChildren<TextMeshPro>();
        _controller = GetComponentInChildren<UIAnimationController>();
    }

    public void Show(int damage)
    {
        _text.text = damage.ToString();
        _controller.Play();
    }
}
