using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class BT_nangcap_nhakho : MonoBehaviour,IPointerDownHandler
{
    public static BT_nangcap_nhakho instance;
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
        if (get_nhakho.instance.transform.GetChild(6).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text == nha_kho.instance.GetComponent<nha_kho>().lv_nhakho.ToString() &&
                get_nhakho.instance.transform.GetChild(6).GetChild(1).GetChild(2).GetComponent<TextMeshProUGUI>().text == nha_kho.instance.GetComponent<nha_kho>().lv_nhakho.ToString() &&
                get_nhakho.instance.transform.GetChild(6).GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text == nha_kho.instance.GetComponent<nha_kho>().lv_nhakho.ToString())
        {
            nha_kho.instance.GetComponent<nha_kho>().lv_nhakho++;
            nha_kho.instance.GetComponent<nha_kho>().suc_chua += 25;
            nha_kho.instance.GetComponent<nha_kho>().Update_nhakho();
            mang = new int[3];
            canvas.SetActive(false);

        }
        for (int i = 0; i < 3; i++)
        {
            get_nhakho.instance.transform.GetChild(6).GetChild(i).GetChild(4).GetChild(2).GetComponent<TextMeshProUGUI>().text =
                nha_kho.instance.lv_nhakho.ToString();
            get_nhakho.instance.transform.GetChild(6).GetChild(i).GetChild(2).GetComponent<TextMeshProUGUI>().text = mang[i].ToString();
            get_nhakho.instance.transform.GetChild(6).GetChild(i).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                nha_kho.instance.lv_nhakho.ToString();
        }

        canvas.SetActive(true);
        show_info.SetActive(false);
    }
}
