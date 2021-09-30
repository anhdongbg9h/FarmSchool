using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cayanqua : MonoBehaviour, IInteractable
{
    public int id;
    [HideInInspector] public int timeCaylon1;
    [HideInInspector] public int timeCaylon2;
    public int timeTotal;
    private int timeTotal1;
    private bool check = true;
    [SerializeField] private GameObject iconFly;
    [SerializeField] private GameObject iconFly_kinhnghiem;
    [SerializeField] private GameObject hieuung;
    private GameObject obj;

    private void Start()
    {
        timeCaylon1 = GameManager.instance.dataNongSan.data[id].time1;
        timeCaylon2 = GameManager.instance.dataNongSan.data[id].time2;
        //PhatTrien(id, timeCaylon1, timeCaylon2);
    }
    private void OnMouseDown()
    {
        Debug.Log(timeTotal);
        if (timeTotal>0)
        {
            obj.transform.position = transform.position + new Vector3(-0.5f, 1.2f, 0);
            StartCoroutine(day_timerangoai());
        }
        if (timeTotal==0)
        {
            GameManager.instance.thuhoachqua.transform.position=transform.position + new Vector3(-0.5f, 1.2f, 0);
        }
    }

    public void phattrien_new(int id, int t1, int t2)
    {
        this.id = id;/*
        timeCaylon1 = t1;
        timeCaylon2 = t2;*/
        PhatTrien(id, t1, t2);
    }

    void PhatTrien(int id, int timeCaylon1, int timeCaylon2)
    {
        obj = Instantiate(GameManager.instance.hienthoigian);
        hieuung.SetActive(false);
        this.timeCaylon1 = timeCaylon1;
        this.timeCaylon2 = timeCaylon2;
        this.timeTotal = timeCaylon1 + timeCaylon2;
        this.timeTotal1 = timeCaylon1 + timeCaylon2;
        StartCoroutine(timecay(timeTotal));
        StartCoroutine(caylon(id,timeCaylon1,timeCaylon2));
    }
    IEnumerator day_timerangoai()
    {
        yield return new WaitForSeconds(2f);
        obj.transform.position = new Vector3(999f, 999f, 0);
    }
    IEnumerator timecay(int timeTotal)
    {
        //this.timeTotal = timeTotal;
        obj.GetComponent<hienthoigian>().UpdateTime(timeTotal, timeTotal1);
        yield return new WaitForSeconds(1f);

        timeTotal--;
        this.timeTotal = timeTotal;
        if (timeTotal > 0)
        {
            StartCoroutine(timecay(timeTotal));
        }
        if (timeTotal == 0)
        {
            hieuung.SetActive(true);
            Destroy(obj);
        }
    }
    IEnumerator caylon(int id, int timeCaylon1, int timeCaylon2)
    {
        yield return new WaitForSeconds(1f);
        this.timeCaylon1 = timeCaylon1;
        this.timeCaylon2 = timeCaylon2;
        timeCaylon1--;
        if (timeCaylon1>0)
            StartCoroutine(caylon(id,timeCaylon1,timeCaylon2));
        else
        {
            GetComponent<SpriteRenderer>().sprite = GameManager.instance.dataNongSan.data[id].gd2;
            timeCaylon2--;
            if (timeCaylon2>0)
            {
                StartCoroutine(caylon(id,timeCaylon1,timeCaylon2));
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = GameManager.instance.dataNongSan.data[id].gd3;
                check = false;
            }
        }
    }
    public void ShowSeedUI()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (check==false && collision.gameObject.CompareTag("bantay"))
        {
            check = true;
            GetComponent<SpriteRenderer>().sprite = GameManager.instance.dataNongSan.data[id].gd1;
            GameObject ob = Instantiate(iconFly, transform.position, Quaternion.identity);
            GameManager.instance.dataNongSan.data[id].sanluong += 2;
            GameObject ob1 = Instantiate(iconFly_kinhnghiem, transform.position, Quaternion.identity);
            GameManager.instance.datanhachinh.data[GameManager.instance.dataui.data[2].giatri - 1].KinhNghiem
                        += GameManager.instance.dataNongSan.data[id].exp;
            ob.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = 
                GameManager.instance.dataNongSan.data[id].iconsanpham;
            PhatTrien(id,timeCaylon1,timeCaylon2);
        }
    }

}
