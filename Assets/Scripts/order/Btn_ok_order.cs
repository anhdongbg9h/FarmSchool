using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Btn_ok_order : MonoBehaviour, IPointerDownHandler
{

    public GameObject Order_UI;
    public GameObject Canvas;
    public GameObject Panel_order_donhang;
    public GameObject O_to_khong;
    public GameObject O_to_hang;

    [HideInInspector] public  int Id;
    int dem;


    public void OnPointerDown(PointerEventData eventData)
    {
        Order_UI.SetActive(false);
        Canvas.SetActive(false);

        dem = 0;

        // đếm số phần tử được duyệt (số đơn)
        for (int i = 2; i < Panel_order_donhang.transform.childCount; i++)
        {
            if (Panel_order_donhang.transform.GetChild(i).gameObject.activeSelf == true)
            {
                dem++;
            }
        }
        // cập nhật vàng và kinh nghiệm
        for (int i = 0; i < dem; i++)
        {
            if (Panel_order_donhang.transform.GetChild(i + 2).GetComponent<Click_donhang>().Id_donhang == Id
                && Panel_order_donhang.transform.GetChild(i + 2).GetComponent<Click_donhang>().Check == true
                && Panel_order_donhang.transform.GetChild(i + 2).GetComponent<Click_donhang>().Sell == true
                && Panel_order_donhang.transform.GetChild(i+2).GetChild(0).gameObject.activeSelf == false)
            {
                GameManager.instance.dataui.data[0].giatri +=
                    Panel_order_donhang.transform.GetChild(i + 2).GetComponent<Click_donhang>().vang;
                GameManager.instance.datanhachinh.data[GameManager.instance.dataui.data[2].giatri-1].KinhNghiem +=
                    Panel_order_donhang.transform.GetChild(i + 2).GetComponent<Click_donhang>().kn;
                Panel_order_donhang.transform.GetChild(i + 2).GetComponent<Click_donhang>().
                    Update_SL_in_kho(Panel_order_donhang.transform.GetChild(i + 2).GetComponent<Click_donhang>().t);
                Panel_order_donhang.transform.GetChild(i + 2).GetComponent<Click_donhang>().Start();
            }
        }
    }
}
