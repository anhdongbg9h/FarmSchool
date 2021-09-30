using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_chuong : MonoBehaviour, IInteractable
{
    public int id_cv;
    private void OnMouseDown()
    {
        GameManager.instance.dayCanvas_rangoai();
        GameManager.instance.canvasga.GetComponent<VatNuoiPopUp>().doianh(id_cv);
        GameManager.instance.canvasga.transform.position = transform.position + new Vector3(-0.7f, 0.8f, 0);
    }
    public void ShowSeedUI()
    {

    }

}
