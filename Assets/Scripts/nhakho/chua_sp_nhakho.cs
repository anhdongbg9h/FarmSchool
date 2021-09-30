using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class chua_sp_nhakho : MonoBehaviour, IPointerDownHandler
{
    public static chua_sp_nhakho instance;
    public int id_o_chua_sp;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject chua_sp;
    public int coso;
    public int giaban;



    private void Awake()
    {
        instance = this;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Tinh_coso();
        get_nhakho.instance.id = id_o_chua_sp;
        nha_kho.instance.Tinh_coso(id_o_chua_sp);
        coso = nha_kho.instance.coso;
        giaban = nha_kho.instance.giaban;

        canvas.SetActive(true);
        chua_sp.SetActive(true);

        chua_sp.transform.GetChild(9).GetComponent<TextMeshProUGUI>().text = coso.ToString();
        chua_sp.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = (giaban*coso).ToString();


    }
}
