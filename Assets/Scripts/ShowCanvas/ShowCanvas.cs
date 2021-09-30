using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowCanvas : MonoBehaviour
{
    public static ShowCanvas instance;
    public GameObject Canvas_thuong;
    public GameObject Canvas;

    private void Awake()
    {
        instance = this;
    }

    public void Update()
    {
        gameObject.transform.GetChild(1).GetChild(2).GetComponent<TextMeshProUGUI>().text =
            GameManager.instance.dataui.data[0].giatri.ToString();
        gameObject.transform.GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text =
            GameManager.instance.dataui.data[1].giatri.ToString();
    }


    public void Active_canvas_thuong()
    {
        Canvas_thuong.SetActive(true);
        Canvas.SetActive(true);
    }

    public void Btn_exit_canvas_thuong()
    {
        Canvas_thuong.SetActive(false);
        Canvas.SetActive(false);
    }

}
