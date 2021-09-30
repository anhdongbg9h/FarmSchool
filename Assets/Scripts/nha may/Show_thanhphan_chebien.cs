using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Show_thanhphan_chebien : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static Show_thanhphan_chebien instance;
    public GameObject thanhphan_chebien;
    public int sl_thanhphan;
    public int[] mang;

    public GameObject canvas;


    private void Awake()
    {
        instance = this;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        thanhphan_chebien.SetActive(true);

        Update_thanhphan_chebien();

        GetComponent<example>().obj.GetComponent<ThucAnCheBien_Scripts>().sl_thanhphan = sl_thanhphan;
        GetComponent<example>().obj.GetComponent<ThucAnCheBien_Scripts>().mang = 
            new int[GetComponent<example>().obj.GetComponent<ThucAnCheBien_Scripts>().sl_thanhphan];
        for (int i = 0; i < sl_thanhphan; i++)
        {
            GetComponent<example>().obj.GetComponent<ThucAnCheBien_Scripts>().mang[i] = mang[i];
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        thanhphan_chebien.SetActive(false);
        for (int i = 0; i < sl_thanhphan; i++)
        {
            thanhphan_chebien.transform.GetChild(i).gameObject.SetActive(false);
            StartCoroutine(Delay_Click());
        }
    }

    void Update_thanhphan_chebien()
    {
        for (int i = 0; i < sl_thanhphan; i++)
        {
            thanhphan_chebien.transform.GetChild(i).gameObject.SetActive(true);

            thanhphan_chebien.transform.GetChild(i).GetComponent<Image>().sprite =
                GameManager.instance.dataNongSan.data[mang[i]].iconsanpham;
            thanhphan_chebien.transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                GameManager.instance.dataNongSan.data[mang[i]].sanluong.ToString();
        }
    }
    IEnumerator Delay_Click()
    {
        yield return new WaitForSeconds(0.01f*Time.deltaTime);
        canvas.transform.position = canvas.GetComponent<Save_vitrinhamay>().vitrinhamay + new Vector3(-0.6f, 0.5f, 0);
    }


}
