using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Focusing : MonoBehaviour
{
    private Canvas _canvas;
    private GameObject _focused;

    public static UnityAction<GameObject> setFocusButton;
    public static UnityAction unsetFocus;

    private void Awake()
    {
        _canvas = GetComponent<Canvas>();

        setFocusButton = SetFocusButton;
        unsetFocus = UnsetFocus;

        _canvas.enabled = false;
    }

    private void SetFocusButton(GameObject button)
    {
        _canvas.enabled = true;

        _focused = Instantiate(button, _canvas.transform);
        _focused.GetComponent<Button>().onClick.AddListener(UnsetFocus);
    }

    private void UnsetFocus()
    {
        _canvas.enabled = false;
        Destroy(_focused);
    }
}
