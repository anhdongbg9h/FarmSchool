using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GetIdCay : MonoBehaviour, IPointerDownHandler
{

    [HideInInspector]
    public static int idCayTrong;
    [SerializeField] private int id;
    
    [SerializeField] private DataNongSan dataNongsan;

    public void OnMouseDown()
    {
        idCayTrong = dataNongsan.data[id].ID;
    }
    

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log(name + "Game Object Click in Progress");
        //idCayTrong = dataNongsan.data[id].ID;
    }
}
