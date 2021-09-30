using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AddBongBong_Scripts : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int so;

    public GameObject canvas;
    public void OnPointerDown(PointerEventData eventData)
    {
        //canvas = GameManager.instance.CanvasSXthuanconvat;
        if (GetComponent<Image>().sprite == GameManager.instance.dataicon.data[0].icon)
        {
            GameManager.instance.nmSX.transform.GetChild(so).gameObject.SetActive(true);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        SanXuatSP.instance.Update_Sp_NhaMay();
        canvas.transform.position = new Vector3(999f, 999f, 0);
        //StartCoroutine(Delay_Click());
    }

    IEnumerator Delay_Click()
    {
        yield return new WaitForSeconds(0.01f * Time.deltaTime);
        canvas.transform.position = canvas.GetComponent<Save_vitrinhamay>().vitrinhamay + new Vector3(-0.6f, 0.5f, 0);
    }
}
