using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Click_donhang : MonoBehaviour, IPointerDownHandler
{
    public static Click_donhang instance;
    private Animator animatoractive;
    public GameObject Panel_info_donhang;
    public GameObject Panel_order_donhang;
    public GameObject O_to_hang;
    public GameObject Order;


    public bool Check;
    public bool Sell;


    [SerializeField] public int Id_donhang;


    public int[,] mang;
    int random_data;
    int random_id_sp;
    int random_sl_1SP;

    int sl_thanhphan_don;
    [HideInInspector] public int kn;
    [HideInInspector] public int vang;
    [HideInInspector] public int t;
    int dem;

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        Check = false;
        Sell = false;
        kn = 0;
        vang = 0;
        dem = 0;
        animatoractive = GetComponent<Animator>();
        animatoractive.enabled = false;

        t = ranDom_sl_thanhphan_don();
        mang = new int[3, t];
        // tạo ra mảng chứa thông tin của đơn
        for (int j = 0; j < t; j++)
        {
            random_data = Random.Range(1, 4);
            mang[0, j] = random_data;


            random_sl_1SP = Random.Range(1, 6);
            mang[2, j] = random_sl_1SP;
            switch (random_data)
            {
                case 1:
                    do
                    {
                        random_id_sp = Random.Range(0, 26);
                    }
                    while (GameManager.instance.dataNongSan.data[random_id_sp].capmo > GameManager.instance.dataui.data[2].giatri);
                    //mang[1, j] = random_id_sp;
                    break;
                case 2:
                    do
                    {
                        random_id_sp = Random.Range(0, 60);
                    }
                    while (GameManager.instance.dataSPCheBien.data[random_id_sp].capmo > GameManager.instance.dataui.data[2].giatri);
                    //mang[1, j] = random_id_sp;
                    break;
                case 3:
                    do
                    {
                        random_id_sp = Random.Range(0, 6);
                    }
                    while (GameManager.instance.dataVatNuoi.data[random_id_sp].capmo > GameManager.instance.dataui.data[2].giatri);
                    //mang[1, j] = random_id_sp;
                    break;
            }
            mang[1, j] = random_id_sp;
        }

        // tính kinh nghiệm và vàng cho từng đơn hàng
        for (int a = 0; a < t; a++)
        {
            if (mang[0, a] == 1)
            {
                kn += ((GameManager.instance.dataNongSan.data[mang[1, a]].exp + 1) * mang[2, a]);
                vang += ((GameManager.instance.dataNongSan.data[mang[1, a]].giaban + 1) * mang[2, a]);
            }
            else if (mang[0, a] == 2)
            {
                kn += ((GameManager.instance.dataSPCheBien.data[mang[1, a]].exp + 1) * mang[2, a]);
                vang += ((GameManager.instance.dataSPCheBien.data[mang[1, a]].giaban + 1) * mang[2, a]);
            }
            else if (mang[0, a] == 3)
            {
                kn += ((GameManager.instance.dataVatNuoi.data[mang[1, a]].exp + 1) * mang[2, a]);
                vang += ((GameManager.instance.dataVatNuoi.data[mang[1, a]].giaban + 1) * mang[2, a]);
            }
        }
        gameObject.transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = kn.ToString();
        gameObject.transform.GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>().text = vang.ToString();

        // check số lượng của các đơn xem thỏa mãn hay không. nếu t/m thì bật dấu tích
        for(int i = 0; i < t; i++)
        {
            if(mang[0, i] == 1)
            {
                if (GameManager.instance.dataNongSan.data[mang[1, i]].sanluong >= mang[2, i])
                {
                    dem++;
                }
            }
            else if (mang[0, i] == 2)
            {
                if (GameManager.instance.dataSPCheBien.data[mang[1, i]].sanluong >= mang[2, i])
                {
                    dem++;
                }
            }
            else if (mang[0, i] == 3)
            {
                if (GameManager.instance.dataVatNuoi.data[mang[1, i]].sl_sanpham >= mang[2, i])
                {
                    dem++;
                }
            }
        }
        if (dem==t)
        {
            gameObject.transform.GetChild(4).gameObject.SetActive(true);
            
            Sell = true;
            Order.transform.GetChild(0).GetChild(0).GetChild(Id_donhang).GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
            Order.transform.GetChild(0).GetChild(0).GetChild(Id_donhang).GetChild(1).gameObject.SetActive(false);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        show_thongtin_don();
    }
    public void show_thongtin_don()
    {
        Check = true;
        Panel_info_donhang.transform.GetChild(6).GetComponent<Btn_xoa_order>().Id = Id_donhang;
        O_to_hang.transform.GetComponent<O_to_move>().Id = Id_donhang;
        for (int i = 0; i < 6; i++)
        {
            Panel_order_donhang.transform.GetChild(i + 2).GetChild(0).gameObject.SetActive(true);
        }

        gameObject.transform.GetChild(0).gameObject.SetActive(false);

        for (int i = 0; i < 3; i++)
        {
            if (Panel_info_donhang.transform.GetChild(i + 3).gameObject.activeSelf == true)
            {
                Panel_info_donhang.transform.GetChild(i + 3).gameObject.SetActive(false);
            }
        }
        animatoractive.enabled = true;
        StartCoroutine(Wait_time());

        Panel_info_donhang.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = kn.ToString();
        Panel_info_donhang.transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = vang.ToString();

        for (int i = 0; i < t; i++)
        {
            Panel_info_donhang.transform.GetChild(i + 3).gameObject.SetActive(true);
            if (mang[0, i] == 1)
            {
                Panel_info_donhang.transform.GetChild(i + 3).GetComponent<Image>().sprite =
                    GameManager.instance.dataNongSan.data[mang[1, i]].iconsanpham;
                Panel_info_donhang.transform.GetChild(i + 3).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                    mang[2, i].ToString();
                Panel_info_donhang.transform.GetChild(i + 3).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataNongSan.data[mang[1, i]].sanluong.ToString();
            }
            else if (mang[0, i] == 2)
            {
                Panel_info_donhang.transform.GetChild(i + 3).GetComponent<Image>().sprite =
                    GameManager.instance.dataSPCheBien.data[mang[1, i]].iconsanpham;
                Panel_info_donhang.transform.GetChild(i + 3).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                    mang[2, i].ToString();
                Panel_info_donhang.transform.GetChild(i + 3).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataSPCheBien.data[mang[1, i]].sanluong.ToString();
            }
            else if (mang[0, i] == 3)
            {
                Panel_info_donhang.transform.GetChild(i + 3).GetComponent<Image>().sprite =
                    GameManager.instance.dataVatNuoi.data[mang[1, i]].iconsanpham;
                Panel_info_donhang.transform.GetChild(i + 3).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                    mang[2, i].ToString();
                Panel_info_donhang.transform.GetChild(i + 3).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataVatNuoi.data[mang[1, i]].sl_sanpham.ToString();
            }
        }
    }

    IEnumerator Wait_time()
    {
        yield return new WaitForSeconds(1f);
        animatoractive.enabled = false;
    }

    // hàm random thành phần của mỗi đơn
    public int ranDom_sl_thanhphan_don()
    {
        sl_thanhphan_don = Random.Range(1, 4);
        return sl_thanhphan_don;
    }

    public void Update_SL_in_kho(int t)
    {
        for (int i = 0; i < t; i++)
        {
            if (mang[0, i] == 1)
            {
                if (GameManager.instance.dataNongSan.data[mang[1, i]].sanluong >= mang[2, i])
                {
                    GameManager.instance.dataNongSan.data[mang[1, i]].sanluong -= mang[2, i];
                }
            }
            else if (mang[0, i] == 2)
            {
                if (GameManager.instance.dataSPCheBien.data[mang[1, i]].sanluong >= mang[2, i])
                {
                    GameManager.instance.dataSPCheBien.data[mang[1, i]].sanluong -= mang[2, i];
                }
            }
            else if (mang[0, i] == 3)
            {
                if (GameManager.instance.dataVatNuoi.data[mang[1, i]].sl_sanpham >= mang[2, i])
                {
                    GameManager.instance.dataVatNuoi.data[mang[1, i]].sl_sanpham -= mang[2, i];
                }
            }
        }
    }
}
