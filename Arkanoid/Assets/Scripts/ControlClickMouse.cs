using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlClickMouse : MonoBehaviour, IPointerClickHandler
{
    public event Action MouseClickEvent;

    public void OnPointerClick(PointerEventData eventData) {
        MouseClickEvent?.Invoke();
    }
}
