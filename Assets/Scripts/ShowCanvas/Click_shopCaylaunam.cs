using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Click_shopCaylaunam : MonoBehaviour,IPointerDownHandler
{
    
    [SerializeField] GameObject shop;
    public void OnPointerDown(PointerEventData eventData)
    {
        for (int i = 0; i < GameManager.instance.datashopcaylaunam.data.Length; i++)
        {
            if (GameManager.instance.datashopcaylaunam.data[i].Capmo > GameManager.instance.dataui.data[2].giatri)
            {
                shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(i).GetChild(0).gameObject.SetActive(false);
                shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(i).GetChild(3).GetChild(0).gameObject.SetActive(false);
                shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(i).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                    + GameManager.instance.datashopcaylaunam.data[i].Capmo;
                shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(i).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(i).GetComponent<Sinhra_gameobject>().khoa = false;
                shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(i).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.datashopcaylaunam.data[i].sl.ToString();
                shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(i).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.datashopcaylaunam.data[i].GioiHan.ToString();
            }
            else if (GameManager.instance.datashopcaylaunam.data[i].Capmo <= GameManager.instance.dataui.data[2].giatri)
            {
                shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(i).GetChild(0).gameObject.SetActive(true);
                shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(i).GetComponent<Sinhra_gameobject>().khoa = true;
                shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(i).GetChild(3).GetChild(0).gameObject.SetActive(true);
                shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(i).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 30;

                shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(i).GetChild(3).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.datashopcaylaunam.data[i].Gia.ToString();
                shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(i).GetChild(4).gameObject.SetActive(true);
                shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(i).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.datashopcaylaunam.data[i].sl.ToString();
                shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(i).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.datashopcaylaunam.data[i].GioiHan.ToString();
            }
        }
    }
}
