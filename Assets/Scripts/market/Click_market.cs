using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Click_market : MonoBehaviour
{
    public GameObject Market;
    public GameObject Canvas;
    public GameObject Canvas_chinh;
    int random_pt_data;
    public int dem = 0;


    public void Start()
    {
        for (int i = 0; i < GameManager.instance.dataui.data[2].giatri; i++)
        {
            int t = Random.Range(1, 4);
            if (t == 1)
            {
                do
                {
                    random_pt_data = Random.Range(0, GameManager.instance.dataNongSan.data.Length);
                }
                while (GameManager.instance.dataNongSan.data[random_pt_data].capmo > GameManager.instance.dataui.data[2].giatri);
                // show hình ảnh
                Market.transform.GetChild(0).GetChild(i + 2).GetChild(0).GetChild(1).GetComponent<Image>().sprite =
                        GameManager.instance.dataNongSan.data[random_pt_data].iconsanpham;
                Market.transform.GetChild(0).GetChild(i + 2).GetChild(0).GetChild(1).GetComponent<Image>().color =
                    new Color32(255, 255, 255, 255);
                // show số lượng text
                Market.transform.GetChild(0).GetChild(i + 2).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = 1.ToString();
                // show giá bán
                Market.transform.GetChild(0).GetChild(i + 2).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataNongSan.data[random_pt_data].giamua.ToString();
                Market.transform.GetChild(0).GetChild(i + 2).GetChild(1).GetComponent<Btn_sell>().id_data = 1;
                Market.transform.GetChild(0).GetChild(i + 2).GetChild(1).GetComponent<Btn_sell>().id_sp = random_pt_data;

            }
            else if (t == 2)
            {
                do
                {
                    random_pt_data = Random.Range(0, GameManager.instance.dataSPCheBien.data.Length);
                }
                while (GameManager.instance.dataSPCheBien.data[random_pt_data].capmo > GameManager.instance.dataui.data[2].giatri);
                
                // show hình ảnh
                Market.transform.GetChild(0).GetChild(i + 2).GetChild(0).GetChild(1).GetComponent<Image>().sprite =
                        GameManager.instance.dataSPCheBien.data[random_pt_data].iconsanpham;
                Market.transform.GetChild(0).GetChild(i + 2).GetChild(0).GetChild(1).GetComponent<Image>().color =
                    new Color32(255, 255, 255, 255);
                // show số lượng text
                Market.transform.GetChild(0).GetChild(i + 2).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = 1.ToString();
                // show giá bán
                Market.transform.GetChild(0).GetChild(i + 2).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataSPCheBien.data[random_pt_data].giamua.ToString();


                Market.transform.GetChild(0).GetChild(i + 2).GetChild(1).GetComponent<Btn_sell>().id_data = 2;
                Market.transform.GetChild(0).GetChild(i + 2).GetChild(1).GetComponent<Btn_sell>().id_sp = random_pt_data;
            }
            else if (t == 3)
            {
                do
                {
                    random_pt_data = Random.Range(0, GameManager.instance.dataVatNuoi.data.Length);
                }
                while (GameManager.instance.dataVatNuoi.data[random_pt_data].capmo > GameManager.instance.dataui.data[2].giatri);
                // show hình ảnh
                Market.transform.GetChild(0).GetChild(i + 2).GetChild(0).GetChild(1).GetComponent<Image>().sprite =
                        GameManager.instance.dataVatNuoi.data[random_pt_data].iconsanpham;
                Market.transform.GetChild(0).GetChild(i + 2).GetChild(0).GetChild(1).GetComponent<Image>().color =
                    new Color32(255, 255, 255, 255);
                // show số lượng text
                Market.transform.GetChild(0).GetChild(i + 2).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = 1.ToString();
                // show giá bán
                Market.transform.GetChild(0).GetChild(i + 2).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataVatNuoi.data[random_pt_data].giamua.ToString();


                Market.transform.GetChild(0).GetChild(i + 2).GetChild(1).GetComponent<Btn_sell>().id_data = 3;
                Market.transform.GetChild(0).GetChild(i + 2).GetChild(1).GetComponent<Btn_sell>().id_sp = random_pt_data;
            }
        }
    }

    private void OnMouseDown()
    {
        //Start();
        Market.gameObject.SetActive(true);
        Canvas.gameObject.SetActive(true);
        Canvas_chinh.gameObject.SetActive(false);
    }
}
