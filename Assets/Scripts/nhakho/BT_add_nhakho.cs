using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class BT_add_nhakho : MonoBehaviour, IPointerDownHandler
{
    public GameObject canvas;
    [HideInInspector] public int dem_spchebien;     // đếm số hạt giống đã được mở


    public void OnPointerDown(PointerEventData eventData)
    {
        dem_spchebien = nha_kho.instance.dem_spchebien;

        if (gameObject.CompareTag("BT_add"))
        {
            if (canvas.GetComponent<get_nhakho>().id< dem_spchebien)
            {
                if (canvas.transform.GetChild(0).GetChild(0).GetChild(canvas.GetComponent<get_nhakho>().id).GetComponent<chua_sp_nhakho>().coso
                < GameManager.instance.dataSPCheBien.data[nha_kho.instance.mang[canvas.transform.GetComponent<get_nhakho>().id]].sanluong)
                {
                    canvas.transform.GetChild(0).GetChild(0).GetChild(canvas.GetComponent<get_nhakho>().id).GetComponent<chua_sp_nhakho>().coso++;
                    nha_kho.instance.update_canvas_thongtin_hat(canvas.GetComponent<get_nhakho>().id);
                }
            }
            else
            {
                if (canvas.transform.GetChild(0).GetChild(0).GetChild(canvas.GetComponent<get_nhakho>().id).GetComponent<chua_sp_nhakho>().coso
                < GameManager.instance.dataVatNuoi.data[nha_kho.instance.mang[canvas.transform.GetComponent<get_nhakho>().id]].sl_sanpham)
                {
                    canvas.transform.GetChild(0).GetChild(0).GetChild(canvas.GetComponent<get_nhakho>().id).GetComponent<chua_sp_nhakho>().coso++;
                    nha_kho.instance.update_canvas_thongtin_hat(canvas.GetComponent<get_nhakho>().id);
                }
            }
            
        }

        else if (gameObject.CompareTag("BT_sub"))
        {
            if (canvas.transform.GetChild(0).GetChild(0).GetChild(canvas.GetComponent<get_nhakho>().id).GetComponent<chua_sp_nhakho>().coso > 1)
            {
                canvas.transform.GetChild(0).GetChild(0).GetChild(canvas.GetComponent<get_nhakho>().id).GetComponent<chua_sp_nhakho>().coso--;
                nha_kho.instance.update_canvas_thongtin_hat(canvas.GetComponent<get_nhakho>().id);
            }
        }

    }
}
