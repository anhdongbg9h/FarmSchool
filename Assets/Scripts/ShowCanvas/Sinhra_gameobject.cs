using BitBenderGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Sinhra_gameobject : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [HideInInspector] public GameObject obj;
    public GameObject SR;
    [SerializeField] GameObject shop;
    [SerializeField] GameObject nen;
    private Vector3 vt;
    private int xacdinh_object;

    public ScrollRect scrollRect;

    public GameObject Grid;
    [HideInInspector] public bool khoa;

    public GameObject obj_chua;

    float x, y;
    public bool convat;
    public bool chuong;
    public bool cayanqua;
    public bool odat;
    public bool nhamay;
    public int ID;

    int TD_X, TD_Y;
    float x_toado, y_toado;
    float TG1, TG2;

    double toado_x, toado_y, temp_x, temp_y;

    public GameObject doituong_dexacdinh_layer;
    public float kc;
    public bool ondrag = false;

    public void OnDrag(PointerEventData eventData)
    {
        ondrag = true;
        TouchInputController.instance.isDragging = true; // khoa camera
        if (khoa == true)
        {
            
            if (convat)
            {
                obj.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                    Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
                shop.transform.position = new Vector3(999, 999, 0);
            }
            else
            {
                toado_x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
                toado_y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
                temp_x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - Grid.transform.position.x;
                temp_y = Mathf.Abs(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - Grid.transform.position.y);
                // xét điều kiện tọa độ X
                {
                    if (temp_x >= System.Math.Truncate(temp_x) && temp_x < System.Math.Truncate(temp_x) + 0.5f)
                    {
                        temp_x = System.Math.Truncate(temp_x);
                    }
                    else if (temp_x >= System.Math.Truncate(temp_x) + 0.5f)
                    {
                        temp_x = System.Math.Truncate(temp_x) + 0.5f;
                    }
                }

                // xét điều kiện tọa độ Y
                {
                    if (temp_y >= System.Math.Truncate(temp_y) && temp_y < System.Math.Truncate(temp_y) + 0.25f)
                    {
                        temp_y = System.Math.Truncate(temp_y);
                    }
                    else if (temp_y >= System.Math.Truncate(temp_y) + 0.25f && temp_y < System.Math.Truncate(temp_y) + 0.5f)
                    {
                        temp_y = System.Math.Truncate(temp_y) + 0.25f;
                    }
                    else if (temp_y >= System.Math.Truncate(temp_y) + 0.5f && temp_y < System.Math.Truncate(temp_y) + 0.75f)
                    {
                        temp_y = System.Math.Truncate(temp_y) + 0.5f;
                    }
                    else if (temp_y >= System.Math.Truncate(temp_y) + 0.75f)
                    {
                        temp_y = System.Math.Truncate(temp_y) + 0.75f;
                    }
                }


                //làm tròn giá trị đúng
                {
                    if (temp_x - System.Math.Truncate(temp_x) == System.Math.Truncate(temp_x - System.Math.Truncate(temp_x)))
                    {
                        if (temp_y == System.Math.Truncate(temp_y) || temp_y == System.Math.Truncate(temp_y) + 0.5f)
                        {
                            temp_y += 0.25f;
                        }
                    }
                    else if (temp_x - System.Math.Truncate(temp_x) == System.Math.Truncate(temp_x - System.Math.Truncate(temp_x)) + 0.5f)
                    {
                        if (temp_y == System.Math.Truncate(temp_y) + 0.25f || temp_y == System.Math.Truncate(temp_y) + 0.75f)
                        {
                            temp_y += 0.25f;
                        }
                    }
                }

                //gán lại tọa độ
                {
                    toado_x = temp_x + Grid.transform.position.x;
                    if (toado_y >= Grid.transform.position.y)
                    {
                        toado_y = temp_y + Grid.transform.position.y;
                    }
                    else if (toado_y < Grid.transform.position.y)
                    {
                        toado_y = Grid.transform.position.y - temp_y;
                    }
                }

                x = (float)toado_x;
                y = (float)toado_y;

                obj.transform.position = new Vector3(x, y, 0);
                if (ondrag == true)
                {
                    Set_ToaDo(1, obj, ID);
                }
                shop.transform.position = new Vector3(999, 999, 0);
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {        
        vt = shop.transform.position;
        TouchInputController.instance.isDragging = true; // khoa camera
        if (khoa == true)
        {
            nen.SetActive(false);
            if (convat)
            {
                obj = Instantiate(SR, Camera.main.ScreenToWorldPoint(Input.mousePosition),
                Quaternion.identity);
            }
            else
            {
                obj = Instantiate(SR, /*GameObject.Find("odats").transform*/ obj_chua.transform);
                obj.transform.position = transform.position;
            }
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (ondrag == false)
        {
            Destroy(obj);
        }
        else
        {
            if (khoa == true)
            {
                if (convat)
                {
                    Destroy(obj);
                    //Click_shopConvat.instance.Showthongtin_shopconvat();

                    if (gameObject.name == "Con_ga")
                    {
                        xacdinh_object = 1;
                        if (GameManager.instance.datashopconvat.data[xacdinh_object].sl <= GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan)
                        {
                            shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                GameManager.instance.datashopconvat.data[xacdinh_object].sl.ToString();
                            if (GameManager.instance.datashopconvat.data[xacdinh_object].sl == GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan)
                            {
                                khoa = false;
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                GameManager.instance.datashopconvat.data[xacdinh_object].sl.ToString();
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan += 3;
                                GameManager.instance.datashopconvat.data[xacdinh_object].Capmo += 5;
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                    (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 3).ToString();
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                    + GameManager.instance.datashopconvat.data[xacdinh_object].Capmo;
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                            }
                        }

                    }
                    else if (gameObject.name == "Con_bo")
                    {
                        xacdinh_object = 3;
                        if (GameManager.instance.datashopconvat.data[xacdinh_object].sl <= GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan)
                        {
                            shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                GameManager.instance.datashopconvat.data[xacdinh_object].sl.ToString();
                            if (GameManager.instance.datashopconvat.data[xacdinh_object].sl == GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan)
                            {
                                khoa = false;
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                GameManager.instance.datashopconvat.data[xacdinh_object].sl.ToString();
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan += 3;
                                GameManager.instance.datashopconvat.data[xacdinh_object].Capmo += 5;
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                    (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 3).ToString();
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                    + GameManager.instance.datashopconvat.data[xacdinh_object].Capmo;
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                            }
                        }
                    }
                    else if (gameObject.name == "Con_lon")
                    {
                        xacdinh_object = 5;
                        if (GameManager.instance.datashopconvat.data[xacdinh_object].sl <= GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan)
                        {
                            shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                GameManager.instance.datashopconvat.data[xacdinh_object].sl.ToString();
                            if (GameManager.instance.datashopconvat.data[xacdinh_object].sl == GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan)
                            {
                                khoa = false;
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                GameManager.instance.datashopconvat.data[xacdinh_object].sl.ToString();
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan += 3;
                                GameManager.instance.datashopconvat.data[xacdinh_object].Capmo += 5;
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                    (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 3).ToString();
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                    + GameManager.instance.datashopconvat.data[xacdinh_object].Capmo;
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                            }
                        }
                    }
                    else if (gameObject.name == "Con_cuu")
                    {
                        xacdinh_object = 7;
                        if (GameManager.instance.datashopconvat.data[xacdinh_object].sl <= GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan)
                        {
                            shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                GameManager.instance.datashopconvat.data[xacdinh_object].sl.ToString();
                            if (GameManager.instance.datashopconvat.data[xacdinh_object].sl == GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan)
                            {
                                khoa = false;
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                GameManager.instance.datashopconvat.data[xacdinh_object].sl.ToString();
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan += 3;
                                GameManager.instance.datashopconvat.data[xacdinh_object].Capmo += 5;
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                    (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 3).ToString();
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                    + GameManager.instance.datashopconvat.data[xacdinh_object].Capmo;
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                            }
                        }
                    }
                    else if (gameObject.name == "Con_de")
                    {
                        xacdinh_object = 9;
                        if (GameManager.instance.datashopconvat.data[xacdinh_object].sl <= GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan)
                        {
                            shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                GameManager.instance.datashopconvat.data[xacdinh_object].sl.ToString();
                            if (GameManager.instance.datashopconvat.data[xacdinh_object].sl == GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan)
                            {
                                khoa = false;
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                GameManager.instance.datashopconvat.data[xacdinh_object].sl.ToString();
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan += 3;
                                GameManager.instance.datashopconvat.data[xacdinh_object].Capmo += 5;
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                    (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 3).ToString();
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                    + GameManager.instance.datashopconvat.data[xacdinh_object].Capmo;
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                            }
                        }
                    }
                    else if (gameObject.name == "Con_ngua")
                    {
                        xacdinh_object = 11;
                        if (GameManager.instance.datashopconvat.data[xacdinh_object].sl <= GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan)
                        {
                            shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                GameManager.instance.datashopconvat.data[xacdinh_object].sl.ToString();
                            if (GameManager.instance.datashopconvat.data[xacdinh_object].sl == GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan)
                            {
                                khoa = false;
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                GameManager.instance.datashopconvat.data[xacdinh_object].sl.ToString();
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan += 3;
                                GameManager.instance.datashopconvat.data[xacdinh_object].Capmo += 5;
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                    (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 3).ToString();
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                    + GameManager.instance.datashopconvat.data[xacdinh_object].Capmo;
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                            }
                        }
                    }
                }
                else
                {
                    if (obj.transform.GetChild(0).GetComponent<SpriteRenderer>().color == new Color32(255, 255, 255, 255))
                    {
                        if (gameObject.name == "o_dat")
                        {
                            xacdinh_object = 0;
                            if (GameManager.instance.datashopxd.data[xacdinh_object].sl < GameManager.instance.datashopxd.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashopxd.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopxd.data[xacdinh_object].Gia;
                                shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashopxd.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashopxd.data[xacdinh_object].sl == GameManager.instance.datashopxd.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);

                                    GameManager.instance.datashopxd.data[xacdinh_object].GioiHan += 3;
                                    GameManager.instance.datashopxd.data[xacdinh_object].Capmo += 5;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 3).ToString();
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashopxd.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "Sanxuat_thucan")
                        {
                            xacdinh_object = 1;
                            if (GameManager.instance.datashopxd.data[xacdinh_object].sl < GameManager.instance.datashopxd.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashopxd.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopxd.data[xacdinh_object].Gia;
                                shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashopxd.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashopxd.data[xacdinh_object].sl == GameManager.instance.datashopxd.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashopxd.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashopxd.data[xacdinh_object].Capmo += 5;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashopxd.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "nhamay_bot")
                        {
                            xacdinh_object = 2;
                            if (GameManager.instance.datashopxd.data[xacdinh_object].sl < GameManager.instance.datashopxd.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashopxd.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopxd.data[xacdinh_object].Gia;
                                shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashopxd.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashopxd.data[xacdinh_object].sl == GameManager.instance.datashopxd.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashopxd.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashopxd.data[xacdinh_object].Capmo += 5;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashopxd.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "May_bo")
                        {
                            xacdinh_object = 3;
                            if (GameManager.instance.datashopxd.data[xacdinh_object].sl < GameManager.instance.datashopxd.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashopxd.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopxd.data[xacdinh_object].Gia;
                                shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashopxd.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashopxd.data[xacdinh_object].sl == GameManager.instance.datashopxd.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashopxd.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashopxd.data[xacdinh_object].Capmo += 5;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashopxd.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "May_quang")
                        {
                            xacdinh_object = 4;
                            if (GameManager.instance.datashopxd.data[xacdinh_object].sl < GameManager.instance.datashopxd.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashopxd.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopxd.data[xacdinh_object].Gia;
                                shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashopxd.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashopxd.data[xacdinh_object].sl == GameManager.instance.datashopxd.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashopxd.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashopxd.data[xacdinh_object].Capmo += 5;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashopxd.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "May_duong")
                        {
                            xacdinh_object = 5;
                            if (GameManager.instance.datashopxd.data[xacdinh_object].sl < GameManager.instance.datashopxd.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashopxd.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopxd.data[xacdinh_object].Gia;
                                shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashopxd.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashopxd.data[xacdinh_object].sl == GameManager.instance.datashopxd.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashopxd.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashopxd.data[xacdinh_object].Capmo += 5;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashopxd.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "May_sua")
                        {
                            xacdinh_object = 6;
                            if (GameManager.instance.datashopxd.data[xacdinh_object].sl < GameManager.instance.datashopxd.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashopxd.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopxd.data[xacdinh_object].Gia;
                                shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashopxd.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashopxd.data[xacdinh_object].sl == GameManager.instance.datashopxd.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashopxd.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashopxd.data[xacdinh_object].Capmo += 5;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashopxd.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "Lo_nuong")
                        {
                            xacdinh_object = 7;
                            if (GameManager.instance.datashopxd.data[xacdinh_object].sl < GameManager.instance.datashopxd.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashopxd.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopxd.data[xacdinh_object].Gia;
                                shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashopxd.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashopxd.data[xacdinh_object].sl == GameManager.instance.datashopxd.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashopxd.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashopxd.data[xacdinh_object].Capmo += 5;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashopxd.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "Lo_pizza")
                        {
                            xacdinh_object = 8;
                            if (GameManager.instance.datashopxd.data[xacdinh_object].sl < GameManager.instance.datashopxd.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashopxd.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopxd.data[xacdinh_object].Gia;
                                shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashopxd.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashopxd.data[xacdinh_object].sl == GameManager.instance.datashopxd.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashopxd.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashopxd.data[xacdinh_object].Capmo += 5;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashopxd.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "May_matong")
                        {
                            xacdinh_object = 9;
                            if (GameManager.instance.datashopxd.data[xacdinh_object].sl < GameManager.instance.datashopxd.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashopxd.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopxd.data[xacdinh_object].Gia;
                                shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashopxd.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashopxd.data[xacdinh_object].sl == GameManager.instance.datashopxd.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashopxd.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashopxd.data[xacdinh_object].Capmo += 5;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashopxd.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "May_ephoa_qua")
                        {
                            xacdinh_object = 10;
                            if (GameManager.instance.datashopxd.data[xacdinh_object].sl < GameManager.instance.datashopxd.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashopxd.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopxd.data[xacdinh_object].Gia;
                                shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashopxd.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashopxd.data[xacdinh_object].sl == GameManager.instance.datashopxd.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashopxd.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashopxd.data[xacdinh_object].Capmo += 5;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashopxd.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "May_ruou")
                        {
                            xacdinh_object = 11;
                            if (GameManager.instance.datashopxd.data[xacdinh_object].sl < GameManager.instance.datashopxd.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashopxd.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopxd.data[xacdinh_object].Gia;
                                shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashopxd.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashopxd.data[xacdinh_object].sl == GameManager.instance.datashopxd.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashopxd.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashopxd.data[xacdinh_object].Capmo += 5;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashopxd.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }


                        else if (gameObject.name == "Chuong_ga")
                        {
                            xacdinh_object = 0;
                            if (GameManager.instance.datashopconvat.data[xacdinh_object].sl < GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashopconvat.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopconvat.data[xacdinh_object].Gia;
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashopconvat.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashopconvat.data[xacdinh_object].sl == GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashopconvat.data[xacdinh_object].Capmo += 5;
                                    shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();
                                    shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashopconvat.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "Chuong_bo")
                        {
                            xacdinh_object = 2;
                            if (GameManager.instance.datashopconvat.data[xacdinh_object].sl < GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashopconvat.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopconvat.data[xacdinh_object].Gia;
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashopconvat.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashopconvat.data[xacdinh_object].sl == GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashopconvat.data[xacdinh_object].Capmo += 5;

                                    shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();

                                    shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashopconvat.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "Chuong_lon")
                        {
                            xacdinh_object = 4;
                            if (GameManager.instance.datashopconvat.data[xacdinh_object].sl < GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashopconvat.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopconvat.data[xacdinh_object].Gia;
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashopconvat.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashopconvat.data[xacdinh_object].sl == GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashopconvat.data[xacdinh_object].Capmo += 5;

                                    shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();

                                    shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashopconvat.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "Chuong_cuu")
                        {
                            xacdinh_object = 6;
                            if (GameManager.instance.datashopconvat.data[xacdinh_object].sl < GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashopconvat.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopconvat.data[xacdinh_object].Gia;
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashopconvat.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashopconvat.data[xacdinh_object].sl == GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashopconvat.data[xacdinh_object].Capmo += 5;

                                    shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();

                                    shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashopconvat.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "Chuong_de")
                        {
                            xacdinh_object = 8;
                            if (GameManager.instance.datashopconvat.data[xacdinh_object].sl < GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashopconvat.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopconvat.data[xacdinh_object].Gia;
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashopconvat.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashopconvat.data[xacdinh_object].sl == GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashopconvat.data[xacdinh_object].Capmo += 5;

                                    shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();

                                    shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashopconvat.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "chuong_ngua")
                        {
                            xacdinh_object = 10;
                            if (GameManager.instance.datashopconvat.data[xacdinh_object].sl < GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashopconvat.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopconvat.data[xacdinh_object].Gia;
                                shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashopconvat.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashopconvat.data[xacdinh_object].sl == GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashopconvat.data[xacdinh_object].Capmo += 5;

                                    shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();

                                    shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashopconvat.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }


                        else if (gameObject.name == "Cay_cherry")
                        {
                            xacdinh_object = 0;
                            if (GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl < GameManager.instance.datashopcaylaunam.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopcaylaunam.data[xacdinh_object].Gia;
                                shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl == GameManager.instance.datashopcaylaunam.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashopcaylaunam.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashopcaylaunam.data[xacdinh_object].Capmo += 5;
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashopcaylaunam.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "Cay_cam")
                        {
                            xacdinh_object = 1;
                            if (GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl < GameManager.instance.datashopcaylaunam.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopcaylaunam.data[xacdinh_object].Gia;
                                shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl == GameManager.instance.datashopcaylaunam.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashopcaylaunam.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashopcaylaunam.data[xacdinh_object].Capmo += 5;
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashopcaylaunam.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "Cay_chanh")
                        {
                            xacdinh_object = 2;
                            if (GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl < GameManager.instance.datashopcaylaunam.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopcaylaunam.data[xacdinh_object].Gia;
                                shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl == GameManager.instance.datashopcaylaunam.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashopcaylaunam.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashopcaylaunam.data[xacdinh_object].Capmo += 5;
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashopcaylaunam.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "Cay_tao")
                        {
                            xacdinh_object = 3;
                            if (GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl < GameManager.instance.datashopcaylaunam.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopcaylaunam.data[xacdinh_object].Gia;
                                shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl == GameManager.instance.datashopcaylaunam.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashopcaylaunam.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashopcaylaunam.data[xacdinh_object].Capmo += 5;
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashopcaylaunam.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "Cay_anhdao")
                        {
                            xacdinh_object = 4;
                            if (GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl < GameManager.instance.datashopcaylaunam.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopcaylaunam.data[xacdinh_object].Gia;
                                shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl == GameManager.instance.datashopcaylaunam.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashopcaylaunam.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashopcaylaunam.data[xacdinh_object].Capmo += 5;
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashopcaylaunam.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "Cay_dieu")
                        {
                            xacdinh_object = 5;
                            if (GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl < GameManager.instance.datashopcaylaunam.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopcaylaunam.data[xacdinh_object].Gia;
                                shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl == GameManager.instance.datashopcaylaunam.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashopcaylaunam.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashopcaylaunam.data[xacdinh_object].Capmo += 5;
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashopcaylaunam.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "Cay_oliu")
                        {
                            xacdinh_object = 6;
                            if (GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl < GameManager.instance.datashopcaylaunam.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopcaylaunam.data[xacdinh_object].Gia;
                                shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl == GameManager.instance.datashopcaylaunam.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashopcaylaunam.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashopcaylaunam.data[xacdinh_object].Capmo += 5;
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashopcaylaunam.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "Cay_luu")
                        {
                            xacdinh_object = 7;
                            if (GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl < GameManager.instance.datashopcaylaunam.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopcaylaunam.data[xacdinh_object].Gia;
                                shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashopcaylaunam.data[xacdinh_object].sl == GameManager.instance.datashopcaylaunam.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashopcaylaunam.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashopcaylaunam.data[xacdinh_object].Capmo += 5;
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashopcaylaunam.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }

                        else if (gameObject.name == "Hom_thu")
                        {
                            xacdinh_object = 0;
                            if (GameManager.instance.datashoptrangtri.data[xacdinh_object].sl < GameManager.instance.datashoptrangtri.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashoptrangtri.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashoptrangtri.data[xacdinh_object].Gia;
                                shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashoptrangtri.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashoptrangtri.data[xacdinh_object].sl == GameManager.instance.datashoptrangtri.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashoptrangtri.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashoptrangtri.data[xacdinh_object].Capmo += 5;
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashoptrangtri.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "Den_tho")
                        {
                            xacdinh_object = 1;
                            if (GameManager.instance.datashoptrangtri.data[xacdinh_object].sl < GameManager.instance.datashoptrangtri.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashoptrangtri.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashoptrangtri.data[xacdinh_object].Gia;
                                shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashoptrangtri.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashoptrangtri.data[xacdinh_object].sl == GameManager.instance.datashoptrangtri.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashoptrangtri.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashoptrangtri.data[xacdinh_object].Capmo += 5;
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashoptrangtri.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "Bu_nhin")
                        {
                            xacdinh_object = 2;
                            if (GameManager.instance.datashoptrangtri.data[xacdinh_object].sl < GameManager.instance.datashoptrangtri.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashoptrangtri.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashoptrangtri.data[xacdinh_object].Gia;
                                shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashoptrangtri.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashoptrangtri.data[xacdinh_object].sl == GameManager.instance.datashoptrangtri.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashoptrangtri.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashoptrangtri.data[xacdinh_object].Capmo += 5;
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashoptrangtri.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "Hoa_cuc")
                        {
                            xacdinh_object = 3;
                            if (GameManager.instance.datashoptrangtri.data[xacdinh_object].sl < GameManager.instance.datashoptrangtri.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashoptrangtri.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashoptrangtri.data[xacdinh_object].Gia;
                                shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashoptrangtri.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashoptrangtri.data[xacdinh_object].sl == GameManager.instance.datashoptrangtri.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashoptrangtri.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashoptrangtri.data[xacdinh_object].Capmo += 5;
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashoptrangtri.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "Hoa_dongtien")
                        {
                            xacdinh_object = 4;
                            if (GameManager.instance.datashoptrangtri.data[xacdinh_object].sl < GameManager.instance.datashoptrangtri.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashoptrangtri.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashoptrangtri.data[xacdinh_object].Gia;
                                shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashoptrangtri.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashoptrangtri.data[xacdinh_object].sl == GameManager.instance.datashoptrangtri.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashoptrangtri.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashoptrangtri.data[xacdinh_object].Capmo += 5;
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashoptrangtri.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "Ghe_go")
                        {
                            xacdinh_object = 5;
                            if (GameManager.instance.datashoptrangtri.data[xacdinh_object].sl < GameManager.instance.datashoptrangtri.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashoptrangtri.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashoptrangtri.data[xacdinh_object].Gia;
                                shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashoptrangtri.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashoptrangtri.data[xacdinh_object].sl == GameManager.instance.datashoptrangtri.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashoptrangtri.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashoptrangtri.data[xacdinh_object].Capmo += 5;
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashoptrangtri.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "Ghe_sat")
                        {
                            xacdinh_object = 6;
                            if (GameManager.instance.datashoptrangtri.data[xacdinh_object].sl < GameManager.instance.datashoptrangtri.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashoptrangtri.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashoptrangtri.data[xacdinh_object].Gia;
                                shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashoptrangtri.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashoptrangtri.data[xacdinh_object].sl == GameManager.instance.datashoptrangtri.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashoptrangtri.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashoptrangtri.data[xacdinh_object].Capmo += 5;
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashoptrangtri.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "Ghe_satvin")
                        {
                            xacdinh_object = 7;
                            if (GameManager.instance.datashoptrangtri.data[xacdinh_object].sl < GameManager.instance.datashoptrangtri.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashoptrangtri.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashoptrangtri.data[xacdinh_object].Gia;
                                shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashoptrangtri.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashoptrangtri.data[xacdinh_object].sl == GameManager.instance.datashoptrangtri.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashoptrangtri.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashoptrangtri.data[xacdinh_object].Capmo += 5;
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashoptrangtri.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "Meo_thantai_trang")
                        {
                            xacdinh_object = 8;
                            if (GameManager.instance.datashoptrangtri.data[xacdinh_object].sl < GameManager.instance.datashoptrangtri.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashoptrangtri.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashoptrangtri.data[xacdinh_object].Gia;
                                shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashoptrangtri.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashoptrangtri.data[xacdinh_object].sl == GameManager.instance.datashoptrangtri.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashoptrangtri.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashoptrangtri.data[xacdinh_object].Capmo += 5;
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashoptrangtri.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }
                        else if (gameObject.name == "Meo_thantai_vang")
                        {
                            xacdinh_object = 9;
                            if (GameManager.instance.datashoptrangtri.data[xacdinh_object].sl < GameManager.instance.datashoptrangtri.data[xacdinh_object].GioiHan)
                            {
                                gan(TD_X, TD_Y, 1, ID);
                                GameManager.instance.datashoptrangtri.data[xacdinh_object].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashoptrangtri.data[xacdinh_object].Gia;
                                shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                                    GameManager.instance.datashoptrangtri.data[xacdinh_object].sl.ToString();
                                if (GameManager.instance.datashoptrangtri.data[xacdinh_object].sl == GameManager.instance.datashoptrangtri.data[xacdinh_object].GioiHan)
                                {
                                    khoa = false;
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(0).gameObject.SetActive(false);
                                    GameManager.instance.datashoptrangtri.data[xacdinh_object].GioiHan++;
                                    GameManager.instance.datashoptrangtri.data[xacdinh_object].Capmo += 5;
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                        (GameManager.instance.datashopconvat.data[xacdinh_object].GioiHan - 1).ToString();
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetChild(0).gameObject.SetActive(false);
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mở khóa ở cấp "
                                        + GameManager.instance.datashoptrangtri.data[xacdinh_object].Capmo;
                                    shop.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(xacdinh_object).GetChild(3).GetComponent<TextMeshProUGUI>().fontSize = 15;
                                }
                            }
                        }

                        xacdinh_object = 0;
                    }
                    else
                    {
                        Destroy(obj);
                    }

                    kc = Mathf.Abs(obj.transform.position.y - doituong_dexacdinh_layer.transform.position.y) * 10;
                    obj.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = (int)kc;
                    /*if (odat)
                    {
                        obj.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = (int)kc;
                        obj.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = (int)kc+1;
                        obj.transform.GetChild(0).GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = (int)kc+1;
                    }*/
                    if (cayanqua)
                    {
                        obj.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = (int)kc;
                        for (int i = 0; i < 2; i++)
                        {
                            obj.transform.GetChild(i).GetComponent<SpriteRenderer>().sortingOrder= (int)kc + 1;
                        }
                        obj.transform.GetChild(0).GetComponent<cayanqua>().phattrien_new(obj.transform.GetChild(0).GetComponent<cayanqua>().id,
                            obj.transform.GetChild(0).GetComponent<cayanqua>().timeCaylon1, 
                            obj.transform.GetChild(0).GetComponent<cayanqua>().timeCaylon2);
                    }
                    /*if (nhamay)
                    {
                        obj.transform.GetComponent<SpriteRenderer>().sortingOrder = (int)kc;
                        for (int i = 0; i < obj.transform.childCount; i++)
                        {
                            obj.transform.GetChild(i).GetComponent<SpriteRenderer>().sortingOrder = (int)kc + 1;
                        }
                    }*/
                    else
                    {
                        for (int i = 0; i < obj.transform.childCount; i++)
                        {
                            obj.transform.GetChild(i).GetComponent<SpriteRenderer>().sortingOrder = (int)kc + 1;
                            if (chuong)
                            {
                                obj.transform.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = (int)kc + 2;
                                for (int j = 1; j < obj.transform.GetChild(i).childCount; j++)
                                {
                                    obj.transform.GetChild(i).GetChild(j).GetComponent<MeshRenderer>().sortingOrder = (int)kc + 2;
                                }
                            }
                            else
                            {
                                for (int j = 0; j < obj.transform.GetChild(i).childCount; j++)
                                {
                                    obj.transform.GetChild(i).GetChild(j).GetComponent<SpriteRenderer>().sortingOrder = (int)kc + 2;
                                }
                            }

                        }
                    }
                    
                }
            }
        }
        shop.transform.position = vt;
        nen.SetActive(true);
        ondrag = false;
    }

    public void Set_ToaDo(int gt, GameObject obj, int id)
    {
        x_toado = obj.transform.position.x - Grid.transform.position.x;
        y_toado = obj.transform.position.y - Grid.transform.position.y;

        TG1 = Mathf.Abs(Grid.transform.GetChild(0).position.x - obj.transform.position.x);
        TG2 = Mathf.Abs(Grid.transform.GetChild(0).position.y - obj.transform.position.y);

        Check_Vitri(gt, TG1, TG2, x_toado, y_toado, obj, id);

    }

    public void Check_Vitri(int gt, float TG1, float TG2, float toado_x, float toado_y, GameObject obj, int id)
    {
        // x
        {
            if (TG1 == System.Math.Truncate(TG1) + 0.5f)
            {
                TG1 = (float)System.Math.Truncate(TG1) + 1f;
            }
            else if (TG1 == System.Math.Truncate(TG1))
            {
                TG1 = (float)System.Math.Truncate(TG1);
            }
        }

        // y
        {
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

        }

        if (toado_y > 0)
        {
            if (toado_x == (float)System.Math.Truncate(toado_x))
            {
                TD_X = (int)(TG1 - TG2 + 1);
                TD_Y = (int)(TG1 + TG2);
            }
            else if (toado_x == (float)System.Math.Truncate(toado_x) + 0.5f)
            {
                TD_X = (int)(TG1 - TG2);
                TD_Y = (int)(TG1 + TG2);
            }
        }
        else if (toado_y < 0)
        {
            if (toado_x == (float)System.Math.Truncate(toado_x))
            {
                TD_Y = (int)(TG1 - TG2 + 1);
                TD_X = (int)(TG1 + TG2);
            }
            else if (toado_x == (float)System.Math.Truncate(toado_x) + 0.5f)
            {
                TD_Y = (int)(TG1 - TG2);
                TD_X = (int)(TG1 + TG2);
            }
        }
        else if (toado_y == 0)
        {
            TD_X = (int)TG1;
            TD_Y = (int)TG1;
        }

        if (kiemtra(TD_X, TD_Y, id))
        {
            obj.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
        else
        {
            //sau nhét một cái UI thông báo không đủ chỗ chứa
            obj.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color32(205, 11, 11, 255);
            //Debug.Log("không đủ chỗ chứa");
        }
    }

    public void gan(int x, int y, int gt, int id/*, GameObject obj*/)
    {
        if (id==0)
        {
            for (int i = x; i >= x - 1; i--)
            {
                for (int j = y; j <= y + 1; j++)
                {
                    Grid.transform.GetChild(0).GetComponent<Tilemap>().tilemap[i, j] = gt;
                }
            }
        }
        else if (id == 1)
        {
            for (int i = x; i >= x - 3; i--)
            {
                for (int j = y; j <= y + 2; j++)
                {
                    Grid.transform.GetChild(0).GetComponent<Tilemap>().tilemap[i, j] = gt;
                }
            }
        }
        else if (id == 2)
        {
            for (int i = x; i >= x - 2; i--)
            {
                for (int j = y; j <= y + 3; j++)
                {
                    Grid.transform.GetChild(0).GetComponent<Tilemap>().tilemap[i, j] = gt;
                }
            }
        }
        else if (id == 3)
        {
            for (int i = x; i >= x - 3; i--)
            {
                for (int j = y; j <= y + 3; j++)
                {
                    Grid.transform.GetChild(0).GetComponent<Tilemap>().tilemap[i, j] = gt;
                }
            }
        }
        else if (id == 4)
        {
            for (int i = x; i >= x - 4; i--)
            {
                for (int j = y; j <= y + 4; j++)
                {
                    Grid.transform.GetChild(0).GetComponent<Tilemap>().tilemap[i, j] = gt;
                }
            }
        }
        else if (id == 5)
        {
            Grid.transform.GetChild(0).GetComponent<Tilemap>().tilemap[TD_X, TD_Y] = gt;
        }
        else if (id == 6)
        {
            for (int i = x; i >= x - 1; i--)
            {
                Grid.transform.GetChild(0).GetComponent<Tilemap>().tilemap[i, TD_Y] = gt;
            }
        }

    }

    bool kiemtra(int TD_X, int TD_Y, int id)
    {
        int dem = 0;
        if (id==0)
        {
            for (int i = TD_X; i >= TD_X - 1; i--)
            {
                for (int j = TD_Y; j <= TD_Y + 1; j++)
                {
                    if (Grid.transform.GetChild(0).GetComponent<Tilemap>().tilemap[i, j] != 0)
                    {
                        dem++;
                    }
                }
            }
        }
        else if (id == 1)
        {
            for (int i = TD_X; i >= TD_X - 3; i--)
            {
                for (int j = TD_Y; j <= TD_Y + 2; j++)
                {
                    if (Grid.transform.GetChild(0).GetComponent<Tilemap>().tilemap[i, j] != 0)
                    {
                        dem++;
                    }
                }
            }
        }
        else if (id == 2)
        {
            for (int i = TD_X; i >= TD_X - 2; i--)
            {
                for (int j = TD_Y; j <= TD_Y + 3; j++)
                {
                    if (Grid.transform.GetChild(0).GetComponent<Tilemap>().tilemap[i, j] != 0)
                    {
                        dem++;
                    }
                }
            }
        }
        else if (id == 3)
        {
            for (int i = TD_X; i >= TD_X - 3; i--)
            {
                for (int j = TD_Y; j <= TD_Y + 3; j++)
                {
                    if (Grid.transform.GetChild(0).GetComponent<Tilemap>().tilemap[i, j] != 0)
                    {
                        dem++;
                    }
                }
            }
        }
        else if (id == 4)
        {
            for (int i = TD_X; i >= TD_X - 4; i--)
            {
                for (int j = TD_Y; j <= TD_Y + 4; j++)
                {
                    if (Grid.transform.GetChild(0).GetComponent<Tilemap>().tilemap[i, j] != 0)
                    {
                        dem++;
                    }
                }
            }
        }
        else if (id == 5)
        {
            if (Grid.transform.GetChild(0).GetComponent<Tilemap>().tilemap[TD_X, TD_Y] != 0)
            {
                dem++;
            }
        }
        else if (id == 6)
        {
            for (int i = TD_X; i >= TD_X - 1; i--)
            {
                if (Grid.transform.GetChild(0).GetComponent<Tilemap>().tilemap[i, TD_Y] != 0)
                {
                    dem++;
                }
            }
        }






        if (dem != 0)
        {
            return false;
        }
        return true;

    }

    // Phần thưởng
}
