using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class shopcavans : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject shop;
    [SerializeField] GameObject nen;

    public void OnPointerDown(PointerEventData eventData)
    {
        for (int i = 0; i < GameManager.instance.datashopxd.data.Length; i++)
        {
            if (GameManager.instance.datashopxd.data[i].Capmo > GameManager.instance.dataui.data[2].giatri)
            {
                shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(i).GetChild(0).gameObject.SetActive(false);
                shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(i).GetChild(3).GetChild(0).gameObject.SetActive(false);
                shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(i).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                    + GameManager.instance.datashopxd.data[i].Capmo;
                shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(i).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(i).GetComponent<Sinhra_gameobject>().khoa = false;
                shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(i).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.datashopxd.data[i].sl.ToString();
                shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(i).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.datashopxd.data[i].GioiHan.ToString();
            }
            else if (GameManager.instance.datashopxd.data[i].Capmo <= GameManager.instance.dataui.data[2].giatri)
            {
                shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(i).GetChild(0).gameObject.SetActive(true);
                shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(i).GetComponent<Sinhra_gameobject>().khoa = true;
                shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(i).GetChild(3).GetChild(0).gameObject.SetActive(true);
                shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(i).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 30;
                shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(i).GetChild(3).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.datashopxd.data[i].Gia.ToString();
                shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(i).GetChild(4).gameObject.SetActive(true);
                shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(i).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.datashopxd.data[i].sl.ToString();
                shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(i).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.datashopxd.data[i].GioiHan.ToString();
            }
        }

        shop.SetActive(true);
        nen.SetActive(true);
    }

}
