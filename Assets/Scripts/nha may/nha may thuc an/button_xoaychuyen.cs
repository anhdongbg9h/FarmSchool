using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button_xoaychuyen : MonoBehaviour
{
    private GameObject obj;
    private GameObject obj1;
    private GameObject obj2;

    int dem=0;
    private void OnMouseDown()
    {
        dem++;
        if (dem % 2 == 0)
        {
            obj = GameManager.instance.CanvasSXthuanconvat.transform.GetChild(2).GetComponent<example>().ob[0];
            GameManager.instance.CanvasSXthuanconvat.transform.GetChild(2).GetComponent<example>().ob[0] =
                GameManager.instance.CanvasSXthuanconvat.transform.GetChild(2).GetComponent<example>().ob[1];
            GameManager.instance.CanvasSXthuanconvat.transform.GetChild(2).GetComponent<example>().ob[1] = obj;
            GameManager.instance.CanvasSXthuanconvat.transform.GetChild(2).GetComponent<Image>().sprite =
                GameManager.instance.dataVatNuoi.data[0].thuan;


            obj1 = GameManager.instance.CanvasSXthuanconvat.transform.GetChild(3).GetComponent<example>().ob[0];
            GameManager.instance.CanvasSXthuanconvat.transform.GetChild(3).GetComponent<example>().ob[0] =
               GameManager.instance.CanvasSXthuanconvat.transform.GetChild(3).GetComponent<example>().ob[1];
            GameManager.instance.CanvasSXthuanconvat.transform.GetChild(3).GetComponent<example>().ob[1] = obj1;
            GameManager.instance.CanvasSXthuanconvat.transform.GetChild(3).GetComponent<Image>().sprite =
                GameManager.instance.dataVatNuoi.data[1].thuan;

            obj2 = GameManager.instance.CanvasSXthuanconvat.transform.GetChild(4).GetComponent<example>().ob[0];
            GameManager.instance.CanvasSXthuanconvat.transform.GetChild(4).GetComponent<example>().ob[0] =
               GameManager.instance.CanvasSXthuanconvat.transform.GetChild(4).GetComponent<example>().ob[1];
            GameManager.instance.CanvasSXthuanconvat.transform.GetChild(4).GetComponent<example>().ob[1] = obj2;
            GameManager.instance.CanvasSXthuanconvat.transform.GetChild(4).GetComponent<Image>().sprite =
                GameManager.instance.dataVatNuoi.data[2].thuan;
        }
        else
        {
            // chuyển đổi thành phần thức ăn (swap)
            obj = GameManager.instance.CanvasSXthuanconvat.transform.GetChild(2).GetComponent<example>().ob[0];
            GameManager.instance.CanvasSXthuanconvat.transform.GetChild(2).GetComponent<example>().ob[0] =
                GameManager.instance.CanvasSXthuanconvat.transform.GetChild(2).GetComponent<example>().ob[1];
            GameManager.instance.CanvasSXthuanconvat.transform.GetChild(2).GetComponent<example>().ob[1] = obj;
            // chuyển đổi hình ảnh của thức ăn
            GameManager.instance.CanvasSXthuanconvat.transform.GetChild(2).GetComponent<Image>().sprite =
                GameManager.instance.dataVatNuoi.data[3].thuan;

            obj1 = GameManager.instance.CanvasSXthuanconvat.transform.GetChild(3).GetComponent<example>().ob[0];
            GameManager.instance.CanvasSXthuanconvat.transform.GetChild(3).GetComponent<example>().ob[0] =
               GameManager.instance.CanvasSXthuanconvat.transform.GetChild(3).GetComponent<example>().ob[1];
            GameManager.instance.CanvasSXthuanconvat.transform.GetChild(3).GetComponent<example>().ob[1] = obj1;
            GameManager.instance.CanvasSXthuanconvat.transform.GetChild(3).GetComponent<Image>().sprite =
                GameManager.instance.dataVatNuoi.data[4].thuan;

            obj2 = GameManager.instance.CanvasSXthuanconvat.transform.GetChild(4).GetComponent<example>().ob[0];
            GameManager.instance.CanvasSXthuanconvat.transform.GetChild(4).GetComponent<example>().ob[0] =
               GameManager.instance.CanvasSXthuanconvat.transform.GetChild(4).GetComponent<example>().ob[1];
            GameManager.instance.CanvasSXthuanconvat.transform.GetChild(4).GetComponent<example>().ob[1] = obj2;
            GameManager.instance.CanvasSXthuanconvat.transform.GetChild(4).GetComponent<Image>().sprite =
                GameManager.instance.dataVatNuoi.data[5].thuan;
        }
        if(dem==2)
        {
            dem = 0;
        }
    }
}
