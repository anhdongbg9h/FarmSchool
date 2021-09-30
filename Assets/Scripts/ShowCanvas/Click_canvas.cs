using BitBenderGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Click_canvas : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        TouchInputController.instance.isDragging = true; // khoa camera
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        TouchInputController.instance.isDragging = false;
    }
}
