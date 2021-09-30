using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class btnxoay_chuyen_canvas : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject canvas;
    bool click = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (GameManager.instance.dataui.data[2].giatri == 8 && click ==false)
        {
            click = true;
            Debug.Log("cấp 8 - 0");
            for (int i = 1; i <= 9; i++)
            {
                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(i).gameObject.SetActive(false);
            }
            for (int i = 10; i < 13; i++)
            {
                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(i).gameObject.SetActive(true);
            }
            GameManager.instance.dialogHG.transform.GetChild(4).GetChild(10).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    GameManager.instance.dataNongSan.data[11].sanluong.ToString();
            GameManager.instance.dialogHG.transform.GetChild(4).GetChild(11).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                GameManager.instance.dataNongSan.data[17].sanluong.ToString();
            GameManager.instance.dialogHG.transform.GetChild(4).GetChild(12).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                GameManager.instance.dataNongSan.data[10].sanluong.ToString();
        }
        else if (GameManager.instance.dataui.data[2].giatri == 8)
        {
            Debug.Log("cấp 8 - 1");
            for (int i = 10; i < 13; i++)
            {
                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(i).gameObject.SetActive(false);
            }
            for (int i = 1; i <= 9; i++)
            {
                GameManager.instance.dialogHG.transform.GetChild(4).GetChild(i).gameObject.SetActive(true);
            }
            GameManager.instance.dialogHG.transform.GetChild(4).GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                GameManager.instance.dataNongSan.data[12].sanluong.ToString();
            GameManager.instance.dialogHG.transform.GetChild(4).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                GameManager.instance.dataNongSan.data[14].sanluong.ToString();
            GameManager.instance.dialogHG.transform.GetChild(4).GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                GameManager.instance.dataNongSan.data[3].sanluong.ToString();
            GameManager.instance.dialogHG.transform.GetChild(4).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                GameManager.instance.dataNongSan.data[6].sanluong.ToString();
            GameManager.instance.dialogHG.transform.GetChild(4).GetChild(5).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                GameManager.instance.dataNongSan.data[9].sanluong.ToString();
            GameManager.instance.dialogHG.transform.GetChild(4).GetChild(6).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                GameManager.instance.dataNongSan.data[5].sanluong.ToString();
            GameManager.instance.dialogHG.transform.GetChild(4).GetChild(7).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                GameManager.instance.dataNongSan.data[13].sanluong.ToString();
            GameManager.instance.dialogHG.transform.GetChild(4).GetChild(8).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                GameManager.instance.dataNongSan.data[16].sanluong.ToString();
            GameManager.instance.dialogHG.transform.GetChild(4).GetChild(9).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                GameManager.instance.dataNongSan.data[15].sanluong.ToString();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
