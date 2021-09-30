using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VatNuoiPopUp : MonoBehaviour
{
    //[SerializeField] private example example;
    [SerializeField] Image thuhoach;
    [SerializeField] Image thucan;
    private int id;
   
    public void doianh(int id)
    {
        thuhoach.sprite = GameManager.instance.dataVatNuoi.data[id].thuhoach;
        thucan.sprite = GameManager.instance.dataVatNuoi.data[id].thuan;
        thucan.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = GameManager.instance.dataSPCheBien.data[id].sanluong.ToString();
        transform.GetChild(1).GetComponent<example>().id = id;
        transform.GetChild(2).GetComponent<example>().id = id;
    }

    private void OnBecameVisible()
    {
        
    }

    private void OnBecameInvisible()
    {
        
    }
}
