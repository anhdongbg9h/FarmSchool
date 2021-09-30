using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class cavansbackground : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject dialog;
    [SerializeField] GameObject chua_sp;
    public void OnPointerDown(PointerEventData eventData)
    {
        gameObject.SetActive(false);
        dialog.SetActive(false);
        chua_sp.SetActive(false);
    }
}
