using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using TMPro;

public class cayrung : MonoBehaviour, IInteractable
{
    public int id;
    public GameObject Grid;
    public GameObject doi_tuong_cha;
    public bool xacdinh =false;
    [HideInInspector] public SkeletonAnimation cr;
    private int time = 2;
    [SerializeField] private GameObject iconFly;
    public GameObject doituong_dexacdinhlayer;
    float kc;
    private void Start()
    {
        cr = GetComponent<SkeletonAnimation>();
        kc = Mathf.Abs(gameObject.transform.position.y - doituong_dexacdinhlayer.transform.position.y)*10;
        gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = (int)kc;
    }

    private void OnMouseDown()
    {
        GameManager.instance.dayCanvas_rangoai();
        xacdinh = true;
        
        Show_canvas();
        GameManager.instance.canvasChatcay.transform.position = transform.position + new Vector3(-0.6f, 1.3f, 0);
    }
    private void Show_canvas()
    {
        GameManager.instance.canvasChatcay.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text =
            GameManager.instance.dataSPCheBien.data[60].sanluong.ToString();
    }
    public void ChangeAnim()
    {
        cr.AnimationName = "chat";
        StartCoroutine(wait());
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
        time--;
        if (time > 0)
        {
            StartCoroutine(wait());
        }
        else if (time == 0)
        {
            cr.AnimationName = "do";
            yield return new WaitForSeconds(0.8f);
            Set_ToaDo(doi_tuong_cha);
            gameObject.SetActive(false);
            GameObject ob = Instantiate(iconFly, transform.position, Quaternion.identity);
            ob.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite =
                GameManager.instance.cayrung.data[0].sanpham;
            GameManager.instance.dataSPCheBien.data[58].sanluong++;
            Destroy(doi_tuong_cha);
            yield return null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("duichatcay"))
        {
            if (xacdinh)
            {
                if (GameManager.instance.dataSPCheBien.data[60].sanluong > 0)
                {
                    save_id_cay.instance.mang_id_chatcay[save_id_cay.instance.dem_cay] = id;
                    save_id_cay.instance.dem_cay++;
                    collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                    collision.gameObject.SetActive(false);
                    GameManager.instance.dataSPCheBien.data[60].sanluong--;
                    ChangeAnim();
                }
                else
                {
                    collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                    collision.gameObject.SetActive(false);
                    Debug.Log("không đủ dìu để chặt cây, bạn hãy mua nó!");
                }
            }
        }
    }
    public void Set_ToaDo(GameObject obj)
    {
        float toado_x, toado_y;
        float TG1, TG2;
        toado_x = obj.transform.position.x - Grid.transform.position.x;
        toado_y = obj.transform.position.y - Grid.transform.position.y;

        TG1 = Mathf.Abs(Grid.transform.GetChild(0).position.x - obj.transform.position.x);
        TG2 = Mathf.Abs(Grid.transform.GetChild(0).position.y - obj.transform.position.y);


        XacDinh_goc(TG1, TG2, toado_x, toado_y);
    }
    public void XacDinh_goc(float TG1, float TG2, float toado_x, float toado_y)
    {
        int x = 0, y = 0;
        if (TG1 == System.Math.Truncate(TG1) + 0.5f)
        {
            TG1 = (float)System.Math.Truncate(TG1) + 1f;
        }
        else if (TG1 == System.Math.Truncate(TG1))
        {
            TG1 = (float)System.Math.Truncate(TG1);
        }

        if (TG2 == (float)System.Math.Truncate(TG2))
        {
            TG2 = (float)System.Math.Truncate(TG2) * 2;
        }
        else if (TG2 == (float)System.Math.Truncate(TG2) + 0.25f || TG2 == (float)System.Math.Truncate(TG2) + 0.5f)
        {
            TG2 = (float)System.Math.Truncate(TG2) * 2 + 1;
        }
        else if (TG2 == (float)System.Math.Truncate(TG2) + 0.75f)
        {
            TG2 = (float)System.Math.Truncate(TG2) * 2 + 2;
        }

        if (toado_y > 0)
        {
            if (toado_x == (float)System.Math.Truncate(toado_x))
            {
                x = (int)(TG1 - TG2 + 1);
                y = (int)(TG1 + TG2);
            }
            else if (toado_x == (float)System.Math.Truncate(toado_x) + 0.5f)
            {
                x = (int)(TG1 - TG2);
                y = (int)(TG1 + TG2);
            }
        }
        else if (toado_y < 0)
        {
            if (toado_x == (float)System.Math.Truncate(toado_x))
            {
                y = (int)(TG1 - TG2 + 1);
                x = (int)(TG1 + TG2);
            }
            else if (toado_x == (float)System.Math.Truncate(toado_x) + 0.5f)
            {
                y = (int)(TG1 - TG2);
                x = (int)(TG1 + TG2);
            }
        }
        else if (toado_y == 0)
        {
            x = (int)TG1;
            y = (int)TG1;
        }
        gan(x, y);
    }
    public void gan(int x, int y)
    {
        Grid.transform.GetChild(0).GetComponent<Tilemap>().tilemap[x, y] = 0;
    }

    public void ShowSeedUI()
    {

    }
}
