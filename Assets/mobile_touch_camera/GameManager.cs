using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public DataNongSan dataNongSan;
    public DataVatNuoi dataVatNuoi;
    public Datacaylaunam dataCayLauNam;
    public DataIconAdd dataicon;
    public DataSPCheBien dataSPCheBien;
    public CayRung cayrung;
    public DataUI dataui;
    public DataNhaChinh datanhachinh;
    public DataShopXD datashopxd;
    public DataShopConvat datashopconvat;
    public DataShopCaylaunam datashopcaylaunam;
    public DataShopTrangTri datashoptrangtri;



    public GameObject dialogHG;
    public GameObject thuhoach;
    public GameObject canvasga;
    public GameObject hienthoigian;
    public GameObject thuhoachqua;
    public GameObject CanvasSXthuanconvat;
    public GameObject canvasChatcay;
    public GameObject nmSX;
    public GameObject canvas_bo_phomai;
    public GameObject canvas_nhamayhoaqua;
    public GameObject canvas_lonuongbanh_pizza;
    public GameObject canvas_lonuong_thit;
    public GameObject canvas_nhamat_ong;
    public GameObject canvas_nhamay_duong;
    public GameObject canvas_nhamay_bot;
    public GameObject canvas_nhamay_quang;
    public GameObject canvas_nhamay_suahop;
    public GameObject canvas_nhamay_sxruou;
    public GameObject canvas_phahuy_da;


    public GameObject Grid;
    GameObject obj;

    public GameObject Canvas_chinh;



    public GameObject cay_rung;
    public GameObject da_to;
    public GameObject o_dat;
    public GameObject homthu;
    public GameObject dentho;
    public GameObject bunhin;
    public GameObject hoacuc;
    public GameObject hoadongtien;
    public GameObject ghego;
    public GameObject ghesat;
    public GameObject ghesatvin;
    public GameObject meothantaitrang;
    public GameObject meothantaivang;

    public GameObject nhamaythucan;


    public GameObject Cay_cherry;
    public GameObject Cay_cam;
    public GameObject Cay_chanh;
    public GameObject Cay_tao;
    public GameObject Cay_anhdao;
    public GameObject Cay_dieu;
    public GameObject Cay_oliu;
    public GameObject Cay_luu;

    private void Awake()
    {
        instance = this;
        for (int i = 0; i < cay_rung.transform.childCount; i++)
        {
            if (cay_rung.transform.GetChild(i).CompareTag("cayrung"))
            {
                cay_rung.transform.GetChild(i).GetChild(0).GetComponent<cayrung>().id = i;
            }
            else if (cay_rung.transform.GetChild(i).CompareTag("danho"))
            {
                cay_rung.transform.GetChild(i).GetComponent<Phada>().id = i;
            }
        }


        for (int i = 0; i < da_to.transform.childCount; i++)
        {
            if (da_to.transform.GetChild(i).CompareTag("dato"))
            {
                da_to.transform.GetChild(i).GetComponent<Phada>().id = i;
            }
        }
    }
    private void Start()
    {
        loadData();
    }
    public void loadData()
    {
        DateTime timehientai = DateTime.Now;

        dataui.data[0].giatri = GameData.unitdata.dataui[0];
        dataui.data[1].giatri = GameData.unitdata.dataui[1];
        dataui.data[2].giatri = GameData.unitdata.dataui[2];
        for (int i = 0; i < dataNongSan.data.Length; i++)
        {
            dataNongSan.data[i].sanluong = GameData.unitdata.datanongsan[i];
        }
        for (int i = 0; i < datanhachinh.data.Length; i++)
        {
            datanhachinh.data[i].KinhNghiem = GameData.unitdata.datanhachinh[i];
        }
        for (int i = 0; i < dataVatNuoi.data.Length; i++)
        {
            dataVatNuoi.data[i].sl_sanpham = GameData.unitdata.datavatnuoi[i];
        }
        for (int i = 0; i < dataSPCheBien.data.Length; i++)
        {
            dataSPCheBien.data[i].sanluong = GameData.unitdata.dataspchebien[i];
        }

        for (int i = 0; i < datashopxd.data.Length; i++)
        {
            datashopxd.data[i].sl = GameData.unitdata.datashopxaydung[0,i];
            datashopxd.data[i].GioiHan = GameData.unitdata.datashopxaydung[1,i];
            datashopxd.data[i].Capmo = GameData.unitdata.datashopxaydung[2,i];
        }

        for (int i = 0; i < datashoptrangtri.data.Length; i++)
        {
            datashoptrangtri.data[i].sl = GameData.unitdata.datashoptrangtri[0, i];
            datashoptrangtri.data[i].GioiHan = GameData.unitdata.datashoptrangtri[1, i];
            datashoptrangtri.data[i].Capmo = GameData.unitdata.datashoptrangtri[2, i];
        }

        for (int i = 0; i < datashopconvat.data.Length; i++)
        {
            datashopconvat.data[i].sl = GameData.unitdata.datashopconvat[0, i];
            datashopconvat.data[i].GioiHan = GameData.unitdata.datashopconvat[1, i];
            datashopconvat.data[i].Capmo = GameData.unitdata.datashopconvat[2, i];
        }

        for (int i = 0; i < datashopcaylaunam.data.Length; i++)
        {
            datashopcaylaunam.data[i].sl = GameData.unitdata.datashopcaylaunam[0, i];
            datashopcaylaunam.data[i].GioiHan = GameData.unitdata.datashopcaylaunam[1, i];
            datashopcaylaunam.data[i].Capmo = GameData.unitdata.datashopcaylaunam[2, i];
        }

        for (int i = 0; i < 350; i++)
        {
            save_id_cay.instance.mang_id_chatcay[i] = GameData.unitdata._save_id_cay[i];
            if (save_id_cay.instance.mang_id_chatcay[i]>=0 && save_id_cay.instance.mang_id_chatcay[i]!=-1)
            {
                Destroy(cay_rung.transform.GetChild(save_id_cay.instance.mang_id_chatcay[i]).gameObject);
            }
        }

        for (int i = 0; i < 50; i++)
        {
            save_id_cay.instance.mang_id_da[i] = GameData.unitdata._save_id_da[i];
            if (save_id_cay.instance.mang_id_da[i]>=0 && save_id_cay.instance.mang_id_da[i]!=-1)
            {
                Destroy(cay_rung.transform.GetChild(save_id_cay.instance.mang_id_da[i]).gameObject);
            }
        }

        for (int i = 0; i < 20; i++)
        {
            save_id_dato.instance.mang_id_dato[i] = GameData.unitdata._save_id_dato[i];
            if (save_id_dato.instance.mang_id_dato[i]>=0&& save_id_dato.instance.mang_id_dato[i]!=-1)
            {
                Destroy(da_to.transform.GetChild(save_id_dato.instance.mang_id_dato[i]).gameObject);
            }
        }

        for (int i = 0; i < GameData.unitdata._mang_info_odat.Length/6; i++)
        {
            if (i>0)
            {
                GameObject obj = Instantiate(o_dat, Grid.transform.GetChild(1));
                obj.transform.position = new Vector3(GameData.unitdata._mang_info_odat[0, i],
                    GameData.unitdata._mang_info_odat[1, i], GameData.unitdata._mang_info_odat[2, i]);
            }
            Grid.transform.GetChild(1).GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 
                (int)GameData.unitdata._mang_info_odat[3, i];
            Grid.transform.GetChild(1).GetChild(i).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 
                (int)GameData.unitdata._mang_info_odat[3, i] + 1;
            Grid.transform.GetChild(1).GetChild(i).GetChild(0).GetComponent<o_dat>().id_sp = (int)GameData.unitdata._mang_info_odat[4, i];
            if (GameData.unitdata._mang_info_odat[4, i] != -1)
            {
                int time_odat = (int)GameData.unitdata._mang_info_odat[5, i];
                //int time_thuc_odat = time_odat;
                int time_thuc_odat = time_odat - Time_cho(GameData.unitdata.time, timehientai);
                if (time_thuc_odat < 0)
                {
                    time_thuc_odat = 0;
                }
                int t1=0, t2=0;

                if (time_thuc_odat > GameManager.instance.dataNongSan.data[(int)GameData.unitdata._mang_info_odat[4, i]].time2
                    && time_thuc_odat < GameManager.instance.dataNongSan.data[(int)GameData.unitdata._mang_info_odat[4, i]].time1 
                    + GameManager.instance.dataNongSan.data[(int)GameData.unitdata._mang_info_odat[4, i]].time2)
                {
                    t1 = time_thuc_odat - GameManager.instance.dataNongSan.data[(int)GameData.unitdata._mang_info_odat[4, i]].time2;
                    t2 = GameManager.instance.dataNongSan.data[(int)GameData.unitdata._mang_info_odat[4, i]].time2;
                    Grid.transform.GetChild(1).GetChild(i).GetChild(0).GetComponent<o_dat>().Start_Odat(
                        (int)GameData.unitdata._mang_info_odat[4, i], time_thuc_odat, t1, t2);
                }
                else if (time_thuc_odat > 0 && time_thuc_odat < GameManager.instance.dataNongSan.data[(int)GameData.unitdata._mang_info_odat[4, i]].time2)
                {
                    t1 = 0;
                    t2 = time_thuc_odat;
                    Grid.transform.GetChild(1).GetChild(i).GetChild(0).GetComponent<o_dat>().Start_Odat(
                        (int)GameData.unitdata._mang_info_odat[4, i], time_thuc_odat, t1, t2);
                }
                else if(time_thuc_odat == 0)
                {
                    Grid.transform.GetChild(1).GetChild(i).GetChild(0).GetComponent<o_dat>().isThuhoach = false;
                    Grid.transform.GetChild(1).GetChild(i).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite =
                    GameManager.instance.dataNongSan.data[(int)GameData.unitdata._mang_info_odat[4, i]].gd3;
                }
            }
            else
            {
                Grid.transform.GetChild(1).GetChild(i).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
            }
        }

        if (GameData.unitdata._mang_info_nhamay.Length>=0)
        {
            for (int i = 0; i < GameData.unitdata._mang_info_nhamay.Length/4; i++)
            {
                GameObject obj = Instantiate(nhamaythucan, Grid.transform.GetChild(3));



                obj.transform.position = new Vector3(GameData.unitdata._mang_info_nhamay[0, i],
                    GameData.unitdata._mang_info_nhamay[1, i], GameData.unitdata._mang_info_nhamay[2, i]);




                Grid.transform.GetChild(3).GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().sortingOrder =
                (int)GameData.unitdata._mang_info_nhamay[3, i];
                for (int j = 0; j < Grid.transform.GetChild(3).GetChild(i).GetChild(0).childCount; j++)
                {
                    Grid.transform.GetChild(3).GetChild(i).GetChild(0).GetChild(j).GetComponent<SpriteRenderer>().sortingOrder =
                        (int)GameData.unitdata._mang_info_nhamay[3, i] + 1;
                }



            }
        }

        // save thông tin của shop trang trí
        if (GameData.unitdata._mang_info_trangtri.Length>=0)
        {
            for (int i = 0; i < GameData.unitdata._mang_info_trangtri.Length / 5; i++)
            {
                if(GameData.unitdata._mang_info_trangtri[3, i] == 0)
                {
                    GameObject obj = Instantiate(homthu, Grid.transform.GetChild(5));
                    obj.transform.position = new Vector3(GameData.unitdata._mang_info_trangtri[0, i],
                    GameData.unitdata._mang_info_trangtri[1, i], GameData.unitdata._mang_info_trangtri[2, i]);
                }
                else if (GameData.unitdata._mang_info_trangtri[3, i] == 1)
                {
                    GameObject obj = Instantiate(dentho, Grid.transform.GetChild(5));
                    obj.transform.position = new Vector3(GameData.unitdata._mang_info_trangtri[0, i],
                    GameData.unitdata._mang_info_trangtri[1, i], GameData.unitdata._mang_info_trangtri[2, i]);
                }
                else if (GameData.unitdata._mang_info_trangtri[3, i] == 2)
                {
                    GameObject obj = Instantiate(bunhin, Grid.transform.GetChild(5));
                    obj.transform.position = new Vector3(GameData.unitdata._mang_info_trangtri[0, i],
                    GameData.unitdata._mang_info_trangtri[1, i], GameData.unitdata._mang_info_trangtri[2, i]);
                }
                else if (GameData.unitdata._mang_info_trangtri[3, i] == 3)
                {
                    GameObject obj = Instantiate(hoacuc, Grid.transform.GetChild(5));
                    obj.transform.position = new Vector3(GameData.unitdata._mang_info_trangtri[0, i],
                    GameData.unitdata._mang_info_trangtri[1, i], GameData.unitdata._mang_info_trangtri[2, i]);
                }
                else if (GameData.unitdata._mang_info_trangtri[3, i] == 4)
                {
                    GameObject obj = Instantiate(hoadongtien, Grid.transform.GetChild(5));
                    obj.transform.position = new Vector3(GameData.unitdata._mang_info_trangtri[0, i],
                    GameData.unitdata._mang_info_trangtri[1, i], GameData.unitdata._mang_info_trangtri[2, i]);
                }
                else if (GameData.unitdata._mang_info_trangtri[3, i] == 5)
                {
                    GameObject obj = Instantiate(ghego, Grid.transform.GetChild(5));
                    obj.transform.position = new Vector3(GameData.unitdata._mang_info_trangtri[0, i],
                    GameData.unitdata._mang_info_trangtri[1, i], GameData.unitdata._mang_info_trangtri[2, i]);
                }
                else if (GameData.unitdata._mang_info_trangtri[3, i] == 6)
                {
                    GameObject obj = Instantiate(ghesat, Grid.transform.GetChild(5));
                    obj.transform.position = new Vector3(GameData.unitdata._mang_info_trangtri[0, i],
                    GameData.unitdata._mang_info_trangtri[1, i], GameData.unitdata._mang_info_trangtri[2, i]);
                }
                else if (GameData.unitdata._mang_info_trangtri[3, i] == 7)
                {
                    GameObject obj = Instantiate(ghesatvin, Grid.transform.GetChild(5));
                    obj.transform.position = new Vector3(GameData.unitdata._mang_info_trangtri[0, i],
                    GameData.unitdata._mang_info_trangtri[1, i], GameData.unitdata._mang_info_trangtri[2, i]);
                }
                else if (GameData.unitdata._mang_info_trangtri[3, i] == 8)
                {
                    GameObject obj = Instantiate(meothantaitrang, Grid.transform.GetChild(5));
                    obj.transform.position = new Vector3(GameData.unitdata._mang_info_trangtri[0, i],
                    GameData.unitdata._mang_info_trangtri[1, i], GameData.unitdata._mang_info_trangtri[2, i]);
                }
                else if (GameData.unitdata._mang_info_trangtri[3, i] == 9)
                {
                    GameObject obj = Instantiate(meothantaivang, Grid.transform.GetChild(5));
                    obj.transform.position = new Vector3(GameData.unitdata._mang_info_trangtri[0, i],
                    GameData.unitdata._mang_info_trangtri[1, i], GameData.unitdata._mang_info_trangtri[2, i]);
                }


                Grid.transform.GetChild(5).GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().sortingOrder =
                (int)GameData.unitdata._mang_info_trangtri[4, i];
            }
        }

        // thông tin cây ăn quả

        if (GameData.unitdata._mang_info_cayanqua.Length>=0)
        {
            for (int i = 0; i < GameData.unitdata._mang_info_cayanqua.Length/7; i++)
            {
                
                if (GameData.unitdata._mang_info_cayanqua[4,i]==0)
                {
                    obj = Instantiate(Cay_cherry, Grid.transform.GetChild(4));
                }
                else if (GameData.unitdata._mang_info_cayanqua[4, i] == 1)
                {
                    obj = Instantiate(Cay_cam, Grid.transform.GetChild(4));
                }
                else if (GameData.unitdata._mang_info_cayanqua[4, i] == 2)
                {
                    obj = Instantiate(Cay_chanh, Grid.transform.GetChild(4));
                }
                else if (GameData.unitdata._mang_info_cayanqua[4, i] == 3)
                {
                    obj = Instantiate(Cay_tao, Grid.transform.GetChild(4));
                }
                else if (GameData.unitdata._mang_info_cayanqua[4, i] == 4)
                {
                    obj = Instantiate(Cay_anhdao, Grid.transform.GetChild(4));
                }
                else if (GameData.unitdata._mang_info_cayanqua[4, i] == 5)
                {
                    obj = Instantiate(Cay_dieu, Grid.transform.GetChild(4));
                }
                else if (GameData.unitdata._mang_info_cayanqua[4, i] == 6)
                {
                    obj = Instantiate(Cay_oliu, Grid.transform.GetChild(4));
                }
                else if (GameData.unitdata._mang_info_cayanqua[4, i] == 7)
                {
                    obj = Instantiate(Cay_luu, Grid.transform.GetChild(4));
                }
                obj.transform.position = new Vector3(GameData.unitdata._mang_info_cayanqua[0, i],
                    GameData.unitdata._mang_info_cayanqua[1, i], GameData.unitdata._mang_info_cayanqua[2, i]);
                Grid.transform.GetChild(4).GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().sortingOrder =
                    (int)GameData.unitdata._mang_info_cayanqua[3, i]; 
                Grid.transform.GetChild(4).GetChild(i).GetChild(1).GetComponent<SpriteRenderer>().sortingOrder =
                     (int)GameData.unitdata._mang_info_cayanqua[3, i];

                if (GameData.unitdata._mang_info_cayanqua[5, i] == 0)
                {
                    obj.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite
                        = GameManager.instance.dataNongSan.data[(int)GameData.unitdata._mang_info_cayanqua[6, i]].gd3;
                }
                /*else if (GameData.unitdata._mang_info_cayanqua[5, i] != 0)
                {
                    int time_cay = (int)GameData.unitdata._mang_info_cayanqua[5, i];
                    int time_thuc_cay = time_cay - Time_cho(GameData.unitdata.time, timehientai);
                    if (time_thuc_cay < 0)
                    {
                        time_thuc_cay = 0;
                    }
                    int t1, t2;
                    if (time_thuc_cay > dataNongSan.data[(int)GameData.unitdata._mang_info_cayanqua[4, i]].time2
                        && time_thuc_cay < dataNongSan.data[(int)GameData.unitdata._mang_info_cayanqua[4, i]].time1
                        + dataNongSan.data[(int)GameData.unitdata._mang_info_cayanqua[4, i]].time2)
                    {
                        t1 = time_thuc_cay - dataNongSan.data[(int)GameData.unitdata._mang_info_cayanqua[5, i]].time2;
                        t2 = dataNongSan.data[(int)GameData.unitdata._mang_info_cayanqua[5, i]].time2;
                        Grid.transform.GetChild(4).GetChild(i).GetChild(0).GetComponent<cayanqua>().phattrien_new((int)GameData.unitdata._mang_info_cayanqua[5, i],
                            t1, t2);
                    }
                    else if (time_thuc_cay > 0 && time_thuc_cay < dataNongSan.data[(int)GameData.unitdata._mang_info_cayanqua[4, i]].time2)
                    {
                        t1 = 0;
                        t2 = time_thuc_cay;
                        Grid.transform.GetChild(4).GetChild(i).GetChild(0).GetComponent<cayanqua>().phattrien_new((int)GameData.unitdata._mang_info_cayanqua[5, i],
                            t1, t2);
                    }
                    else if (time_thuc_cay == 0)
                    {
                        obj.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite
                        = GameManager.instance.dataNongSan.data[(int)GameData.unitdata._mang_info_cayanqua[4, i]].gd3;
                    }
                }*/


            }
        }


        Canvas_chinh.transform.GetChild(2).GetChild(0).GetComponent<Show_lv_game>().Start_ShowLevel();
        Grid.transform.GetChild(0).GetComponent<Tilemap>().Start_Tilemap();
    }


    int Time_cho(DateTime time_thoat, DateTime time_vao)
    {
        int y = time_vao.Year - time_thoat.Year;
        int m = time_vao.Month - time_thoat.Month;
        int d = time_vao.Day - time_thoat.Day;
        int h = time_vao.Hour - time_thoat.Hour;
        int mu = time_vao.Minute - time_thoat.Minute;
        int s = time_vao.Second - time_thoat.Second;
        if(y > 0)
        {
            s += y * 31536000;
        }
        if(m > 0)
        {
            s += m * 2592000;
        }
        if(d > 0)
        {
            s += d * 86400;
        }
        if(h > 0)
        {
            s += h * 3600;
        }
        if(mu > 0)
        {
            s += mu * 60;
        }
        return s;
    }
    public void dayCanvas_rangoai()
    {
        for (int i = 0; i < cay_rung.transform.childCount; i++)
        {
            if (cay_rung.transform.GetChild(i).CompareTag("cayrung"))
            {
                if (cay_rung.transform.GetChild(i).GetChild(0).GetComponent<cayrung>().xacdinh)
                {
                    cay_rung.transform.GetChild(i).GetChild(0).GetComponent<cayrung>().xacdinh = false;
                }
            }
            else if (cay_rung.transform.GetChild(i).CompareTag("danho"))
            {
                if (cay_rung.transform.GetChild(i).GetComponent<Phada>().xacdinh)
                {
                    cay_rung.transform.GetChild(i).GetComponent<Phada>().xacdinh = false;
                }
            }
        }

        for (int i = 0; i < da_to.transform.childCount; i++)
        {
            if (da_to.transform.GetChild(i).CompareTag("dato"))
            {
                if (da_to.transform.GetChild(i).GetComponent<Phada>().xacdinh)
                {
                    da_to.transform.GetChild(i).GetComponent<Phada>().xacdinh = false;
                }
            }
        }
        dialogHG.transform.position = new Vector3(999f, 999f, 0);
        thuhoach.transform.position = new Vector3(999f, 999f, 0);
        canvasga.transform.position = new Vector3(999f, 999f, 0);
        hienthoigian.transform.position = new Vector3(999f, 999f, 0);
        thuhoachqua.transform.position = new Vector3(999f, 999f, 0);
        CanvasSXthuanconvat.transform.position = new Vector3(999f, 999f, 0);
        canvasChatcay.transform.position = new Vector3(999f, 999f, 0);
        canvas_bo_phomai.transform.position = new Vector3(999f, 999f, 0);
        canvas_nhamayhoaqua.transform.position = new Vector3(999f, 999f, 0);
        canvas_lonuongbanh_pizza.transform.position = new Vector3(999f, 999f, 0);
        canvas_lonuong_thit.transform.position = new Vector3(999f, 999f, 0);
        canvas_nhamat_ong.transform.position = new Vector3(999f, 999f, 0);
        canvas_nhamay_duong.transform.position = new Vector3(999f, 999f, 0);
        canvas_nhamay_bot.transform.position = new Vector3(999f, 999f, 0);
        canvas_nhamay_quang.transform.position = new Vector3(999f, 999f, 0);
        canvas_nhamay_suahop.transform.position = new Vector3(999f, 999f, 0);
        canvas_nhamay_sxruou.transform.position = new Vector3(999f, 999f, 0);
        canvas_phahuy_da.transform.position = new Vector3(999f, 999f, 0);
    }

}
