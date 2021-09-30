using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class UnitData
{
    public int lvplayer;
    public int[] dataui;
    public int[] datanongsan;
    public int[] datanhachinh;
    public int[] datavatnuoi;
    public int[] dataspchebien;
    public int[,] datashopxaydung;
    public int[,] datashoptrangtri;
    public int[,] datashopconvat;
    public int[,] datashopcaylaunam;

    public float[,] _mang_info_odat;
    public float[,] _mang_info_nhamay;
    public float[,] _mang_info_trangtri;
    public float[,] _mang_info_cayanqua;

    public int[] _save_id_cay;
    public int[] _save_id_da;
    public int[] _save_id_dato;

    public System.DateTime time;

    private string KEY_DATA = "unitdata";

    // khởi tạo các giá trị ban đầu
    public UnitData()
    {
        lvplayer = 1;

        dataui = new int[3];
        dataui[0] = 10000;
        dataui[1] = 10000;
        dataui[2] = 1;

        datanongsan = new int[26];
        for(int i = 0; i < 26; i++)
        {
            datanongsan[i] = 3;
        }

        datanhachinh = new int[30];
        for (int i = 0; i < 30; i++)
        {
            datanhachinh[i] = 0;
        }

        datavatnuoi = new int[6];
        for (int i = 0; i < 6; i++)
        {
            datavatnuoi[i] = 3;
        }

        dataspchebien = new int[62];
        for (int i = 0; i < 62; i++)
        {
            dataspchebien[i] = 3;
        }

        Save_data_shop_xd();

        Save_data_shop_trangtri();

        Save_data_shop_convat();

        Save_data_shop_caylaunam();

        _save_id_cay = new int[350];
        for (int i = 0; i < 350; i++)
        {
            _save_id_cay[i] = -1;
        }

        _save_id_da = new int[50];
        for (int i = 0; i < 50; i++)
        {
            _save_id_da[i] = -1;
        }
        _save_id_dato = new int[20];
        for (int i = 0; i < 20; i++)
        {
            _save_id_dato[i] = -1;
        }

        _mang_info_odat = new float[6, 1];
        _mang_info_odat[3, 0] = 152;
        _mang_info_odat[4, 0] = -1;
        _mang_info_odat[5, 0] = -1;

        _mang_info_nhamay = new float[3, 0];

        _mang_info_trangtri = new float[5, 0];

        _mang_info_cayanqua = new float[7, 0];
    }
    // Save dữ liệu

    public void Save(GameObject Grid)
    {
        lvplayer = GameManager.instance.dataui.data[2].giatri;

        dataui = new int[3];
        dataui[0] = GameManager.instance.dataui.data[0].giatri;
        dataui[1] = GameManager.instance.dataui.data[1].giatri;
        dataui[2] = GameManager.instance.dataui.data[2].giatri;

        datanongsan = new int[26];
        for (int i = 0; i < 26; i++)
        {
            datanongsan[i] = GameManager.instance.dataNongSan.data[i].sanluong;
        }

        datanhachinh = new int[30];
        for (int i = 0; i < 30; i++)
        {
            datanhachinh[i] = GameManager.instance.datanhachinh.data[i].KinhNghiem;
        }

        datavatnuoi = new int[6];
        for (int i = 0; i < 6; i++)
        {
            datavatnuoi[i] = GameManager.instance.dataVatNuoi.data[i].sl_sanpham;
        }

        dataspchebien = new int[62];
        for (int i = 0; i < 62; i++)
        {
            dataspchebien[i] = GameManager.instance.dataSPCheBien.data[i].sanluong;
        }

        datashopxaydung = new int[3, 12];
        for (int i = 0; i < 12; i++)
        {
            datashopxaydung[0, i] = GameManager.instance.datashopxd.data[i].sl;
            datashopxaydung[1, i] = GameManager.instance.datashopxd.data[i].GioiHan;
            datashopxaydung[2, i] = GameManager.instance.datashopxd.data[i].Capmo;
        }

        datashoptrangtri = new int[3, 10];
        for (int i = 0; i < 10; i++)
        {
            datashoptrangtri[0, i] = GameManager.instance.datashoptrangtri.data[i].sl;
            datashoptrangtri[1, i] = GameManager.instance.datashoptrangtri.data[i].GioiHan;
            datashoptrangtri[2, i] = GameManager.instance.datashoptrangtri.data[i].Capmo;
        }

        datashopconvat = new int[3, 12];
        for (int i = 0; i < 12; i++)
        {
            datashopconvat[0, i] = GameManager.instance.datashopconvat.data[i].sl;
            datashopconvat[1, i] = GameManager.instance.datashopconvat.data[i].GioiHan;
            datashopconvat[2, i] = GameManager.instance.datashopconvat.data[i].Capmo;
        }

        datashopcaylaunam = new int[3, 8];
        for (int i = 0; i < 8; i++)
        {
            datashopcaylaunam[0, i] = GameManager.instance.datashopcaylaunam.data[i].sl;
            datashopcaylaunam[1, i] = GameManager.instance.datashopcaylaunam.data[i].GioiHan;
            datashopcaylaunam[2, i] = GameManager.instance.datashopcaylaunam.data[i].Capmo;
        }

        _save_id_cay = new int[350];
        for (int i = 0; i < 350; i++)
        {
            _save_id_cay[i] = save_id_cay.instance.mang_id_chatcay[i];
        }

        _save_id_da = new int[50];
        for (int i = 0; i < 50; i++)
        {
            _save_id_da[i] = save_id_cay.instance.mang_id_da[i];
        }

        _save_id_dato = new int[20];
        for (int i = 0; i < 20; i++)
        {
            _save_id_dato[i] = save_id_dato.instance.mang_id_dato[i];
        }


        _mang_info_odat = new float[6,Grid.transform.GetChild(1).childCount];
        for (int i = 0; i < Grid.transform.GetChild(1).childCount; i++)
        {
            _mang_info_odat[0, i] = Grid.transform.GetChild(1).GetChild(i).position.x;
            _mang_info_odat[1, i] = Grid.transform.GetChild(1).GetChild(i).position.y;
            _mang_info_odat[2, i] = Grid.transform.GetChild(1).GetChild(i).position.z;
            _mang_info_odat[3, i] = 
                Grid.transform.GetChild(1).GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().sortingOrder;
            _mang_info_odat[4, i] = Grid.transform.GetChild(1).GetChild(i).GetChild(0).GetComponent<o_dat>().id_sp;
            _mang_info_odat[5, i] = Grid.transform.GetChild(1).GetChild(i).GetChild(0).GetComponent<o_dat>().timeTotal;

        }

        // save thông tin nhà máy thức ăn
        _mang_info_nhamay = new float[4, Grid.transform.GetChild(3).childCount];
        for (int i = 0; i < Grid.transform.GetChild(3).childCount; i++)
        {
            _mang_info_nhamay[0, i] = Grid.transform.GetChild(3).GetChild(i).position.x;
            _mang_info_nhamay[1, i] = Grid.transform.GetChild(3).GetChild(i).position.y;
            _mang_info_nhamay[2, i] = Grid.transform.GetChild(3).GetChild(i).position.z;
            _mang_info_nhamay[3, i] = 
                Grid.transform.GetChild(3).GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().sortingOrder;

        }


        _mang_info_trangtri = new float[5, Grid.transform.GetChild(5).childCount];
        for (int i = 0; i < Grid.transform.GetChild(5).childCount; i++)
        {
            _mang_info_trangtri[0,i]= Grid.transform.GetChild(5).GetChild(i).position.x;
            _mang_info_trangtri[1,i]= Grid.transform.GetChild(5).GetChild(i).position.y;
            _mang_info_trangtri[2,i]= Grid.transform.GetChild(5).GetChild(i).position.z;
            _mang_info_trangtri[3,i]= Grid.transform.GetChild(5).GetChild(i).GetComponent<Id_do_trangtri>().id;
            _mang_info_trangtri[4,i]= Grid.transform.GetChild(5).GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().sortingOrder;
        }


        _mang_info_cayanqua = new float[7, Grid.transform.GetChild(4).childCount];

        for (int i = 0; i < Grid.transform.GetChild(4).childCount; i++)
        {
            _mang_info_cayanqua[0, i] = Grid.transform.GetChild(4).GetChild(i).position.x;
            _mang_info_cayanqua[1, i] = Grid.transform.GetChild(4).GetChild(i).position.y;
            _mang_info_cayanqua[2, i] = Grid.transform.GetChild(4).GetChild(i).position.z;
            _mang_info_cayanqua[3, i] = Grid.transform.GetChild(4).GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().sortingOrder;
            _mang_info_cayanqua[4, i] = Grid.transform.GetChild(4).GetChild(i).GetComponent<Id_do_trangtri>().id;
            _mang_info_cayanqua[5, i] = Grid.transform.GetChild(4).GetChild(i).GetChild(0).GetComponent<cayanqua>().timeTotal;
            _mang_info_cayanqua[6, i] = Grid.transform.GetChild(4).GetChild(i).GetChild(0).GetComponent<cayanqua>().id;
        }



        time = System.DateTime.Now;

        // convert dữ liệu sang dạng string
        string s = JsonConvert.SerializeObject(this);
        // dùng playerprefs để lưu giá trị hiện tại
        PlayerPrefs.SetString(KEY_DATA, s);
    }
    public void Save_data_shop_xd()
    {
        datashopxaydung = new int[3, 12];

        datashopxaydung[0, 0] = 1;
        datashopxaydung[1, 0] = 3;
        datashopxaydung[2, 0] = 1;

        datashopxaydung[0, 1] = 0;
        datashopxaydung[1, 1] = 1;
        datashopxaydung[2, 1] = 1;

        datashopxaydung[0, 2] = 0;
        datashopxaydung[1, 2] = 1;
        datashopxaydung[2, 2] = 5;

        datashopxaydung[0, 3] = 0;
        datashopxaydung[1, 3] = 1;
        datashopxaydung[2, 3] = 5;

        datashopxaydung[0, 4] = 0;
        datashopxaydung[1, 4] = 1;
        datashopxaydung[2, 4] = 15;

        datashopxaydung[0, 5] = 0;
        datashopxaydung[1, 5] = 1;
        datashopxaydung[2, 5] = 20;

        datashopxaydung[0, 6] = 0;
        datashopxaydung[1, 6] = 1;
        datashopxaydung[2, 6] = 10;

        datashopxaydung[0, 7] = 0;
        datashopxaydung[1, 7] = 1;
        datashopxaydung[2, 7] = 7;

        datashopxaydung[0, 8] = 0;
        datashopxaydung[1, 8] = 1;
        datashopxaydung[2, 8] = 7;

        datashopxaydung[0, 9] = 0;
        datashopxaydung[1, 9] = 1;
        datashopxaydung[2, 9] = 7;

        datashopxaydung[0, 10] =0;
        datashopxaydung[1, 10] = 1;
        datashopxaydung[2, 10] = 10;

        datashopxaydung[0, 11] = 0;
        datashopxaydung[1, 11] = 1;
        datashopxaydung[2, 11] = 15;
    }
    public void Save_data_shop_trangtri()
    {
        datashoptrangtri = new int[3, 10];

        datashoptrangtri[0, 0] = 0;
        datashoptrangtri[1, 0] = 1;
        datashoptrangtri[2, 0] = 2;

        datashoptrangtri[0, 1] = 0;
        datashoptrangtri[1, 1] = 1;
        datashoptrangtri[2, 1] = 3;

        datashoptrangtri[0, 2] = 0;
        datashoptrangtri[1, 2] = 1;
        datashoptrangtri[2, 2] = 4;

        datashoptrangtri[0, 3] = 0;
        datashoptrangtri[1, 3] = 1;
        datashoptrangtri[2, 3] = 5;

        datashoptrangtri[0, 4] = 0;
        datashoptrangtri[1, 4] = 1;
        datashoptrangtri[2, 4] = 7;

        datashoptrangtri[0, 5] = 0;
        datashoptrangtri[1, 5] = 1;
        datashoptrangtri[2, 5] = 8;

        datashoptrangtri[0, 6] = 0;
        datashoptrangtri[1, 6] = 1;
        datashoptrangtri[2, 6] = 9;

        datashoptrangtri[0, 7] = 0;
        datashoptrangtri[1, 7] = 1;
        datashoptrangtri[2, 7] = 10;

        datashoptrangtri[0, 8] = 0;
        datashoptrangtri[1, 8] = 1;
        datashoptrangtri[2, 8] = 11;

        datashoptrangtri[0, 9] = 0;
        datashoptrangtri[1, 9] = 1;
        datashoptrangtri[2, 9] = 12;
    }
    public void Save_data_shop_convat()
    {
        datashopconvat = new int[3, 12];

        datashopconvat[0, 0] = 0;
        datashopconvat[1, 0] = 1;
        datashopconvat[2, 0] = 1;

        datashopconvat[0, 1] = 0;
        datashopconvat[1, 1] = 3;
        datashopconvat[2, 1] = 1;

        datashopconvat[0, 2] = 0;
        datashopconvat[1, 2] = 1;
        datashopconvat[2, 2] = 5;

        datashopconvat[0, 3] = 0;
        datashopconvat[1, 3] = 3;
        datashopconvat[2, 3] = 5;

        datashopconvat[0, 4] = 0;
        datashopconvat[1, 4] = 1;
        datashopconvat[2, 4] = 7;

        datashopconvat[0, 5] = 0;
        datashopconvat[1, 5] = 3;
        datashopconvat[2, 5] = 7;

        datashopconvat[0, 6] = 0;
        datashopconvat[1, 6] = 1;
        datashopconvat[2, 6] = 10;

        datashopconvat[0, 7] = 0;
        datashopconvat[1, 7] = 3;
        datashopconvat[2, 7] = 10;

        datashopconvat[0, 8] = 0;
        datashopconvat[1, 8] = 1;
        datashopconvat[2, 8] = 15;

        datashopconvat[0, 9] = 0;
        datashopconvat[1, 9] = 3;
        datashopconvat[2, 9] = 15;

        datashopconvat[0, 10] = 0;
        datashopconvat[1, 10] = 1;
        datashopconvat[2, 10] = 7;

        datashopconvat[0, 11] = 0;
        datashopconvat[1, 11] = 3;
        datashopconvat[2, 11] = 7;
    }
    public void Save_data_shop_caylaunam()
    {
        datashopcaylaunam = new int[3, 8];

        datashopcaylaunam[0, 0] = 0;
        datashopcaylaunam[1, 0] = 1;
        datashopcaylaunam[2, 0] = 1;

        datashopcaylaunam[0, 1] = 0;
        datashopcaylaunam[1, 1] = 1;
        datashopcaylaunam[2, 1] = 3;

        datashopcaylaunam[0, 2] = 0;
        datashopcaylaunam[1, 2] = 1;
        datashopcaylaunam[2, 2] = 5;

        datashopcaylaunam[0, 3] = 0;
        datashopcaylaunam[1, 3] = 1;
        datashopcaylaunam[2, 3] = 7;

        datashopcaylaunam[0, 4] = 0;
        datashopcaylaunam[1, 4] = 1;
        datashopcaylaunam[2, 4] = 9;

        datashopcaylaunam[0, 5] = 0;
        datashopcaylaunam[1, 5] = 1;
        datashopcaylaunam[2, 5] = 12;

        datashopcaylaunam[0, 6] = 0;
        datashopcaylaunam[1, 6] = 1;
        datashopcaylaunam[2, 6] = 15;

        datashopcaylaunam[0, 7] = 0;
        datashopcaylaunam[1, 7] = 1;
        datashopcaylaunam[2, 7] = 17;
    }
}
