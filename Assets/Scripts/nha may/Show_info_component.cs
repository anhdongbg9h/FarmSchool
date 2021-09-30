using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Show_info_component : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int sl_thanhphan;
    public GameObject thanhphan_chebien;
    public GameObject canvas;

    public int[] mang1;
    public int[] mang2;

    void save_idsp_iddata(int sltp)
    {
        GetComponent<example>().obj.GetComponent<ThucAnCheBien_Scripts>().sl_thanhphan = sltp;
        GetComponent<example>().obj.GetComponent<ThucAnCheBien_Scripts>().mang =
            new int[GetComponent<example>().obj.GetComponent<ThucAnCheBien_Scripts>().sl_thanhphan];
        GetComponent<example>().obj.GetComponent<ThucAnCheBien_Scripts>().mang_LT =
            new int[GetComponent<example>().obj.GetComponent<ThucAnCheBien_Scripts>().sl_thanhphan];

        for(int i = 0; i < sltp; i++)
        {
            GetComponent<example>().obj.GetComponent<ThucAnCheBien_Scripts>().mang[i] = mang1[i];
            GetComponent<example>().obj.GetComponent<ThucAnCheBien_Scripts>().mang_LT[i] = mang2[i];
        }
    }

    void Show_info(int id_sp, int iddata,int i)
    {
        if(iddata == 0)
        {
            thanhphan_chebien.transform.GetChild(i).GetComponent<Image>().sprite =
                   GameManager.instance.dataNongSan.data[id_sp].iconsanpham;
            thanhphan_chebien.transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                GameManager.instance.dataNongSan.data[id_sp].sanluong.ToString();
        }
        else if(iddata == 1)
        {
            thanhphan_chebien.transform.GetChild(i).GetComponent<Image>().sprite =
                   GameManager.instance.dataVatNuoi.data[id_sp].iconsanpham;
            thanhphan_chebien.transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                GameManager.instance.dataVatNuoi.data[id_sp].sl_sanpham.ToString();
        }
        else if(iddata == 2)
        {
            thanhphan_chebien.transform.GetChild(i).GetComponent<Image>().sprite =
                  GameManager.instance.dataSPCheBien.data[id_sp].iconsanpham;
            thanhphan_chebien.transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                GameManager.instance.dataSPCheBien.data[id_sp].sanluong.ToString();
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        thanhphan_chebien.SetActive(true);

        for(int i=0; i < sl_thanhphan; i++)
        {
            thanhphan_chebien.transform.GetChild(i).gameObject.SetActive(true);
            Show_info(mang1[i], mang2[i], i);
        }
        save_idsp_iddata(sl_thanhphan);


    }

    public void OnPointerUp(PointerEventData eventData)
    {
        for (int i = 0; i < sl_thanhphan; i++)
        {
            thanhphan_chebien.transform.GetChild(i).gameObject.SetActive(false);
        }
        thanhphan_chebien.SetActive(false);
        StartCoroutine(Delay_Click());
    }

    IEnumerator Delay_Click()
    {
        yield return new WaitForSeconds(0.01f*Time.deltaTime);
        canvas.transform.position = canvas.GetComponent<Save_vitrinhamay>().vitrinhamay + new Vector3(-0.6f, 0.5f, 0);
    }
}
