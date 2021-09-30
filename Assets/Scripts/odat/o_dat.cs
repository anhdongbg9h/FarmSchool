using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class o_dat : MonoBehaviour, IInteractable
{
    Animator ani;
    private int id_giong;
    [SerializeField] private SpriteRenderer cay;
    [SerializeField] private GameObject iconFly;
    [SerializeField] private GameObject iconFly_kinhnghiem;
    [SerializeField] private int timeCayLon1;
    [SerializeField] private int timeCayLon2;
    public int timeTotal;
    public int timeTotal1;

    public bool isThuhoach = true;
    //[HideInInspector]
    public int id_sp;

    private GameObject obj;
    //public GameObject canvas;

    private void Awake()
    {
        id_sp = -1;
        ani = GetComponent<Animator>();
        ani.enabled = !ani.enabled;
    }
    public void Start_Odat(int id_giong, int time, int t1, int t2)
    {
        this.timeTotal = time;
        timeTotal1 = time;
        this.id_giong = id_giong;
        timeCayLon1 = t1;
        timeCayLon2 = t2;
        TrongCay(id_giong, timeCayLon1, timeCayLon2);
    }

    public void OdatUICLick(bool isThuHoach, Vector3 viTri)
    {
        // cập nhật thông tin của canvas
        Show_canvas();

        if (cay.sprite == null)
        {
            GameManager.instance.dialogHG.transform.position = viTri + new Vector3(-0.8f, 0.4f, 0);
        }
        else
        {
            if (timeTotal > 0)
            {
                obj.transform.position = viTri + new Vector3(-0.5f, 1f, 0);
                StartCoroutine(day_timerangoai());
            }
            if (!isThuHoach)
            {
                GameManager.instance.thuhoach.transform.position = viTri + new Vector3(-1f, 1f, 0);
            }
        }
    }
    private void OnMouseDown()
    {
        //GameManager.instance.hienthoigian.GetComponent<hienthoigian>().StopTime();
        GameManager.instance.dialogHG.GetComponent<Save_vitrinhamay>().vitrinhamay = transform.position;
        GameManager.instance.dayCanvas_rangoai();
        OdatUICLick(isThuhoach, transform.position);
    }
    public void TrongCay(int id, int timeCayLon1, int timeCayLon2)
    {
        if (cay.sprite == null)
        {
            obj = Instantiate(GameManager.instance.hienthoigian);
            this.timeCayLon1 = timeCayLon1;
            this.timeCayLon2 = timeCayLon2;
            cay.sprite = GameManager.instance.dataNongSan.data[id].gd1;
            StartCoroutine(cayLon(id, timeCayLon1, timeCayLon2));
            StartCoroutine(time_odat(timeTotal));
        }
        id_sp = id;
    }

    IEnumerator day_timerangoai()
    {
        yield return new WaitForSeconds(5f);
        obj.transform.position = new Vector3(999f, 999f, 0);
    }

    IEnumerator time_odat(int timeTotal)
    {
        obj.GetComponent<hienthoigian>().UpdateTime(timeTotal, timeTotal1);
        yield return new WaitForSeconds(1f);
        //Debug.Log(timeTotal);
        timeTotal--;
        this.timeTotal = timeTotal;
        if (timeTotal > 0)
        {
            StartCoroutine(time_odat(timeTotal));
        }
        if (timeTotal == 0)
        {
            Destroy(obj);
        }
    }

    IEnumerator cayLon(int id, int timeCayLon1, int timeCayLon2)
    {
        yield return new WaitForSeconds(1f);
        this.timeCayLon1 = timeCayLon1;
        this.timeCayLon2 = timeCayLon2;
        timeCayLon1--;
        if (timeCayLon1 > 0)
            StartCoroutine(cayLon(id, timeCayLon1, timeCayLon2));
        else
        {
            cay.sprite = GameManager.instance.dataNongSan.data[id].gd2;
            timeCayLon2--;
            if (timeCayLon2 > 0)
            {
                StartCoroutine(cayLon(id, timeCayLon1, timeCayLon2));
            }
            else
            {
                isThuhoach = false;
                cay.sprite = GameManager.instance.dataNongSan.data[id].gd3;
                yield return null;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (cay.sprite == null)
        {
            if(collision.gameObject.tag == "nongsan")
            {
                id_giong = collision.gameObject.GetComponent<nongsan_setID>().id;
                timeCayLon1 = GameManager.instance.dataNongSan.data[id_giong].time1;
                timeCayLon2 = GameManager.instance.dataNongSan.data[id_giong].time2;
                timeTotal = timeCayLon1 + timeCayLon2;
                timeTotal1 = timeCayLon1 + timeCayLon2;
                StartCoroutine(hieuung(gameObject));
                TrongCay(id_giong, timeCayLon1, timeCayLon2);
                GameManager.instance.dataNongSan.data[id_giong].sanluong--;
            }
        }
        else
        {
            if (!isThuhoach)
            {
                if (collision.gameObject.CompareTag("liem"))
                {
                    cay.sprite = null;
                    GameObject ob = Instantiate(iconFly, transform.position, Quaternion.identity);
                    GameObject obj = Instantiate(iconFly_kinhnghiem, transform.position, Quaternion.identity);
                    ob.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = 
                        GameManager.instance.dataNongSan.data[id_sp].iconsanpham;
                    isThuhoach = true;
                    GameManager.instance.datanhachinh.data[GameManager.instance.dataui.data[2].giatri - 1].KinhNghiem
                        += GameManager.instance.dataNongSan.data[id_sp].exp;
                    GameManager.instance.dataNongSan.data[id_sp].sanluong += 2;
                    id_sp = -1;
                }
            }
        }
    }

    IEnumerator hieuung(GameObject obj)
    {
        obj.transform.GetChild(1).gameObject.SetActive(true);
        obj.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite =
            GameManager.instance.dataNongSan.data[id_giong].iconsanpham;
        yield return new WaitForSeconds(.7f);
        obj.transform.GetChild(1).gameObject.SetActive(false);
    }

    public void Show_canvas()
    {
        // cấp 1
        if (GameManager.instance.dataui.data[2].giatri == 1)
        {
            // tắt tất cả các canvas thành phần
            for (int i = 0; i < GameManager.instance.dialogHG.transform.childCount; i++)
            {
                GameManager.instance.dialogHG.transform.GetChild(i).gameObject.SetActive(false);
            }
            GameManager.instance.dialogHG.transform.GetChild(0).gameObject.SetActive(true);
            GameManager.instance.dialogHG.transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                GameManager.instance.dataNongSan.data[12].sanluong.ToString();
        }
        // cấp 2
        else if (GameManager.instance.dataui.data[2].giatri == 2)
        {
            for (int i = 0; i < GameManager.instance.dialogHG.transform.childCount; i++)
            {
                GameManager.instance.dialogHG.transform.GetChild(i).gameObject.SetActive(false);
            }
            GameManager.instance.dialogHG.transform.GetChild(1).gameObject.SetActive(true);
            GameManager.instance.dialogHG.transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                GameManager.instance.dataNongSan.data[12].sanluong.ToString();
            GameManager.instance.dialogHG.transform.GetChild(1).GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                GameManager.instance.dataNongSan.data[14].sanluong.ToString();

        }
        // cấp 3
        else if (GameManager.instance.dataui.data[2].giatri == 3)
        {
            for (int i = 0; i < GameManager.instance.dialogHG.transform.childCount; i++)
            {
                GameManager.instance.dialogHG.transform.GetChild(i).gameObject.SetActive(false);
            }
            GameManager.instance.dialogHG.transform.GetChild(2).gameObject.SetActive(true);
            GameManager.instance.dialogHG.transform.GetChild(2).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                GameManager.instance.dataNongSan.data[12].sanluong.ToString();
            GameManager.instance.dialogHG.transform.GetChild(2).GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                GameManager.instance.dataNongSan.data[14].sanluong.ToString();
            GameManager.instance.dialogHG.transform.GetChild(2).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                GameManager.instance.dataNongSan.data[3].sanluong.ToString();
        }
        // cấp 4
        else if (GameManager.instance.dataui.data[2].giatri == 4)
        {
            for (int i = 0; i < GameManager.instance.dialogHG.transform.childCount; i++)
            {
                GameManager.instance.dialogHG.transform.GetChild(i).gameObject.SetActive(false);
            }
            GameManager.instance.dialogHG.transform.GetChild(3).gameObject.SetActive(true);
            GameManager.instance.dialogHG.transform.GetChild(3).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                GameManager.instance.dataNongSan.data[12].sanluong.ToString();
            GameManager.instance.dialogHG.transform.GetChild(3).GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                GameManager.instance.dataNongSan.data[14].sanluong.ToString();
            GameManager.instance.dialogHG.transform.GetChild(3).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                GameManager.instance.dataNongSan.data[3].sanluong.ToString();
            GameManager.instance.dialogHG.transform.GetChild(3).GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                GameManager.instance.dataNongSan.data[6].sanluong.ToString();

        }
        // cấp 5 trở lên
        else if (GameManager.instance.dataui.data[2].giatri >= 5)
        {
            for (int i = 0; i < GameManager.instance.dialogHG.transform.childCount; i++)
            {
                GameManager.instance.dialogHG.transform.GetChild(i).gameObject.SetActive(false);
            }

            GameManager.instance.dialogHG.transform.GetChild(4).gameObject.SetActive(true);

            if (GameManager.instance.dataui.data[2].giatri == 5)
            {
                for (int i = 1; i <= 5; i++)
                {
                    GameManager.instance.dialogHG.transform.GetChild(4).GetChild(i).gameObject.SetActive(true);
                }
                for (int i = 6; i < 19; i++)
                {
                    GameManager.instance.dialogHG.transform.GetChild(4).GetChild(i).gameObject.SetActive(false);
                }
                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                GameManager.instance.dataNongSan.data[12].sanluong.ToString();
                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataNongSan.data[14].sanluong.ToString();
                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataNongSan.data[3].sanluong.ToString();
                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataNongSan.data[6].sanluong.ToString();
                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(5).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataNongSan.data[9].sanluong.ToString();
            }
            else if (GameManager.instance.dataui.data[2].giatri == 6)
            {
                for (int i = 1; i <= 7; i++)
                {
                    GameManager.instance.dialogHG.transform.GetChild(4).GetChild(i).gameObject.SetActive(true);
                }
                for (int i = 8; i < 19; i++)
                {
                    GameManager.instance.dialogHG.transform.GetChild(4).GetChild(i).gameObject.SetActive(false);
                }

                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                GameManager.instance.dataNongSan.data[12].sanluong.ToString();
                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataNongSan.data[14].sanluong.ToString();
                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataNongSan.data[3].sanluong.ToString();
                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataNongSan.data[6].sanluong.ToString();
                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(5).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataNongSan.data[9].sanluong.ToString();
                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(6).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataNongSan.data[5].sanluong.ToString();
                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(7).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataNongSan.data[13].sanluong.ToString();
            }
            else if (GameManager.instance.dataui.data[2].giatri == 7)
            {
                for (int i = 1; i <= 9; i++)
                {
                    GameManager.instance.dialogHG.transform.GetChild(4).GetChild(i).gameObject.SetActive(true);
                }
                for (int i = 10; i < 19; i++)
                {
                    GameManager.instance.dialogHG.transform.GetChild(4).GetChild(i).gameObject.SetActive(false);
                }

                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                GameManager.instance.dataNongSan.data[12].sanluong.ToString();
                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataNongSan.data[14].sanluong.ToString();
                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataNongSan.data[3].sanluong.ToString();
                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataNongSan.data[6].sanluong.ToString();
                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(5).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataNongSan.data[9].sanluong.ToString();
                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(6).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataNongSan.data[5].sanluong.ToString();
                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(7).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataNongSan.data[13].sanluong.ToString();
                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(8).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataNongSan.data[16].sanluong.ToString();
                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(9).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataNongSan.data[15].sanluong.ToString();
            }
            else if (GameManager.instance.dataui.data[2].giatri >= 8)
            {
                GameManager.instance.dialogHG.transform.GetChild(5).gameObject.SetActive(true);
                for (int i = 1; i <= 9; i++)
                {
                    GameManager.instance.dialogHG.transform.GetChild(4).GetChild(i).gameObject.SetActive(true);
                }

                for (int i = 10; i < 19; i++)
                {
                    GameManager.instance.dialogHG.transform.GetChild(4).GetChild(i).gameObject.SetActive(false);
                }

                /*GameManager.instance.dialogHG.transform.GetChild(4).GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                GameManager.instance.dataNongSan.data[12].sanluong.ToString();
                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataNongSan.data[14].sanluong.ToString();
                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataNongSan.data[3].sanluong.ToString();
                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataNongSan.data[6].sanluong.ToString();
                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(5).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataNongSan.data[9].sanluong.ToString();
                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(6).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataNongSan.data[5].sanluong.ToString();
                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(7).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataNongSan.data[13].sanluong.ToString();
                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(8).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataNongSan.data[16].sanluong.ToString();
                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(9).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataNongSan.data[15].sanluong.ToString();*/
            }

        }
    }

    public void xoay_chuyen()
    {
        
    }

    public void ShowSeedUI()
    {

    }
}
