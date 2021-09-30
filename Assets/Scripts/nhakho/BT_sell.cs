using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class BT_sell : MonoBehaviour,IPointerDownHandler
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject show_info;


    public void OnPointerDown(PointerEventData eventData)
    {
        if (canvas.GetComponent<get_nhakho>().id < nha_kho.instance.dem_spchebien)
        {
            if (GameManager.instance.dataSPCheBien.data[nha_kho.instance.mang[canvas.transform.GetComponent<get_nhakho>().id]].sanluong
            > canvas.transform.GetChild(0).GetChild(0).GetChild(canvas.GetComponent<get_nhakho>().id).GetComponent<chua_sp_nhakho>().coso)
            {
                GameManager.instance.dataSPCheBien.data[nha_kho.instance.mang[canvas.transform.GetComponent<get_nhakho>().id]].sanluong
                -= canvas.transform.GetChild(0).GetChild(0).GetChild(canvas.GetComponent<get_nhakho>().id).GetComponent<chua_sp_nhakho>().coso;
                string c = canvas.transform.GetChild(4).GetChild(6).GetComponent<TextMeshProUGUI>().text;
                GameManager.instance.dataui.data[0].giatri += int.Parse(c);
                canvas.transform.GetChild(0).GetChild(0).GetChild(canvas.GetComponent<get_nhakho>().id).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text =
            GameManager.instance.dataSPCheBien.data[nha_kho.instance.mang[canvas.transform.GetComponent<get_nhakho>().id]].sanluong.ToString();
            }
            else
            {
                Debug.Log("Bạn sẽ bán hết số lượng trong kho đấy -.-");
            }
        }
        else
        {
            if (GameManager.instance.dataVatNuoi.data[nha_kho.instance.mang[canvas.transform.GetComponent<get_nhakho>().id]].sl_sanpham
            > canvas.transform.GetChild(0).GetChild(0).GetChild(canvas.GetComponent<get_nhakho>().id).GetComponent<chua_sp_nhakho>().coso)
            {
                GameManager.instance.dataVatNuoi.data[nha_kho.instance.mang[canvas.transform.GetComponent<get_nhakho>().id]].sl_sanpham
                -= canvas.transform.GetChild(0).GetChild(0).GetChild(canvas.GetComponent<get_nhakho>().id).GetComponent<chua_sp_nhakho>().coso;
                string c = canvas.transform.GetChild(4).GetChild(6).GetComponent<TextMeshProUGUI>().text;
                GameManager.instance.dataui.data[0].giatri += int.Parse(c);
                canvas.transform.GetChild(0).GetChild(0).GetChild(canvas.GetComponent<get_nhakho>().id).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text =
            GameManager.instance.dataVatNuoi.data[nha_kho.instance.mang[canvas.transform.GetComponent<get_nhakho>().id]].sl_sanpham.ToString();
            }
            else
            {
                Debug.Log("Bạn sẽ bán hết số lượng trong kho đấy -.-");
            }
        }



        /*canvas.transform.GetChild(0).GetChild(0).GetChild(canvas.GetComponent<get_nhakho>().id).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text =
            GameManager.instance.dataVatNuoi.data[nha_kho.instance.mang[canvas.transform.GetComponent<get_nhakho>().id]].sl_sanpham.ToString();*/
        //nha_kho.instance.Update_nhakho();
        show_info.SetActive(false);
    }
}
