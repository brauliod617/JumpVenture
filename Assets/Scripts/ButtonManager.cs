using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IPointerClickHandler
{
    public bool IsPressed {
        get;
        set;
    }

    public bool IsClicked
    {
        get;
        set;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        IsPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        IsPressed = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IsPressed = false;
        IsClicked = false;
    }

    public void OnPointerClick(PointerEventData eventData) {
        IsClicked = true;
    }
}
