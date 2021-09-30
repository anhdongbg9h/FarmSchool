using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_to_move : MonoBehaviour
{
    public GameObject Order_UI;
    public GameObject Canvas;
    public GameObject Panel_order_donhang;
    public GameObject poit1, poit2;



    public int Id;
    int dem;


    public void Click_btn_ok()
    {
        Order_UI.SetActive(false);
        Canvas.SetActive(false);

        dem = 0;

        // đếm số phần tử được duyệt (số đơn)
        for (int i = 2; i < Panel_order_donhang.transform.childCount; i++)
        {
            if (Panel_order_donhang.transform.GetChild(i).gameObject.activeSelf == true)
            {
                dem++;
            }
        }
        // cập nhật vàng và kinh nghiệm
        for (int i = 0; i < dem; i++)
        {
            if (Panel_order_donhang.transform.GetChild(i + 2).GetComponent<Click_donhang>().Id_donhang == Id
                && Panel_order_donhang.transform.GetChild(i + 2).GetComponent<Click_donhang>().Check == true
                && Panel_order_donhang.transform.GetChild(i + 2).GetComponent<Click_donhang>().Sell == true
                && Panel_order_donhang.transform.GetChild(i + 2).GetChild(0).gameObject.activeSelf == false)
            {
                GameManager.instance.dataui.data[0].giatri +=
                    Panel_order_donhang.transform.GetChild(i + 2).GetComponent<Click_donhang>().vang;
                GameManager.instance.datanhachinh.data[GameManager.instance.dataui.data[2].giatri - 1].KinhNghiem +=
                    Panel_order_donhang.transform.GetChild(i + 2).GetComponent<Click_donhang>().kn;
                Panel_order_donhang.transform.GetChild(i + 2).GetComponent<Click_donhang>().
                    Update_SL_in_kho(Panel_order_donhang.transform.GetChild(i + 2).GetComponent<Click_donhang>().t);
                Panel_order_donhang.transform.GetChild(i + 2).GetComponent<Click_donhang>().Start();

                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
                StartCoroutine(xuatphat(transform.GetChild(1).gameObject, transform.GetChild(0).position, poit1.transform.position));
            }
        }
    }

    IEnumerator xuatphat(GameObject obj, Vector3 diembatdau, Vector3 diemden)
    {
        move_xehang(obj, diemden);
        yield return new WaitForSeconds(0.1f * Time.deltaTime);
        if(diemden == poit1.transform.position)
        {
            if(obj.transform.position != diemden)
            {
                StartCoroutine(xuatphat(obj, diembatdau, diemden));
            }
            else
            {
                obj.SetActive(false);
                obj.transform.position = diembatdau;
                transform.GetChild(2).gameObject.SetActive(true);
                StartCoroutine(xuatphat(transform.GetChild(2).gameObject, poit2.transform.position, transform.GetChild(0).position));
            }
        }
        else if(diemden == transform.GetChild(0).position)
        {
            if (obj.transform.position != diemden)
            {
                StartCoroutine(xuatphat(obj, diembatdau, diemden));
            }
            else
            {
                obj.transform.position = diemden;
            }
        }
    }
    private void move_xehang(GameObject obj, Vector3 diemden)
    {
        obj.transform.position = Vector3.MoveTowards(obj.transform.position, diemden, 0.1f);
    }

}
