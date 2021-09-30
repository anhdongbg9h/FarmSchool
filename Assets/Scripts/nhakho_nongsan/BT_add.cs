using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class BT_add : MonoBehaviour, IPointerDownHandler
{

    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject show_info;


    public void OnPointerDown(PointerEventData eventData)
    {
        if (GameManager.instance.dataNongSan.data[nhakho_nongsan.instance.mang[canvas.transform.GetComponent<instaceCanvas>().id]].sanluong
            > canvas.transform.GetChild(0).GetChild(0).GetChild(canvas.GetComponent<instaceCanvas>().id).GetComponent<Click_into_chua_sp>().coso)
        {
            GameManager.instance.dataNongSan.data[nhakho_nongsan.instance.mang[canvas.transform.GetComponent<instaceCanvas>().id]].sanluong
            -= canvas.transform.GetChild(0).GetChild(0).GetChild(canvas.GetComponent<instaceCanvas>().id).GetComponent<Click_into_chua_sp>().coso;
            string c = canvas.transform.GetChild(4).GetChild(6).GetComponent<TextMeshProUGUI>().text;
            GameManager.instance.dataui.data[0].giatri += int.Parse(c);
        }


        nhakho_nongsan.instance.Update_sl();
        show_info.SetActive(false);
        
    }
}
