using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BitBenderGames;

public class nha_kho : MonoBehaviour
{
    public static nha_kho instance;
    [SerializeField] private GameObject nhakho;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject chua_sp;

    [HideInInspector] public int lv_nhakho = 1;
    [HideInInspector] public int suc_chua = 50;
    private int sl;

    [HideInInspector] public int dem;     // đếm số hạt giống đã được mở
    [HideInInspector] public int dem_spchebien;     // đếm số hạt giống đã được mở
    [HideInInspector] public int[] mang;// lưu vị trí của các hạt đã được mở
    [HideInInspector] public int coso;
    [HideInInspector] public int giaban;

    public GameObject doituong_dexacdinh_layer;
    public GameObject doituong_cha;
    public float kc;


    private void Start()
    {
        instance = this;
        mang = new int[80];
        kc = Mathf.Abs(doituong_cha.transform.position.y - doituong_dexacdinh_layer.transform.position.y)*10;
        doituong_cha.transform.GetComponent<SpriteRenderer>().sortingOrder = (int)kc;
    }

    private void OnMouseDown()
    {
        //TouchInputController.instance.isDragging = true; // khoa camera
        /*if (TouchInputController.instance.isDragging)
        {
            Debug.Log("true");
        }
        else
        {
            Debug.Log("false");
        }*/
        sl = 0;
        dem = 0;
        dem_spchebien = 0;
        nhakho.SetActive(true);
        chua_sp.SetActive(true);
        canvas.SetActive(false);

        Update_nhakho();
    }

