using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SXthucanconvat : MonoBehaviour, IInteractable
{
    public static SXthucanconvat instance;
    [SerializeField] public GameObject spri;
    public GameObject icon_thuhoach;
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
        sl_bongbong = 0;
        dem = 0;
        danhdau = 1;
    }
    private void OnMouseDown()
    {
        GameManager.instance.nmSX = gameObject;
        Maxdem = 0;
        for(int i = 1; i < transform.childCount; i++)
        {
            //Debug.Log(transform.childCount);
            if(transform.GetChild(i).gameObject.activeSelf == true)
            {
                Maxdem++;
                if(Maxdem > sl_bongbong)
                {
                    sl_bongbong = Maxdem;
                }
            }
        }

        if(spri.activeSelf == true)
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
                    ob.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite
                        = GameManager.instance.dataVatNuoi.data[transform.GetChild(demSP).GetComponent<ThucAnCheBien_Scripts>().id].thuan;
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
                ob.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite
                    = GameManager.instance.dataVatNuoi.data[transform.GetChild(danhdau).GetComponent<ThucAnCheBien_Scripts>().id].thuan;
                demSP = 0;
                if (danhdau > 1)
                {
                    danhdau--;
                }
            }
        }

        ShowCanvasUIMayCheBienThucAn();

        //show time
        if (spri.activeSelf == true)
        {
            GameManager.instance.CanvasSXthuanconvat.transform.GetChild(0).GetComponent<hienthoigian>().StopTime();
            /*t1 = mang[0, 1];
            t2 = mang[0, 2];
            StartCoroutine(GameManager.instance.CanvasSXthuanconvat.transform.GetChild(0).GetComponent<hienthoigian>().updatetime(t1-1, t2));*/

            StartCoroutine(update_newSanPham(t1));
            GameManager.instance.CanvasSXthuanconvat.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if(spri.activeSelf == false)
        {
            GameManager.instance.CanvasSXthuanconvat.transform.GetChild(0).gameObject.SetActive(false);
        }

    }
    IEnumerator update_newTime()
    {
        t1 = mang[0, 1];
        t2 = mang[0, 2];
        yield return new WaitForSeconds(1f);
        if(t1 > 0)
        {
            StartCoroutine(update_newTime());
        }
    }
    IEnumerator update_newSanPham(int time)
    {
        GameManager.instance.CanvasSXthuanconvat.transform.GetChild(0).GetComponent<hienthoigian>().StopTime();
        
        StartCoroutine(GameManager.instance.CanvasSXthuanconvat.transform.GetChild(0).GetComponent<hienthoigian>().updatetime(t1, t2));
        yield return new WaitForSeconds(t1+1);

        for (int i = 0; i <= dem; i++)
        {
            if(i < dem)
            {
                GameManager.instance.CanvasSXthuanconvat.transform.GetChild(6).GetChild(i).GetChild(0).GetComponent<Image>().sprite
                    = GameManager.instance.dataVatNuoi.data[mang[i, 0]].thuan;
                GameManager.instance.CanvasSXthuanconvat.transform.GetChild(6).GetChild(i).GetChild(0).GetComponent<Image>().color
                    = new Color(255, 255, 255, 255);
            }
            if(i == dem)
            {
                GameManager.instance.CanvasSXthuanconvat.transform.GetChild(6).GetChild(i).GetChild(0).GetComponent<Image>().sprite
                    = null;
                GameManager.instance.CanvasSXthuanconvat.transform.GetChild(6).GetChild(i).GetChild(0).GetComponent<Image>().color
                    = new Color(255, 255, 255, 0);
            }
            if(dem == 0)
            {
                GameManager.instance.CanvasSXthuanconvat.transform.GetChild(6).GetChild(dem).GetChild(0).GetComponent<Image>().sprite
                    = null;
                GameManager.instance.CanvasSXthuanconvat.transform.GetChild(6).GetChild(dem).GetChild(0).GetComponent<Image>().color
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
    public void ShowCanvasUIMayCheBienThucAn()
    {
        //show số lượng bong bóng
        for(int i = 0; i <= sl_bongbong; i++)
        {
            if(i < sl_bongbong)
            {
                GameManager.instance.CanvasSXthuanconvat.transform.GetChild(6).GetChild(i).gameObject.SetActive(true);

                GameManager.instance.CanvasSXthuanconvat.transform.GetChild(6).GetChild(i).GetChild(0).GetComponent<Image>().sprite
                    = null;
                GameManager.instance.CanvasSXthuanconvat.transform.GetChild(6).GetChild(i).GetChild(0).GetComponent<Image>().color
                    = new Color(255, 255, 255, 0);
            }
            else if (i == sl_bongbong)
            {
                if(sl_bongbong < 6)
                {
                    GameManager.instance.CanvasSXthuanconvat.transform.GetChild(6).GetChild(i).gameObject.SetActive(true);
                    GameManager.instance.CanvasSXthuanconvat.transform.GetChild(6).GetChild(i).GetChild(0).GetComponent<Image>().sprite
                        = GameManager.instance.dataicon.data[0].icon;
                    GameManager.instance.CanvasSXthuanconvat.transform.GetChild(6).GetChild(i).GetChild(0).GetComponent<Image>().color
                        = new Color(255, 255, 255, 255);
                }
            }
        }

        for(int i = sl_bongbong + 1; i < GameManager.instance.CanvasSXthuanconvat.transform.GetChild(6).childCount; i++)
        {
            GameManager.instance.CanvasSXthuanconvat.transform.GetChild(6).GetChild(i).gameObject.SetActive(false);
        }


        //hiển thị hình ảnh thức ăn chế biến trong bong bóng
        for(int i = 0; i < dem; i++)
        {
            GameManager.instance.CanvasSXthuanconvat.transform.GetChild(6).GetChild(i).GetChild(0).GetComponent<Image>().sprite
                    = GameManager.instance.dataVatNuoi.data[mang[i, 0]].thuan;
            GameManager.instance.CanvasSXthuanconvat.transform.GetChild(6).GetChild(i).GetChild(0).GetComponent<Image>().color
                = new Color(255, 255, 255, 255);
        }

        //show canvas UI máy sản xuất thức ăn con vật
        GameManager.instance.CanvasSXthuanconvat.transform.position =
          transform.position + new Vector3(-0.4f, 0.4f, 0);
    }
    public void ShowSeedUI()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CheBienTA")){

            dem++;
            if(dem > sl_bongbong)
            {
                GetComponent<CircleCollider2D>().isTrigger = false;
            }
            if(dem <= sl_bongbong)
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

                if(dem == 1)
                {
                    StartCoroutine(PhatTrien(dem));
                }
            }
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
        else if(mang[giatri - 1, 1] == 0)
        {
            transform.GetChild(danhdau).GetComponent<SpriteRenderer>().sprite
                = GameManager.instance.dataVatNuoi.data[mang[giatri - 1, 0]].thuan;
            transform.GetChild(danhdau).GetComponent<ThucAnCheBien_Scripts>().id = mang[giatri - 1, 0];

            danhdau++;

            for(int i = 1; i < dem; i++)
            {
                mang[i - 1, 0] = mang[i, 0];
                mang[i - 1, 1] = mang[i, 1];
                mang[i - 1, 2] = mang[i, 2];
            }

            if(danhdau >= sl_bongbong)
            {
                GetComponent<CircleCollider2D>().isTrigger = false;
                dem--;
            }
            else
            {
                dem--;
            }

            if(mang[0,1] > 0)
            {
                StartCoroutine(PhatTrien(1));
            }
        }
        if (time == 0)
        {
            spri.SetActive(false);
            GameManager.instance.CanvasSXthuanconvat.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
