using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SXbo_phomai : MonoBehaviour, IInteractable
{
    public int id; 
    
    private Animator animatoractive;
    public static SXbo_phomai instance;

    private int maxDem;
    private int sl_bongbong;
    [HideInInspector] public int dem; // xét vị trí mảng

    [SerializeField] public GameObject spri;
    public int[,] mang;
    [SerializeField] public int time;

    [HideInInspector] public int danhdau; // đánh dấu số thứ tự của sprite sản phẩm trong gameobject nhà máy

    private void Awake()
    {
        instance = this;
        mang = new int[6, 3];
    }

    private void Start()
    {
        animatoractive = GetComponent<Animator>();
        //animatoractive.enabled = !animatoractive.enabled;
        animatoractive.enabled = false;
        maxDem = 0;
        sl_bongbong = 0;
        dem = 0;
        danhdau = 1;
    }
    private void OnMouseDown()
    {
        GameManager.instance.nmSX = gameObject;
        maxDem = 0;
        for (int i=1; i<transform.childCount;i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf==true)
            {
                maxDem++;
                if (maxDem > sl_bongbong)
                {
                    sl_bongbong = maxDem;
                }
            }
        }
        //ShowCanvasBo_phomai();
        switch (id)
        {
            case 1:
                ShowCanvas_NhaMay(GameManager.instance.CanvasSXthuanconvat);
                break;
            case 2:
                ShowCanvas_NhaMay(GameManager.instance.canvas_bo_phomai);
                break;
            case 3:

                break;
            default:
                break;
        }
    }

    public void ShowCanvas_NhaMay(GameObject canvas)
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
                        = GameManager.instance.dataSPCheBien.data[mang[i, 0]-1].iconsanpham;
                canvas.transform.GetChild(2).GetChild(i).GetChild(0).GetComponent<Image>().color
                    = new Color(255, 255, 255, 255);
            }

        }

        // show ra canvas
        {
            canvas.transform.position = transform.position + new Vector3(-0.4f, 1f, 0);
        }
       

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (id)
        {
            case 1:

                break;
            case 2:
                if (collision.gameObject.CompareTag("SP_bo_phomai"))
                {

                    Debug.Log("va cham");
                    if (animatoractive.enabled == false)
                    {
                        animatoractive.enabled = true;
                    }

                    dem++;
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
                break;
            default:
                break;
        }
    }

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
            animatoractive.enabled =false;
            //GameManager.instance.canvas_bo_phomai.transform.GetChild(0).gameObject.SetActive(false);
        }
    }



    public void ShowSeedUI()
    {

    }
}
