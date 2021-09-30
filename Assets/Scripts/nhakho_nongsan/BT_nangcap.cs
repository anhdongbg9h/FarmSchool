using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class BT_nangcap : MonoBehaviour, IPointerDownHandler
{
    public static BT_nangcap instance;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject show_info;

    [HideInInspector] public int[] mang;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        mang = new int[3];
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (instaceCanvas.instance.transform.GetChild(6).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text == nhakho_nongsan.instance.GetComponent<nhakho_nongsan>().lv_nhakho.ToString() &&
                instaceCanvas.instance.transform.GetChild(6).GetChild(1).GetChild(2).GetComponent<TextMeshProUGUI>().text == nhakho_nongsan.instance.GetComponent<nhakho_nongsan>().lv_nhakho.ToString() &&
                instaceCanvas.instance.transform.GetChild(6).GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text == nhakho_nongsan.instance.GetComponent<nhakho_nongsan>().lv_nhakho.ToString())
        {
            nhakho_nongsan.instance.GetComponent<nhakho_nongsan>().lv_nhakho++;
            nhakho_nongsan.instance.GetComponent<nhakho_nongsan>().suc_chua += 25;
            nhakho_nongsan.instance.GetComponent<nhakho_nongsan>().Update_sl();
            mang = new int[3];
            canvas.SetActive(false);

        }
        for (int i=0; i<3; i++)
        {
            instaceCanvas.instance.transform.GetChild(6).GetChild(i).GetChild(4).GetChild(2).GetComponent<TextMeshProUGUI>().text =
                nhakho_nongsan.instance.lv_nhakho.ToString();
            instaceCanvas.instance.transform.GetChild(6).GetChild(i).GetChild(2).GetComponent<TextMeshProUGUI>().text = mang[i].ToString();
            instaceCanvas.instance.transform.GetChild(6).GetChild(i).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                nhakho_nongsan.instance.lv_nhakho.ToString();
        }

        canvas.SetActive(true);
        show_info.SetActive(false);
    }
}