    public void Update_nhakho()
    {
        for (int i = 0; i < get_nhakho.instance.transform.GetChild(0).GetChild(0).childCount; i++)
        {
            get_nhakho.instance.transform.GetChild(0).GetChild(0).GetChild(i).gameObject.SetActive(false);
        }
        // số lượng hạt cây nông nghiệp có thể sử dụng
        for (int i = 0; i < GameManager.instance.dataSPCheBien.data.Length; i++)
        {
            if (GameManager.instance.dataSPCheBien.data[i].capmo <= GameManager.instance.dataui.data[2].giatri
                && GameManager.instance.dataSPCheBien.data[i].capmo != 0)
            {
                mang[dem] = i;
                sl += GameManager.instance.dataSPCheBien.data[i].sanluong;
                dem++;
                dem_spchebien++;
            }
        }

        for (int i = 0; i < GameManager.instance.dataVatNuoi.data.Length; i++)
        {
            if (GameManager.instance.dataVatNuoi.data[i].capmo <= GameManager.instance.dataui.data[2].giatri
                && GameManager.instance.dataVatNuoi.data[i].capmo != 0)
            {
                mang[dem] = i;
                sl += GameManager.instance.dataVatNuoi.data[i].sl_sanpham;
                dem++;
            }
        }

        // active ô chứa hạt giống và show lên thông tin về những hạt giống trong kho
        for (int i = 0; i < dem; i++)
        {
            if (i < dem_spchebien)
            {
                get_nhakho.instance.transform.GetChild(0).GetChild(0).GetChild(i).gameObject.SetActive(true);
                get_nhakho.instance.transform.GetChild(0).GetChild(0).GetChild(i).GetChild(1).GetComponent<Image>().sprite =
                    GameManager.instance.dataSPCheBien.data[mang[i]].iconsanpham;
                get_nhakho.instance.transform.GetChild(0).GetChild(0).GetChild(i).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataSPCheBien.data[mang[i]].sanluong.ToString();
            }
            else
            {
                get_nhakho.instance.transform.GetChild(0).GetChild(0).GetChild(i).gameObject.SetActive(true);
                get_nhakho.instance.transform.GetChild(0).GetChild(0).GetChild(i).GetChild(1).GetComponent<Image>().sprite = GameManager.instance.dataVatNuoi.data[mang[i]].iconsanpham;
                get_nhakho.instance.transform.GetChild(0).GetChild(0).GetChild(i).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = GameManager.instance.dataVatNuoi.data[mang[i]].sl_sanpham.ToString();
            }
            
        }

        get_nhakho.instance.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text =
            sl.ToString() + "/" + suc_chua.ToString();
    }
    public void update_canvas_thongtin_hat(int id)
    {
        if (id < dem_spchebien)
        {
            get_nhakho.instance.transform.GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
            GameManager.instance.dataSPCheBien.data[mang[id]].nameVNI;
            get_nhakho.instance.transform.GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                GameManager.instance.dataSPCheBien.data[mang[id]].nguongoc;
            get_nhakho.instance.transform.GetChild(4).GetChild(2).GetComponent<Image>().sprite =
                GameManager.instance.dataSPCheBien.data[mang[id]].iconsanpham;
            if (get_nhakho.instance.transform.GetChild(0).GetChild(0).GetChild(id).GetComponent<chua_sp_nhakho>().coso == 0)
            {
                get_nhakho.instance.transform.GetChild(4).GetChild(9).GetComponent<TextMeshProUGUI>().text = 
                    get_nhakho.instance.transform.GetChild(0).GetChild(0).GetChild(id).GetComponent<chua_sp_nhakho>().coso.ToString();
                get_nhakho.instance.transform.GetChild(4).GetChild(6).GetComponent<TextMeshProUGUI>().text =
                    (get_nhakho.instance.transform.GetChild(0).GetChild(0).GetChild(id).GetComponent<chua_sp_nhakho>().coso 
                    * get_nhakho.instance.transform.GetChild(0).GetChild(0).GetChild(id).GetComponent<chua_sp_nhakho>().giaban).ToString();
            }
            else
            {
                get_nhakho.instance.transform.GetChild(4).GetChild(9).GetComponent<TextMeshProUGUI>().text = 
                    get_nhakho.instance.transform.GetChild(0).GetChild(0).GetChild(id).GetComponent<chua_sp_nhakho>().coso.ToString();
                get_nhakho.instance.transform.GetChild(4).GetChild(6).GetComponent<TextMeshProUGUI>().text = 
                    (get_nhakho.instance.transform.GetChild(0).GetChild(0).GetChild(id).GetComponent<chua_sp_nhakho>().giaban 
                    * get_nhakho.instance.transform.GetChild(0).GetChild(0).GetChild(id).GetComponent<chua_sp_nhakho>().coso).ToString();
            }
        }
        else
        {
            get_nhakho.instance.transform.GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
            GameManager.instance.dataVatNuoi.data[mang[id]].nameVNI;
            get_nhakho.instance.transform.GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                GameManager.instance.dataVatNuoi.data[mang[id]].nameVNI;
            get_nhakho.instance.transform.GetChild(4).GetChild(2).GetComponent<Image>().sprite =
                GameManager.instance.dataVatNuoi.data[mang[id]].iconsanpham;
            if (get_nhakho.instance.transform.GetChild(0).GetChild(0).GetChild(id).GetComponent<chua_sp_nhakho>().coso == 0)
            {
                get_nhakho.instance.transform.GetChild(4).GetChild(9).GetComponent<TextMeshProUGUI>().text = get_nhakho.instance.transform.GetChild(0).GetChild(0).GetChild(id).GetComponent<chua_sp_nhakho>().coso.ToString();
                get_nhakho.instance.transform.GetChild(4).GetChild(6).GetComponent<TextMeshProUGUI>().text = 
                    (get_nhakho.instance.transform.GetChild(0).GetChild(0).GetChild(id).GetComponent<chua_sp_nhakho>().coso 
                    * get_nhakho.instance.transform.GetChild(0).GetChild(0).GetChild(id).GetComponent<chua_sp_nhakho>().giaban).ToString();
            }
            else
            {
                get_nhakho.instance.transform.GetChild(4).GetChild(9).GetComponent<TextMeshProUGUI>().text = 
                    get_nhakho.instance.transform.GetChild(0).GetChild(0).GetChild(id).GetComponent<chua_sp_nhakho>().coso.ToString();
                get_nhakho.instance.transform.GetChild(4).GetChild(6).GetComponent<TextMeshProUGUI>().text = 
                    (get_nhakho.instance.transform.GetChild(0).GetChild(0).GetChild(id).GetComponent<chua_sp_nhakho>().giaban 
                    * get_nhakho.instance.transform.GetChild(0).GetChild(0).GetChild(id).GetComponent<chua_sp_nhakho>().coso).ToString();
            }
        }
    }
    public void Tinh_coso(int id_o_chua)
    {
        if (id_o_chua<dem_spchebien)
        {
            coso = GameManager.instance.dataSPCheBien.data[mang[id_o_chua]].sanluong / 2;
            giaban = GameManager.instance.dataSPCheBien.data[mang[id_o_chua]].giaban;
        }
        else
        {
            coso = GameManager.instance.dataVatNuoi.data[mang[id_o_chua]].sl_sanpham / 2;
            giaban = GameManager.instance.dataVatNuoi.data[mang[id_o_chua]].giaban;
        }
        update_canvas_thongtin_hat(id_o_chua);
    }


}
