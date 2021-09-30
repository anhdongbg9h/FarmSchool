using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Btn_sell : MonoBehaviour, IPointerDownHandler
{
    public GameObject panel;
    public GameObject vang;
    public GameObject cho;

    public int id_data;
    public int id_sp;
    public void OnPointerDown(PointerEventData eventData)
    {
        int giatien = int.Parse(gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text);
        if (giatien <= GameManager.instance.dataui.data[0].giatri)
        {
            switch (id_data)
            {
                case 1:
                    GameManager.instance.dataNongSan.data[id_sp].sanluong += 1;
                    break;
                case 2:
                    GameManager.instance.dataSPCheBien.data[id_sp].sanluong += 1;
                    break;
                case 3:
                    GameManager.instance.dataVatNuoi.data[id_sp].sl_sanpham += 1;
                    break;
            }
            gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = " ";
            panel.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = null;
            panel.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = new Color32(255, 255, 255, 0);
            panel.transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = " ";
            GameManager.instance.dataui.data[0].giatri -= giatien;
            cho.transform.GetComponent<Click_market>().dem++;
        }
        else
        {
            Debug.Log("Số tiền còn lại không đủ để thực hiện giao dịch");
        }
        if (cho.transform.GetComponent<Click_market>().dem == GameManager.instance.dataui.data[2].giatri)
        {
            cho.transform.GetComponent<Click_market>().Start();
            cho.transform.GetComponent<Click_market>().dem = 0;
        }

        
    }
}
