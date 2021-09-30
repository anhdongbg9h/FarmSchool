using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class BT_add_nangcao_nhakho : MonoBehaviour,IPointerDownHandler
{
    public int id;
    public void OnPointerDown(PointerEventData eventData)
    {
        Id_panel_nangcap.instance.GetComponent<Id_panel_nangcap>().id = id;
        if (BT_nangcap_nhakho.instance.GetComponent<BT_nangcap_nhakho>().mang[Id_panel_nangcap.instance.GetComponent<Id_panel_nangcap>().id] < nha_kho.instance.GetComponent<nha_kho>().lv_nhakho)
        {
            BT_nangcap_nhakho.instance.GetComponent<BT_nangcap_nhakho>().mang[Id_panel_nangcap.instance.GetComponent<Id_panel_nangcap>().id]++;
            get_nhakho.instance.transform.GetChild(6).GetChild(Id_panel_nangcap.instance.GetComponent<Id_panel_nangcap>().id).GetChild(2).GetComponent<TextMeshProUGUI>().text =
                BT_nangcap_nhakho.instance.GetComponent<BT_nangcap_nhakho>().mang[Id_panel_nangcap.instance.GetComponent<Id_panel_nangcap>().id].ToString();
        }
    }
}
