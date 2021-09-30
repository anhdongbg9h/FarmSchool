using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Show_lv_game : MonoBehaviour
{
    //public GameObject Grid;
    public int level_player;
    public Image processBar;
    public TextMeshProUGUI KinhNghiemtext;

    [HideInInspector] public int kinhnghiem;
    [HideInInspector] public int gioihan;
    public GameObject panel_tangcap;

    //public TextMeshProUGUI lvtext;
    public void Start_ShowLevel()
    {
        gameObject.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text =
            GameManager.instance.dataui.data[2].giatri.ToString();
    }

    int setGiatriTime(DateTime timetruoc, DateTime timesau)
    {
        int y = timesau.Year - timetruoc.Year;
        int m = timesau.Month - timetruoc.Month;
        int d = timesau.Day - timetruoc.Day;
        int h = timesau.Hour - timetruoc.Hour;
        int mm = timesau.Minute - timetruoc.Minute;
        int s = timesau.Second - timetruoc.Second;
        if(y > 0)
        {
            s += y * 31557600;
        }
        if(m > 0)
        {
            s += m * 2629800;
        }
        if(d > 0)
        {
            s += d * 86400;
        }
        if(h > 0)
        {
            s += h * 3600;
        }
        if(mm > 0)
        {
            s += mm * 60;
        }
        return s;
    }

    private void Update()
    {
        gameObject.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text =
            GameManager.instance.dataui.data[2].giatri.ToString();
        kinhnghiem = GameManager.instance.datanhachinh.data[GameManager.instance.dataui.data[2].giatri-1].KinhNghiem;
        gioihan = GameManager.instance.datanhachinh.data[GameManager.instance.dataui.data[2].giatri-1].GioiHanKinhNghiem;

        processBar.fillAmount = (float)kinhnghiem / (float)gioihan;
        KinhNghiemtext.text = kinhnghiem.ToString() + "/" + gioihan.ToString();

        if (GameManager.instance.datanhachinh.data[GameManager.instance.dataui.data[2].giatri - 1].KinhNghiem >=
            GameManager.instance.datanhachinh.data[GameManager.instance.dataui.data[2].giatri - 1].GioiHanKinhNghiem)
        {
            GameManager.instance.datanhachinh.data[GameManager.instance.dataui.data[2].giatri].KinhNghiem =
                GameManager.instance.datanhachinh.data[GameManager.instance.dataui.data[2].giatri - 1].KinhNghiem
                - GameManager.instance.datanhachinh.data[GameManager.instance.dataui.data[2].giatri - 1].GioiHanKinhNghiem;
            GameManager.instance.dataui.data[2].giatri++;
            gameObject.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text =
            GameManager.instance.dataui.data[2].giatri.ToString();
            StartCoroutine(tangLevel());
        }
    }

    public void Tang1cap()
    {
        if (GameManager.instance.dataui.data[2].giatri>0 && GameManager.instance.dataui.data[2].giatri<30)
        {
            GameManager.instance.dataui.data[2].giatri++;
            StartCoroutine(tangLevel());
        }
    }
    public void Giam1cap()
    {
        if (GameManager.instance.dataui.data[2].giatri > 1)
        {
            GameManager.instance.dataui.data[2].giatri--;
        }
    }

    IEnumerator tangLevel()
    {
        panel_tangcap.SetActive(true);
        yield return new WaitForSeconds(1f);
        panel_tangcap.SetActive(false);
    }

}
// tăng +1
// giảm -1