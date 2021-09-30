
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Click_order : MonoBehaviour
{
    public GameObject Order_UI;
    public GameObject Panel_info_donhang;
    public GameObject Canvas;
    public GameObject Canvas_chinh;
    public GameObject Panel_order_donhang;

    

    private void Start()
    {

        // show ra số lượng đơn
        for (int i = 0; i < GameManager.instance.dataui.data[2].giatri; i++)
        {
            if (i>6)
            {
                break;
            }
            else
            {
                gameObject.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

    private void OnMouseDown()
    {
        //Start();
        for (int i = 0; i < 6; i++)
        {
            Panel_order_donhang.transform.GetChild(i + 2).GetChild(0).gameObject.SetActive(true);
        }
        for (int i = 0; i < GameManager.instance.dataui.data[2].giatri; i++)
        {
            if (i > 6)
            {
                break;
            }
            else
            {
                Panel_order_donhang.transform.GetChild(i + 2).gameObject.SetActive(true);
            }
        }

        Panel_info_donhang.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = 0.ToString();
        Panel_info_donhang.transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = 0.ToString();

        Panel_info_donhang.transform.GetChild(3).gameObject.SetActive(false);
        Panel_info_donhang.transform.GetChild(4).gameObject.SetActive(false);
        Panel_info_donhang.transform.GetChild(5).gameObject.SetActive(false);


        Order_UI.gameObject.SetActive(true);
        Canvas.gameObject.SetActive(true);
        Canvas_chinh.gameObject.SetActive(false);
    }
}
