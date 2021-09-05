using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OverScrollChecker : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Min(0.1f)] public float threshold;

    public UnityAction<bool> onOverScrolled;
    public UnityAction<bool> onOverScrollReleased;
    private bool isOnOverScrolledTriggered;

    private bool overScrolledToLeftOrBottom;
    private bool overScrolledToRightOrTop;

    private void Awake()
    {
        ScrollRect scrollRect = GetComponent<ScrollRect>();

        bool hor = scrollRect.horizontal;
        bool ver = scrollRect.vertical;
        if (hor && ver)
        {
            Debug.Log("only one scroll direction");
        }
        else if ((hor && !ver) || (!hor && ver))
        {
            scrollRect.onValueChanged.AddListener(CheckOverScroll);

            ///////
            onOverScrolled = (bool value) => Debug.Log("overScrolled : " + value);
            onOverScrollReleased = (bool value) => Debug.Log("overScroll released : " + value);
        }
    }

    private void CheckOverScroll(Vector2 pos)
    {
        if ((pos.x < -threshold || pos.y < -threshold))
        {
            overScrolledToLeftOrBottom = true;

            if (!isOnOverScrolledTriggered)
            {
                isOnOverScrolledTriggered = true;
                onOverScrolled?.Invoke(true);
            }
        }
        else
        {
            overScrolledToLeftOrBottom = false;
        }

        if ((pos.x > 1 + threshold || pos.y > 1 + threshold))
        {
            overScrolledToRightOrTop = true;

            if (!isOnOverScrolledTriggered)
            {
                isOnOverScrolledTriggered = true;
                onOverScrolled?.Invoke(false);
            }
        }
        else
        {
            overScrolledToRightOrTop = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        overScrolledToLeftOrBottom = false;
        overScrolledToRightOrTop = false;
        isOnOverScrolledTriggered = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // 포인터 클릭 해제 시 포인터가 ScrollRect를 벗어나 있는 경우 실행하고 싶지 않다면
        // eventData.pressPointer가 eventData.hovered에 포함되어있는지 확인

        if (overScrolledToLeftOrBottom) onOverScrollReleased?.Invoke(true);
        else if (overScrolledToRightOrTop) onOverScrollReleased?.Invoke(false);
    }
}
