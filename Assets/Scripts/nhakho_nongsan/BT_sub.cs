using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class BT_sub : MonoBehaviour,IPointerDownHandler
{
    public GameObject canvas;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.CompareTag("BT_add"))
        {
            if (canvas.transform.GetChild(0).GetChild(0).GetChild(canvas.GetComponent<instaceCanvas>().id).GetComponent<Click_into_chua_sp>().coso<GameManager.instance.dataNongSan.data[nhakho_nongsan.instance.mang[canvas.transform.GetComponent<instaceCanvas>().id]].sanluong)
            {
                canvas.transform.GetChild(0).GetChild(0).GetChild(canvas.GetComponent<instaceCanvas>().id).GetComponent<Click_into_chua_sp>().coso++;
                canvas.transform.GetChild(0).GetChild(0).GetChild(canvas.GetComponent<instaceCanvas>().id).GetComponent<Click_into_chua_sp>().update_canvas_thongtin_hat(canvas.GetComponent<instaceCanvas>().id);
                //canvas.GetComponent<instaceCanvas>().id
                canvas.transform.GetChild(4).GetChild(6).GetComponent<TextMeshProUGUI>().text =
                    (canvas.transform.GetChild(0).GetChild(0).GetChild(canvas.GetComponent<instaceCanvas>().id).GetComponent<Click_into_chua_sp>().coso * GameManager.instance.dataNongSan.data[nhakho_nongsan.instance.mang[canvas.transform.GetComponent<instaceCanvas>().id]].giaban).ToString();
            }
        }

        else if (gameObject.CompareTag("BT_sub"))
        {
            if (canvas.transform.GetChild(0).GetChild(0).GetChild(canvas.GetComponent<instaceCanvas>().id).GetComponent<Click_into_chua_sp>().coso>1)
            {
                canvas.transform.GetChild(0).GetChild(0).GetChild(canvas.GetComponent<instaceCanvas>().id).GetComponent<Click_into_chua_sp>().coso--;
                canvas.transform.GetChild(0).GetChild(0).GetChild(canvas.GetComponent<instaceCanvas>().id).GetComponent<Click_into_chua_sp>().update_canvas_thongtin_hat(canvas.GetComponent<instaceCanvas>().id);
                canvas.transform.GetChild(4).GetChild(6).GetComponent<TextMeshProUGUI>().text =
                    (canvas.transform.GetChild(0).GetChild(0).GetChild(canvas.GetComponent<instaceCanvas>().id).GetComponent<Click_into_chua_sp>().coso * GameManager.instance.dataNongSan.data[nhakho_nongsan.instance.mang[canvas.transform.GetComponent<instaceCanvas>().id]].giaban).ToString();
            }
        }
    }
}
