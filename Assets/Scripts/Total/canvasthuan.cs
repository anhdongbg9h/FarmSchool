using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using BitBenderGames;
public class cavansthuan : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    //set object and prefabs
    public GameObject ob;
    GameObject obj;

    public void OnDrag(PointerEventData eventData)
    {
        //ob= GameManager.instance.dataVatNuoi.data[id].
        obj.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        TouchInputController.instance.isDragging = true; // khoa camera
        obj = Instantiate(ob, Camera.main.ScreenToWorldPoint(Input.mousePosition),
            Quaternion.identity);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        TouchInputController.instance.isDragging = false;
        Destroy(obj);
    }


}
