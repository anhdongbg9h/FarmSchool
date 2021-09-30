using BitBenderGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BT_huy_nhakho : MonoBehaviour, IPointerDownHandler
{

    [SerializeField] GameObject nhakho;
    [SerializeField] GameObject canvas_total;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject show_info;
    [SerializeField] GameObject nang_cap;


    public void OnPointerDown(PointerEventData eventData)
    {
        //TouchInputController.instance.isDragging = false;
        nhakho.SetActive(false);
        canvas_total.SetActive(true);
        canvas.SetActive(false);
        nang_cap.SetActive(false);
        show_info.SetActive(false);
    }
}
