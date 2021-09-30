using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Btn_exit_order : MonoBehaviour, IPointerDownHandler    
{
    public GameObject Order_ui;
    public GameObject Canvas;
    public GameObject Canvas_chinh;

    public void OnPointerDown(PointerEventData eventData)
    {
        Order_ui.gameObject.SetActive(false);
        Canvas.gameObject.SetActive(false);
        Canvas_chinh.gameObject.SetActive(true);
    }
}
