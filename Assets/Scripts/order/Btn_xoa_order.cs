using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Btn_xoa_order : MonoBehaviour, IPointerDownHandler
{

    public GameObject Panel_order_donhang;
    public GameObject Panel_info_donhang;

    public int Id;
    int dem;

    public void OnPointerDown(PointerEventData eventData)
    {
        dem = 0;
        for(int i = 2; i < Panel_order_donhang.transform.childCount; i++)
        {
            if (Panel_order_donhang.transform.GetChild(i).gameObject.activeSelf==true)
            {
                dem++;
            }
        }

        for(int i = 0; i< dem; i++)
        {
            if (Panel_order_donhang.transform.GetChild(i+2).GetComponent<Click_donhang>().Id_donhang==Id
                && Panel_order_donhang.transform.GetChild(i + 2).GetComponent<Click_donhang>().Check == true)
            {
                Panel_order_donhang.transform.GetChild(i + 2).GetComponent<Click_donhang>().Check = false;
                Panel_order_donhang.transform.GetChild(i + 2).GetComponent<Click_donhang>().Start();
                Panel_order_donhang.transform.GetChild(i + 2).GetComponent<Click_donhang>().show_thongtin_don();
            }
        }

        /*Panel_info_donhang.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = 0.ToString();
        Panel_info_donhang.transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = 0.ToString();*/

        /*Panel_info_donhang.transform.GetChild(3).gameObject.SetActive(false);
        Panel_info_donhang.transform.GetChild(4).gameObject.SetActive(false);
        Panel_info_donhang.transform.GetChild(5).gameObject.SetActive(false);*/

        //Click_donhang.instance.show_thongtin_don(Id);


    }
}
