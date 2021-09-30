using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class BT_add_nangcap : MonoBehaviour, IPointerDownHandler
{
    public int id;
    public void OnPointerDown(PointerEventData eventData)
    {
        Id_panel_nangcap.instance.GetComponent<Id_panel_nangcap>().id = id;
        if (BT_nangcap.instance.GetComponent<BT_nangcap>().mang[Id_panel_nangcap.instance.GetComponent<Id_panel_nangcap>().id]<nhakho_nongsan.instance.GetComponent<nhakho_nongsan>().lv_nhakho &&
            GameManager.instance.dataui.data[1].giatri>0)
        {
            BT_nangcap.instance.GetComponent<BT_nangcap>().mang[Id_panel_nangcap.instance.GetComponent<Id_panel_nangcap>().id]++;
            instaceCanvas.instance.transform.GetChild(6).GetChild(Id_panel_nangcap.instance.GetComponent<Id_panel_nangcap>().id).GetChild(2).GetComponent<TextMeshProUGUI>().text =
                BT_nangcap.instance.GetComponent<BT_nangcap>().mang[Id_panel_nangcap.instance.GetComponent<Id_panel_nangcap>().id].ToString();
            GameManager.instance.dataui.data[1].giatri--;
        }
        else
        {
            Debug.Log("Lượng đá quý không đủ");
        }
    }
}
