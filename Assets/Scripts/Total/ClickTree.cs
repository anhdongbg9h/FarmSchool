using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickTree : MonoBehaviour, IInteractable
{
    public static ClickTree instance;
    public bool xacdinh = false;

    private void Awake()
    {
        instance = this;
    }

    private void OnMouseDown()
    {
        xacdinh = true;
        GameManager.instance.dayCanvas_rangoai();
        Show_canvas();
        GameManager.instance.canvasChatcay.transform.position= transform.position + new Vector3(-0.6f, 1.3f, 0);
    }
    public void ShowSeedUI()
    {

    }

    private void Show_canvas()
    {
        GameManager.instance.canvasChatcay.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = 
            GameManager.instance.dataSPCheBien.data[60].sanluong.ToString();
    }
}
