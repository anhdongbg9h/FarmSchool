using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using BitBenderGames;

public class Cell_convat : MonoBehaviour, IPointerDownHandler,IPointerUpHandler, IDragHandler
{
    Sinhra_gameobject sinhra;


    public int id;
    public GameObject[] ob;
    [HideInInspector] public GameObject obj;

    private void Start()
    {
        sinhra = GetComponent<Sinhra_gameobject>();/*
        sinhra.enabled = false;*/
    }


    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("fffffffffffffffffffffffff");
        sinhra.enabled = false;
        obj.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown in Cell_convat");
        sinhra.enabled = false;
        TouchInputController.instance.isDragging = true; // khoa camera
        obj = Instantiate(ob[id], Camera.main.ScreenToWorldPoint(Input.mousePosition),
            Quaternion.identity);
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        sinhra.enabled = true;
        TouchInputController.instance.isDragging = false;
        Destroy(obj);
    }

/*    private void OnTriggerEnter2D(Collider2D collision)
    {
        *//*if (collision.gameObject.CompareTag("chuongga"))
        {
            *//*if (gameObject.tag=="conga")
            {

                
            }*//*
            if (collision.gameObject.transform.GetChild(1).gameObject.activeSelf == false)
            {
                collision.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                if (collision.gameObject.transform.GetChild(2).gameObject.activeSelf == false)
                {
                    collision.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                }
                else
                {
                    if (collision.gameObject.transform.GetChild(3).gameObject.activeSelf == false)
                    {
                        collision.gameObject.transform.GetChild(3).gameObject.SetActive(true);
                    }
                }
            }

            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }*//*
    }
*/}
