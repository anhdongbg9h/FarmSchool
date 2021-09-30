using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chuongga : MonoBehaviour,IInteractable
{
    public int idCage;
    //Vector3 vt;
    //private bool thuhoach;

    public void ChuongGaUIClick()
    {
        GameManager.instance.canvasga.transform.position= transform.position + new Vector3(-0.7f, 0.4f, 0);
    }

    private void OnMouseDown()
    {
        ChuongGaUIClick();
    }

    public void ShowSeedUI()
    {
        
    }
}
