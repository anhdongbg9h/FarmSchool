using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SanXuatSP : MonoBehaviour, IInteractable
{
    public static SanXuatSP instance;
    [SerializeField] public int id;
    [SerializeField] public GameObject spri;
    private Animator animatoractive;
    private GameObject canvas;

    public GameObject icon_thuhoach;
    public GameObject icon_thuhoachkinhnghiem;
    [SerializeField] public int time;

    public int[,] mang;

    [HideInInspector] public int sl_bongbong;//xét số lượng bong bóng cần hiện
    int Maxdem;

    [HideInInspector] public int dem; // xét vị trí mảng
    [HideInInspector] public int danhdau; // đánh dấu số thứ tự của sprite sản phẩm trong gameobject nhà máy

    int t1, t2;//t1 dùng để gán thời gian giảm được, t2 là thời gian cố định
    private void Awake()
    {
        instance = this;
        mang = new int[6, 3];
    }
    private void Start()
    {
        animatoractive = GetComponent<Animator>();
        animatoractive.enabled = false;
        sl_bongbong = 0;
        dem = 0;
        danhdau = 1;
    }
    private void OnMouseDown()
    {
        GameManager.instance.dayCanvas_rangoai();
        GameManager.instance.nmSX = gameObject;
        Maxdem = 0;
        for (int i = 1; i < transform.childCount; i++)
        {
            //Debug.Log(transform.childCount);
            if (transform.GetChild(i).gameObject.activeSelf == true)
            {
                Maxdem++;
                if (Maxdem > sl_bongbong)
                {
                    sl_bongbong = Maxdem;
                }
            }
        }

        if (spri.activeSelf == true)
        {
            StartCoroutine(update_newTime());
        }

        if (dem < sl_bongbong && danhdau < sl_bongbong)
        {
            GetComponent<CircleCollider2D>().isTrigger = true;
        }
        //check số sp sinh ra
        int demSP = 0;
        for (int i = 1; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<SpriteRenderer>().sprite != null)
            {
                demSP++;
            }
        }
        //thu hoạch sản phẩm được sinh ra cuối cùng
        if (demSP <= 6 && demSP > 0)
        {
            if (demSP < 6)
            {
                if (transform.GetChild(demSP + 1).GetComponent<SpriteRenderer>().sprite == null)
                {
                    transform.GetChild(demSP).GetComponent<SpriteRenderer>().sprite = null;
                    GameObject ob = Instantiate(icon_thuhoach, transform.position, Quaternion.identity);
                    GameObject ob1 = Instantiate(icon_thuhoachkinhnghiem, transform.position, Quaternion.identity);
                    ob.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite
                        = GameManager.instance.dataSPCheBien.data[transform.GetChild(demSP).GetComponent<ThucAnCheBien_Scripts>().id].iconsanpham;
                    GameManager.instance.dataSPCheBien.data[transform.GetChild(demSP).GetComponent<ThucAnCheBien_Scripts>().id].sanluong++;
                    GameManager.instance.datanhachinh.data[GameManager.instance.dataui.data[2].giatri - 1].KinhNghiem +=
                        GameManager.instance.dataSPCheBien.data[transform.GetChild(demSP).GetComponent<ThucAnCheBien_Scripts>().id].exp;
                    demSP = 0;
                    if (danhdau > 1)
                    {
                        danhdau--;
                    }
                }
            }
            else if (demSP == 6)
            {
                transform.GetChild(demSP).GetComponent<SpriteRenderer>().sprite = null;
                GameObject ob = Instantiate(icon_thuhoach, transform.position, Quaternion.identity);
                GameObject ob1 = Instantiate(icon_thuhoachkinhnghiem, transform.position, Quaternion.identity);
                ob.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite
                    = GameManager.instance.dataSPCheBien.data[transform.GetChild(danhdau).GetComponent<ThucAnCheBien_Scripts>().id].iconsanpham;
                GameManager.instance.dataSPCheBien.data[transform.GetChild(danhdau).GetComponent<ThucAnCheBien_Scripts>().id].sanluong++;
                GameManager.instance.datanhachinh.data[GameManager.instance.dataui.data[2].giatri - 1].KinhNghiem +=
                        GameManager.instance.dataSPCheBien.data[transform.GetChild(danhdau).GetComponent<ThucAnCheBien_Scripts>().id].exp;
                demSP = 0;
                if (danhdau > 1)
                {
                    danhdau--;
                }
            }
        }

        //ShowCanvasUIMayCheBienThucAn();

        switch (id)
        {
            case 1:
                canvas = GameManager.instance.CanvasSXthuanconvat;
                ShowCanvas_NhaMay(1);
                break;
            case 2:
                canvas = GameManager.instance.canvas_bo_phomai;
                ShowCanvas_NhaMay(2);
                break;
            case 3:
                canvas = GameManager.instance.canvas_nhamayhoaqua;
                ShowCanvas_NhaMay(3);
                break;
            case 4:
                canvas = GameManager.instance.canvas_lonuongbanh_pizza;
                ShowCanvas_NhaMay(4);
                break;
            case 5:
                canvas = GameManager.instance.canvas_lonuong_thit;
                ShowCanvas_NhaMay(5);
                break;
            case 6:
                canvas = GameManager.instance.canvas_nhamat_ong;
                ShowCanvas_NhaMay(6);
                break;
            case 7:
                canvas = GameManager.instance.canvas_nhamay_duong;
                ShowCanvas_NhaMay(7);
                break;
            case 8:
                canvas = GameManager.instance.canvas_nhamay_bot;
                ShowCanvas_NhaMay(8);
                break;
            case 9:
                canvas = GameManager.instance.canvas_nhamay_quang;
                ShowCanvas_NhaMay(9);
                break;
            case 10:
                canvas = GameManager.instance.canvas_nhamay_suahop;
                ShowCanvas_NhaMay(10);
                break;
            case 11:
                canvas = GameManager.instance.canvas_nhamay_sxruou;
                ShowCanvas_NhaMay(11);
                break;
            default:
                break;
        }

        //show time
        if (spri.activeSelf == true)
        {
            canvas.transform.GetChild(0).GetComponent<hienthoigian>().StopTime();
            StartCoroutine(update_newSanPham(t1));
            canvas.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (spri.activeSelf == false)
        {
            canvas.transform.GetChild(0).gameObject.SetActive(false);
        }

    }

    IEnumerator update_newTime()
    {
        t1 = mang[0, 1];
        t2 = mang[0, 2];
        yield return new WaitForSeconds(1f);
        if (t1 > 0)
        {
            StartCoroutine(update_newTime());
        }
    }

    IEnumerator update_newSanPham(int time)
    {
        canvas.transform.GetChild(0).GetComponent<hienthoigian>().StopTime();

        StartCoroutine(canvas.transform.GetChild(0).GetComponent<hienthoigian>().updatetime(t1, t2));
        yield return new WaitForSeconds(t1 + 1);

        for (int i = 0; i <= dem; i++)
        {
            if (i < dem)
            {
                canvas.transform.GetChild(2).GetChild(i).GetChild(0).GetComponent<Image>().sprite
                    = GameManager.instance.dataSPCheBien.data[mang[i, 0]].iconsanpham;
                canvas.transform.GetChild(2).GetChild(i).GetChild(0).GetComponent<Image>().color
                    = new Color(255, 255, 255, 255);
            }
            if (i == dem)
            {
                canvas.transform.GetChild(2).GetChild(i).GetChild(0).GetComponent<Image>().sprite
                    = null;
                canvas.transform.GetChild(2).GetChild(i).GetChild(0).GetComponent<Image>().color
                    = new Color(255, 255, 255, 0);
            }
            if (dem == 0)
            {
                canvas.transform.GetChild(2).GetChild(dem).GetChild(0).GetComponent<Image>().sprite
                    = null;
                canvas.transform.GetChild(2).GetChild(dem).GetChild(0).GetComponent<Image>().color
                    = new Color(255, 255, 255, 0);
            }
        }


        if (t1 > 0)
        {
            StartCoroutine(update_newSanPham(t1));
        }
    }

    public void Update_Sp_NhaMay()
    {
        Maxdem = 0;
        for (int i = 1; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf == true)
            {
                Maxdem++;
                if (Maxdem > sl_bongbong)
                {
                    sl_bongbong = Maxdem;
                }
            }
        }
        
        if (dem < sl_bongbong && danhdau < sl_bongbong)
        {
            GetComponent<CircleCollider2D>().isTrigger = true;
        }
    }

    public void ShowCanvas_NhaMay(int id)
    {
        // show so luong bong bong
        {
            for (int i = 0; i <= sl_bongbong; i++)
            {
                if (i < sl_bongbong)
                {
                    canvas.transform.GetChild(2).GetChild(i).gameObject.SetActive(true);
                    canvas.transform.GetChild(2).GetChild(i).GetChild(0).GetComponent<Image>().sprite
                        = null;
                    canvas.transform.GetChild(2).GetChild(i).GetChild(0).GetComponent<Image>().color
                        = new Color(255, 255, 255, 0);
                }
                else if (i == sl_bongbong)
                {
                    if (sl_bongbong < 6)
                    {
                        canvas.transform.GetChild(2).GetChild(i).gameObject.SetActive(true);
                        canvas.transform.GetChild(2).GetChild(i).GetChild(0).GetComponent<Image>().sprite
                            = GameManager.instance.dataicon.data[0].icon;
                        canvas.transform.GetChild(2).GetChild(i).GetChild(0).GetComponent<Image>().color
                            = new Color(255, 255, 255, 255);
                    }
                }
            }

            for (int i = sl_bongbong + 1; i < canvas.transform.GetChild(2).childCount; i++)
            {
                canvas.transform.GetChild(2).GetChild(i).gameObject.SetActive(false);
            }

        }

        //hiển thị hình ảnh thức ăn chế biến trong bong bóng
        {
            for (int i = 0; i < dem; i++)
            {
                canvas.transform.GetChild(2).GetChild(i).GetChild(0).GetComponent<Image>().sprite 
                    = GameManager.instance.dataSPCheBien.data[mang[i, 0]].iconsanpham;
                canvas.transform.GetChild(2).GetChild(i).GetChild(0).GetComponent<Image>().color
                    = new Color(255, 255, 255, 255);
            }

        }

        // xử lý cấp mở cho sản phẩm chế biến
        {
            // xử lý cấp mở cho sản xuất thức ăn
            if (id==1)
            {
                if (GameManager.instance.dataui.data[2].giatri > 0 && GameManager.instance.dataui.data[2].giatri < 5)
                {
                    canvas.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(true);
                }
                else if (GameManager.instance.dataui.data[2].giatri >= 5 && GameManager.instance.dataui.data[2].giatri < 7)
                {
                    canvas.transform.GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(true);
                }
                else if (GameManager.instance.dataui.data[2].giatri >= 7 && GameManager.instance.dataui.data[2].giatri < 10)
                {
                    canvas.transform.GetChild(1).GetChild(2).GetChild(0).gameObject.SetActive(true);
                }
                else if (GameManager.instance.dataui.data[2].giatri >= 10 && GameManager.instance.dataui.data[2].giatri < 15)
                {
                    canvas.transform.GetChild(1).GetChild(3).GetChild(0).gameObject.SetActive(true);
                }
                else if (GameManager.instance.dataui.data[2].giatri >= 15 && GameManager.instance.dataui.data[2].giatri < 17)
                {
                    canvas.transform.GetChild(1).GetChild(4).GetChild(0).gameObject.SetActive(true);
                }
                else if (GameManager.instance.dataui.data[2].giatri >= 17)
                {
                    canvas.transform.GetChild(1).GetChild(5).GetChild(0).gameObject.SetActive(true);
                }
            }
            // xử lý cấp mở cho nhà máy bò phomai
            else if (id==2)
            {
                if (GameManager.instance.dataui.data[2].giatri >= 5 && GameManager.instance.dataui.data[2].giatri < 10)
                {
                    canvas.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(true);
                    canvas.transform.GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(true);
                }
                else if (GameManager.instance.dataui.data[2].giatri >= 10 && GameManager.instance.dataui.data[2].giatri < 12)
                {
                    canvas.transform.GetChild(1).GetChild(2).GetChild(0).gameObject.SetActive(true);
                }
                else if (GameManager.instance.dataui.data[2].giatri >= 12 && GameManager.instance.dataui.data[2].giatri < 15)
                {
                    canvas.transform.GetChild(1).GetChild(3).GetChild(0).gameObject.SetActive(true);
                }
                else if (GameManager.instance.dataui.data[2].giatri >= 15)
                {
                    canvas.transform.GetChild(1).GetChild(4).GetChild(0).gameObject.SetActive(true);
                }
            }
            // xử lý cấp mở cho các sản phẩm nhà máy hoa quả
            else if (id == 3)
            {
                if (GameManager.instance.dataui.data[2].giatri >=10 && GameManager.instance.dataui.data[2].giatri < 13)
                {
                    canvas.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(true);
                }
                else if (GameManager.instance.dataui.data[2].giatri >= 13 && GameManager.instance.dataui.data[2].giatri < 15)
                {
                    canvas.transform.GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(true);
                }
                else if (GameManager.instance.dataui.data[2].giatri >= 15 && GameManager.instance.dataui.data[2].giatri < 17)
                {
                    canvas.transform.GetChild(1).GetChild(2).GetChild(0).gameObject.SetActive(true);
                }
                else if (GameManager.instance.dataui.data[2].giatri >= 17 && GameManager.instance.dataui.data[2].giatri < 20)
                {
                    canvas.transform.GetChild(1).GetChild(3).GetChild(0).gameObject.SetActive(true);
                }
                else if (GameManager.instance.dataui.data[2].giatri >= 20 && GameManager.instance.dataui.data[2].giatri < 23)
                {
                    canvas.transform.GetChild(1).GetChild(4).GetChild(0).gameObject.SetActive(true);
                }
                else if (GameManager.instance.dataui.data[2].giatri >= 23)
                {
                    canvas.transform.GetChild(1).GetChild(5).GetChild(0).gameObject.SetActive(true);
                }
            }
            // xử lý cấp mở cho các sản phẩm lò bánh pizza
            else if (id == 4)
            {

            }
            // xử lý cấp mở cho các sản phẩm lò nướng thịt
            else if (id == 5)
            {
                if (GameManager.instance.dataui.data[2].giatri >=7 && GameManager.instance.dataui.data[2].giatri < 10)
                {
                    canvas.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(true);
                    canvas.transform.GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(true);
                    canvas.transform.GetChild(1).GetChild(2).GetChild(0).gameObject.SetActive(true);
                    canvas.transform.GetChild(1).GetChild(3).GetChild(0).gameObject.SetActive(true);
                }
                else if (GameManager.instance.dataui.data[2].giatri >= 10)
                {
                    canvas.transform.GetChild(1).GetChild(4).GetChild(0).gameObject.SetActive(true);
                }
            }
            // xử lý cấp mở cho các sản phẩm nhà máy mật ong
            else if (id == 6)
            {

            }
            // xử lý cấp mở cho các sản phẩm nhà máy đường
            else if (id == 7)
            {
                if (GameManager.instance.dataui.data[2].giatri >=6 && GameManager.instance.dataui.data[2].giatri < 9)
                {
                    canvas.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(true);
                    canvas.transform.GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(true);
                }
                else if (GameManager.instance.dataui.data[2].giatri >= 9 && GameManager.instance.dataui.data[2].giatri < 11)
                {
                    canvas.transform.GetChild(1).GetChild(2).GetChild(0).gameObject.SetActive(true);
                    canvas.transform.GetChild(1).GetChild(3).GetChild(0).gameObject.SetActive(true);
                }
                else if (GameManager.instance.dataui.data[2].giatri >= 11)
                {
                    canvas.transform.GetChild(1).GetChild(4).GetChild(0).gameObject.SetActive(true);
                }
            }
            // xử lý cấp mở cho các sản phẩm nhà máy bọt
            else if (id == 8)
            {
                if (GameManager.instance.dataui.data[2].giatri >= 5 && GameManager.instance.dataui.data[2].giatri < 7)
                {
                    canvas.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(true);
                    canvas.transform.GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(true);
                    canvas.transform.GetChild(1).GetChild(2).GetChild(0).gameObject.SetActive(true);
                }
                else if (GameManager.instance.dataui.data[2].giatri >= 7 && GameManager.instance.dataui.data[2].giatri < 10)
                {
                    canvas.transform.GetChild(1).GetChild(3).GetChild(0).gameObject.SetActive(true);
                }
                else if (GameManager.instance.dataui.data[2].giatri >= 10)
                {
                    canvas.transform.GetChild(1).GetChild(4).GetChild(0).gameObject.SetActive(true);
                }
            }
            // xử lý cấp mở cho các sản phẩm nhà máy quạng
            else if (id == 9)
            {
                if (GameManager.instance.dataui.data[2].giatri >=15 && GameManager.instance.dataui.data[2].giatri < 17)
                {
                    canvas.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(true);
                    canvas.transform.GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(true);
                }
                else if (GameManager.instance.dataui.data[2].giatri >= 17 && GameManager.instance.dataui.data[2].giatri < 20)
                {
                    canvas.transform.GetChild(1).GetChild(2).GetChild(0).gameObject.SetActive(true);
                }
                else if (GameManager.instance.dataui.data[2].giatri >= 20 && GameManager.instance.dataui.data[2].giatri < 22)
                {
                    canvas.transform.GetChild(1).GetChild(3).GetChild(0).gameObject.SetActive(true);
                }
                else if (GameManager.instance.dataui.data[2].giatri >= 22)
                {
                    canvas.transform.GetChild(1).GetChild(4).GetChild(0).gameObject.SetActive(true);
                }
            }
            // xử lý cấp mở cho các sản phẩm nhà máy sữa hộp
            else if (id == 10)
            {
                if (GameManager.instance.dataui.data[2].giatri >= 10 && GameManager.instance.dataui.data[2].giatri < 13)
                {
                    canvas.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(true);
                    canvas.transform.GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(true);
                }
                else if (GameManager.instance.dataui.data[2].giatri >= 13 && GameManager.instance.dataui.data[2].giatri < 15)
                {
                    canvas.transform.GetChild(1).GetChild(2).GetChild(0).gameObject.SetActive(true);
                }
                else if (GameManager.instance.dataui.data[2].giatri >= 15)
                {
                    canvas.transform.GetChild(1).GetChild(3).GetChild(0).gameObject.SetActive(true);
                    canvas.transform.GetChild(1).GetChild(4).GetChild(0).gameObject.SetActive(true);
                }
            }

            // xử lý cấp mở cho các sản phẩm nhà máy rượu
            else if (id == 11)
            {
                if (GameManager.instance.dataui.data[2].giatri >=15 && GameManager.instance.dataui.data[2].giatri < 17)
                {
                    canvas.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(true);
                }
                else if (GameManager.instance.dataui.data[2].giatri >= 17 && GameManager.instance.dataui.data[2].giatri < 20)
                {
                    canvas.transform.GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(true);
                }
                else if (GameManager.instance.dataui.data[2].giatri >= 20 && GameManager.instance.dataui.data[2].giatri < 23)
                {
                    canvas.transform.GetChild(1).GetChild(2).GetChild(0).gameObject.SetActive(true);
                }
                else if (GameManager.instance.dataui.data[2].giatri >= 23 && GameManager.instance.dataui.data[2].giatri < 25)
                {
                    canvas.transform.GetChild(1).GetChild(3).GetChild(0).gameObject.SetActive(true);
                }
                else if (GameManager.instance.dataui.data[2].giatri >= 25)
                {
                    canvas.transform.GetChild(1).GetChild(4).GetChild(0).gameObject.SetActive(true);
                }
            }

        }


        // show ra canvas
        {
            canvas.transform.position = transform.position + new Vector3(-0.6f, 0.5f, 0);
            canvas.GetComponent<Save_vitrinhamay>().vitrinhamay = transform.position;
        }


    }

    public void ShowSeedUI()
    {

    }


    public void Chebien()
    {
        if (animatoractive.enabled == false)
        {
            animatoractive.enabled = true;
        }
        if (dem > sl_bongbong)
        {
            GetComponent<CircleCollider2D>().isTrigger = false;
        }
        if (dem <= sl_bongbong)
        {
            spri.SetActive(true);
            mang[dem - 1, 0] = ThucAnCheBien_Scripts.instance.id;
            mang[dem - 1, 1] = GameManager.instance.dataSPCheBien.data[ThucAnCheBien_Scripts.instance.id].time;
            mang[dem - 1, 2] = GameManager.instance.dataSPCheBien.data[ThucAnCheBien_Scripts.instance.id].time;
            time = time + mang[dem - 1, 1];

            if (dem == sl_bongbong)
            {
                GetComponent<CircleCollider2D>().isTrigger = false;
            }
            if (dem == 1)
            {
                StartCoroutine(PhatTrien(dem));
            }
        }
    }

    int slnl;
    public void NL_Giam(GameObject obj)
    {
        slnl = 0;
        for (int i = 0; i < obj.GetComponent<ThucAnCheBien_Scripts>().sl_thanhphan; i++)
        {
            if (GameManager.instance.dataNongSan.data[obj.GetComponent<ThucAnCheBien_Scripts>().mang[i]].sanluong > 0)
            {
                slnl++;
            }
        }
        if (slnl == obj.GetComponent<ThucAnCheBien_Scripts>().sl_thanhphan)
        {
            for (int j = 0; j < slnl; j++)
            {
                GameManager.instance.dataNongSan.data[obj.GetComponent<ThucAnCheBien_Scripts>().mang[j]].sanluong--;
            }
            dem++;
            Chebien();
        }
    }

    int check_iddata(int iddata, int idsp, int slnl)
    {
        if (iddata == 0)
        {
            if (GameManager.instance.dataNongSan.data[idsp].sanluong > 0)
            {
                slnl++;
            }
        }
        else if (iddata == 1)
        {
            if (GameManager.instance.dataVatNuoi.data[idsp].sl_sanpham > 0)
            {
                slnl++;
            }
        }
        else if (iddata == 2)
        {
            if (GameManager.instance.dataCayLauNam.data[idsp].sanluong > 0)
            {
                slnl++;
            }
        }
        else if (iddata == 3)
        {
            if (GameManager.instance.dataSPCheBien.data[idsp].sanluong > 0)
            {
                slnl++;
            }
        }

        return slnl;
    }

    void Giam_SL_NL(int iddata, int idsp)
    {
        if (iddata == 0)
        {
            GameManager.instance.dataNongSan.data[idsp].sanluong--;
        }
        else if (iddata == 1)
        {
            GameManager.instance.dataVatNuoi.data[idsp].sl_sanpham--;
        }
        else if (iddata == 2)
        {
            GameManager.instance.dataCayLauNam.data[idsp].sanluong--;
        }
        else if (iddata == 3)
        {
            GameManager.instance.dataSPCheBien.data[idsp].sanluong--;
        }
    }
    public void NL_Giam_2mang(GameObject obj)
    {
        slnl = 0;
        for (int i = 0; i < obj.GetComponent<ThucAnCheBien_Scripts>().sl_thanhphan; i++)
        {
            slnl = check_iddata(obj.GetComponent<ThucAnCheBien_Scripts>().mang_LT[i], obj.GetComponent<ThucAnCheBien_Scripts>().mang[i], slnl);
        }

        if (slnl == obj.GetComponent<ThucAnCheBien_Scripts>().sl_thanhphan)
        {
            for (int j = 0; j < slnl; j++)
            {
                Giam_SL_NL(obj.GetComponent<ThucAnCheBien_Scripts>().mang_LT[j], obj.GetComponent<ThucAnCheBien_Scripts>().mang[j]);
            }
            dem++;
            Chebien();
        }
        else
        {
            Debug.Log("không đủ nguyên liệu");
        }
    }
    public void Show_NguyenLieu_chebien(int id, GameObject obj)
    {
        if (id>=0||id<=5)
        {
            NL_Giam(obj);
        }
        else if (id >= 6 || id <= 57)
        {
            NL_Giam_2mang(obj);
        }
        {
            /*if(id == 0)
        {
            NL_Giam(obj);
        }
        else if(id == 1)
        {
            NL_Giam(obj);
        }
        else if (id == 2)
        {
            NL_Giam(obj);
        }
        else if (id == 3)
        {
            NL_Giam(obj);
        }
        else if (id == 4)
        {
            NL_Giam(obj);
        }
        else if (id == 5)
        {
            NL_Giam(obj);
        }
        else if (id == 6)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 7)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 8)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 9)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 10)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 11)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 12)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 13)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 14)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 15)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 16)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 17)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 18)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 19)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 20)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 21)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 22)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 23)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 24)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 25)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 26)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 27)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 28)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 29)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 30)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 31)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 32)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 33)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 34)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 35)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 36)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 37)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 38)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 39)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 40)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 41)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 42)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 43)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 44)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 45)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 46)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 47)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 48)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 49)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 50)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 51)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 52)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 53)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 54)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 55)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 56)
        {
            NL_Giam_2mang(obj);
        }
        else if (id == 57)
        {
            NL_Giam_2mang(obj);
        }*/
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (id)
        {
            case 1:
                if (collision.gameObject.CompareTag("CheBienTA"))
                {
                    if (gameObject.CompareTag("nhamaysxthuan"))
                    {
                        Show_NguyenLieu_chebien(collision.gameObject.GetComponent<ThucAnCheBien_Scripts>().id,collision.gameObject);
                    }
                }
                break;
            case 2:
                if (collision.gameObject.CompareTag("SP_bo_phomai"))
                {
                    if (gameObject.CompareTag("nhamaybo_phomai"))
                    {
                        Show_NguyenLieu_chebien(collision.gameObject.GetComponent<ThucAnCheBien_Scripts>().id, collision.gameObject);
                    }
                }
                break;
            case 3:
                if (collision.gameObject.CompareTag("ncephoaqua"))
                {
                    if (gameObject.CompareTag("nhamay_ephoaqua"))
                    {
                        Show_NguyenLieu_chebien(collision.gameObject.GetComponent<ThucAnCheBien_Scripts>().id,
                            collision.gameObject);
                    }
                }
                break;
            case 4:
                if (collision.gameObject.CompareTag("SP_lobanhpizza"))
                {
                    if (gameObject.CompareTag("lonuong_banhpizza"))
                    {
                        Show_NguyenLieu_chebien(collision.gameObject.GetComponent<ThucAnCheBien_Scripts>().id,
                            collision.gameObject);
                    }
                }
                break;
            case 5:
                if (collision.gameObject.CompareTag("SP_lonuong_thit"))
                {
                    if (gameObject.CompareTag("lonuong_thit"))
                    {
                        Show_NguyenLieu_chebien(collision.gameObject.GetComponent<ThucAnCheBien_Scripts>().id,
                            collision.gameObject);
                    }
                }
                break;
            case 6:
                if (collision.gameObject.CompareTag("SP_nhamay_matong"))
                {
                    if (gameObject.CompareTag("nhamay_matong"))
                    {
                        Show_NguyenLieu_chebien(collision.gameObject.GetComponent<ThucAnCheBien_Scripts>().id,
                            collision.gameObject);
                    }
                }
                break;
            case 7:
                if (collision.gameObject.CompareTag("SP_nhamay_duong"))
                {
                    if (gameObject.CompareTag("nhamay_duong"))
                    {
                        Show_NguyenLieu_chebien(collision.gameObject.GetComponent<ThucAnCheBien_Scripts>().id,
                            collision.gameObject);
                    }
                }
                break;
            case 8:
                if (collision.gameObject.CompareTag("SP_nhamay_bot"))
                {
                    if (gameObject.CompareTag("nhamay_bot"))
                    {
                        Show_NguyenLieu_chebien(collision.gameObject.GetComponent<ThucAnCheBien_Scripts>().id,
                            collision.gameObject);
                    }
                }
                break;
            case 9:
                if (collision.gameObject.CompareTag("SP_nhamay_quang"))
                {
                    if (gameObject.CompareTag("nhamay_quang"))
                    {
                        Show_NguyenLieu_chebien(collision.gameObject.GetComponent<ThucAnCheBien_Scripts>().id,
                            collision.gameObject);
                    }
                }
                break;
            case 10:
                if (collision.gameObject.CompareTag("SP_nhamay_suahop"))
                {
                    if (gameObject.CompareTag("nhamay_suahop"))
                    {
                        Show_NguyenLieu_chebien(collision.gameObject.GetComponent<ThucAnCheBien_Scripts>().id,
                            collision.gameObject);
                    }
                }
                break;
            case 11:
                if (collision.gameObject.CompareTag("SP_nhamay_sxruou"))
                {
                    if (gameObject.CompareTag("nhamay_sxruou"))
                    {
                        Show_NguyenLieu_chebien(collision.gameObject.GetComponent<ThucAnCheBien_Scripts>().id,
                            collision.gameObject);
                    }
                }
                break;
            default:
                break;
        }
    }

    //chạy thời gian chế biến thức ăn
    IEnumerator PhatTrien(int giatri)
    {
        yield return new WaitForSeconds(1f);
        mang[giatri - 1, 1]--;
        time--;
        if (mang[giatri - 1, 1] > 0)
        {
            StartCoroutine(PhatTrien(giatri));
        }
        else if (mang[giatri - 1, 1] == 0)
        {
            transform.GetChild(danhdau).GetComponent<SpriteRenderer>().sprite
                = GameManager.instance.dataSPCheBien.data[mang[giatri - 1, 0]].iconsanpham;
            transform.GetChild(danhdau).GetComponent<ThucAnCheBien_Scripts>().id = mang[giatri - 1, 0];

            danhdau++;

            for (int i = 1; i < dem; i++)
            {
                mang[i - 1, 0] = mang[i, 0];
                mang[i - 1, 1] = mang[i, 1];
                mang[i - 1, 2] = mang[i, 2];
            }

            if (danhdau >= sl_bongbong)
            {
                GetComponent<CircleCollider2D>().isTrigger = false;
                dem--;
            }
            else
            {
                dem--;
            }

            if (mang[0, 1] > 0)
            {
                StartCoroutine(PhatTrien(1));
            }
        }
        if (time == 0)
        {
            spri.SetActive(false);
            canvas.transform.GetChild(0).gameObject.SetActive(false);
            animatoractive.enabled = false;
        }
    }

    // Thu hoạch từ nhà máy sản xuất thức ăn
}
