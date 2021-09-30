using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Btn_exit : MonoBehaviour, IPointerDownHandler
{
    public GameObject Market;
    public GameObject Canvas;
    public GameObject Canvas_chinh;

    public void OnPointerDown(PointerEventData eventData)
    {
        Market.gameObject.SetActive(false);
        Canvas.gameObject.SetActive(false);
        Canvas_chinh.gameObject.SetActive(true);
    }
}
