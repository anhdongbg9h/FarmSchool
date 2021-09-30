using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Phada : MonoBehaviour, IInteractable
{
    public int id;
    public GameObject anima;
    public GameObject Grid;
    public GameObject doituong_dexacdinh_layer;
    public bool xacdinh = false;
    [HideInInspector] public float kc;

    [SerializeField] private GameObject iconFly;


    private void Start()
    {
        kc = Mathf.Abs(gameObject.transform.GetChild(1).transform.position.y - doituong_dexacdinh_layer.transform.position.y)*10;
        gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = (int)kc;
    }

    public void ChangeAnim()
    {
        anima.SetActive(true);
        StartCoroutine(wait());
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.7f);
        anima.SetActive(false);
        Set_ToaDo(gameObject);
        yield return new WaitForSeconds(0.2f);
        GameObject ob = Instantiate(iconFly, transform.position, Quaternion.identity);
        ob.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite =
            GameManager.instance.dataSPCheBien.data[59].iconsanpham;
        GameManager.instance.dataSPCheBien.data[59].sanluong++;
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        GameManager.instance.dayCanvas_rangoai();
        xacdinh = true;
        Show_canvas_phada();
        GameManager.instance.canvas_phahuy_da.transform.position = transform.position + new Vector3(-0.7f, 0.8f, 0);
    }
    private void Show_canvas_phada()
    {
        GameManager.instance.canvas_phahuy_da.transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text
            = GameManager.instance.dataSPCheBien.data[61].sanluong.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("thuocno"))
        {
            if (xacdinh)
            {
                if (GameManager.instance.dataSPCheBien.data[61].sanluong > 0)
                {
                    if (gameObject.CompareTag("danho"))
                    {
                        Debug.Log("va cham da nho");
                        save_id_cay.instance.mang_id_da[save_id_cay.instance.dem_da] = id;
                        save_id_cay.instance.dem_da++;
                    }
                    else if (gameObject.CompareTag("dato"))
                    {
                        Debug.Log("va cham da to");

                        save_id_dato.instance.mang_id_dato[save_id_dato.instance.dem_da_to] = id;
                        save_id_dato.instance.dem_da_to++;
                    }
                    collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                    collision.gameObject.SetActive(false);
                    GameManager.instance.dataSPCheBien.data[61].sanluong--;
                    ChangeAnim();
                }
                else
                {
                    collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                    collision.gameObject.SetActive(false);
                    Debug.Log("không đủ thuốc nổ để phá đá, bạn hãy mua nó!");
                }
            }
        }
    }

    public void ShowSeedUI()
    {

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
        if (gameObject.CompareTag("danho"))
        {
            Grid.transform.GetChild(0).GetComponent<Tilemap>().tilemap[x, y] = 0;
        }
        else if (gameObject.CompareTag("dato"))
        {
            for (int i = x; i >= x - 2; i--)
            {
                for (int j = y; j <= y + 2; j++)
                {
                    Grid.transform.GetChild(0).GetComponent<Tilemap>().tilemap[i, j] = 0;
                }
            }
        }
    }

}
