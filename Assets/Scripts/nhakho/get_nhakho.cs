using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class get_nhakho : MonoBehaviour,IPointerDownHandler
{
    public static get_nhakho instance;
    public int id;
    [SerializeField] GameObject show_sp;

    public void OnPointerDown(PointerEventData eventData)
    {
        show_sp.SetActive(false);
    }

    private void Awake()
    {
        instance = this;
    }
}
