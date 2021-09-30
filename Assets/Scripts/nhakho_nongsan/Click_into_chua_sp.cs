using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Click_into_chua_sp : MonoBehaviour, IPointerDownHandler
{
    public static Click_into_chua_sp instance;
    public int id_o_chua_sp;
    [HideInInspector] public int coso;
    [HideInInspector] public int giaban;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject chua_sp;

    private void Awake()
    {
        instance = this;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        //update_canvas_thongtin_hat();
        Tinh_coso();
        instaceCanvas.instance.id = id_o_chua_sp;
        canvas.SetActive(true);
        chua_sp.SetActive(true);
    }

    public void update_canvas_thongtin_hat(int id)
    {
        instaceCanvas.instance.transform.GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
            GameManager.instance.dataNongSan.data[nhakho_nongsan.instance.mang[id]].nameVNI;
        instaceCanvas.instance.transform.GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
            GameManager.instance.dataNongSan.data[nhakho_nongsan.instance.mang[id]].nguongoc;
        instaceCanvas.instance.transform.GetChild(4).GetChild(2).GetComponent<Image>().sprite =
            GameManager.instance.dataNongSan.data[nhakho_nongsan.instance.mang[id]].iconsanpham;
        if (coso==0)
        {
            instaceCanvas.instance.transform.GetChild(4).GetChild(9).GetComponent<TextMeshProUGUI>().text = (coso+1).ToString();
            instaceCanvas.instance.transform.GetChild(4).GetChild(6).GetComponent<TextMeshProUGUI>().text = (giaban * (coso+1)).ToString();
        }
        else
        {
            instaceCanvas.instance.transform.GetChild(4).GetChild(9).GetComponent<TextMeshProUGUI>().text = coso.ToString();
            instaceCanvas.instance.transform.GetChild(4).GetChild(6).GetComponent<TextMeshProUGUI>().text = (giaban * coso).ToString();
        }
    }

    public void Tinh_coso()
    {
        coso = GameManager.instance.dataNongSan.data[nhakho_nongsan.instance.mang[id_o_chua_sp]].sanluong / 2;
        giaban = GameManager.instance.dataNongSan.data[nhakho_nongsan.instance.mang[id_o_chua_sp]].giaban;

        update_canvas_thongtin_hat(id_o_chua_sp);
    }
}
