using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BT_huy : MonoBehaviour,IPointerDownHandler
{


    [SerializeField] GameObject nhakhonongsan;
    [SerializeField] GameObject canvas_total;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject chua_sp;
    [SerializeField] GameObject nang_cap;


    public void OnPointerDown(PointerEventData eventData)
    {
        nhakhonongsan.SetActive(false);
        canvas.SetActive(false);
        nang_cap.SetActive(false);
        chua_sp.SetActive(false);
        canvas_total.SetActive(true);
    }

}
