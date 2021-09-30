using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BTxoaychuyen : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{
    public GameObject canvas;
    public void OnPointerDown(PointerEventData eventData)
    {
        for(int i = 0; i < canvas.transform.GetChild(1).childCount; i++)
        {
            if(canvas.transform.GetChild(1).GetChild(i).gameObject.activeSelf == true)
            {
                canvas.transform.GetChild(1).GetChild(i).gameObject.SetActive(false);
            }
            else if(canvas.transform.GetChild(1).GetChild(i).gameObject.activeSelf == false)
            {
                canvas.transform.GetChild(1).GetChild(i).gameObject.SetActive(true);
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StartCoroutine(Delay_Click());
    }
    IEnumerator Delay_Click()
    {
        yield return new WaitForSeconds(0.01f * Time.deltaTime);
        canvas.transform.position = canvas.GetComponent<Save_vitrinhamay>().vitrinhamay + new Vector3(-0.6f, 0.5f, 0);
    }
}
