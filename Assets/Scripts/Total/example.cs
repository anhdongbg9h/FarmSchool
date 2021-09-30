using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using BitBenderGames;
public class example : MonoBehaviour,IPointerDownHandler,IDragHandler,IPointerUpHandler
{
   
    public int id;
    public GameObject[] ob;
    [HideInInspector] public GameObject obj;

    public void OnPointerDown(PointerEventData eventData)
    {
        TouchInputController.instance.isDragging = true; // khoa camera
        obj = Instantiate(ob[id], Camera.main.ScreenToWorldPoint(Input.mousePosition),
            Quaternion.identity);
    }

    public void OnDrag(PointerEventData eventData)
    {
        obj.transform.position =new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y,0);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        TouchInputController.instance.isDragging = false;
        Destroy(obj);
        GameManager.instance.dayCanvas_rangoai();
    }
}
