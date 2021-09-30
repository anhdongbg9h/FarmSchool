using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThuHoachConVat : MonoBehaviour
{
    [SerializeField] private GameObject iconFly;
    [SerializeField] private GameObject iconFlykinhnghiem;
    public int id;
    //private bool th = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "conga")
        {
            if (collision.gameObject.GetComponent<VatNuoi>().th == true && tag == "thuhoachga")
            {
                GameObject ob = Instantiate(iconFly, transform.position, Quaternion.identity);
                GameObject obj = Instantiate(iconFlykinhnghiem, transform.position, Quaternion.identity);
                ob.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite =
                    GameManager.instance.dataVatNuoi.data[id].iconsanpham;
                collision.gameObject.GetComponent<VatNuoi>().ske.AnimationName = "stand 2";
                collision.gameObject.GetComponent<VatNuoi>().th = false;
                GameManager.instance.dataVatNuoi.data[0].sl_sanpham++;
                GameManager.instance.datanhachinh.data[GameManager.instance.dataui.data[2].giatri - 1].KinhNghiem +=
                    GameManager.instance.dataVatNuoi.data[0].exp;
            }

        }
        if (collision.gameObject.tag == "conngua")
        {
            if (collision.gameObject.GetComponent<VatNuoi>().th == true && tag == "thuhoachngua")
            {
                GameObject ob = Instantiate(iconFly, transform.position, Quaternion.identity);
                GameObject obj = Instantiate(iconFlykinhnghiem, transform.position, Quaternion.identity);
                ob.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite =
                    GameManager.instance.dataVatNuoi.data[id].iconsanpham;
                collision.gameObject.GetComponent<VatNuoi>().ske.AnimationName = "stand 2";
                collision.gameObject.GetComponent<VatNuoi>().th = false;
                GameManager.instance.dataVatNuoi.data[1].sl_sanpham++;
                GameManager.instance.datanhachinh.data[GameManager.instance.dataui.data[2].giatri - 1].KinhNghiem +=
                    GameManager.instance.dataVatNuoi.data[1].exp;
            }

        }
        if (collision.gameObject.tag == "conlon")
        {
            
            if (collision.gameObject.GetComponent<VatNuoi>().th == true && tag == "thuhoachlon")
            {
                GameObject ob = Instantiate(iconFly, transform.position, Quaternion.identity);
                GameObject obj = Instantiate(iconFlykinhnghiem, transform.position, Quaternion.identity);
                ob.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite =
                    GameManager.instance.dataVatNuoi.data[id].iconsanpham;
                collision.gameObject.GetComponent<VatNuoi>().ske.AnimationName = "stand 2";
                collision.gameObject.GetComponent<VatNuoi>().th = false;
                GameManager.instance.dataVatNuoi.data[2].sl_sanpham++;
                GameManager.instance.datanhachinh.data[GameManager.instance.dataui.data[2].giatri - 1].KinhNghiem +=
                    GameManager.instance.dataVatNuoi.data[2].exp;
            }

        }
        if (collision.gameObject.tag == "conbo")
        {

            if (collision.gameObject.GetComponent<VatNuoi>().th == true && tag == "thuhoachbo")
            {
                GameObject ob = Instantiate(iconFly, transform.position, Quaternion.identity);
                GameObject obj = Instantiate(iconFlykinhnghiem, transform.position, Quaternion.identity);
                ob.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite =
                    GameManager.instance.dataVatNuoi.data[id].iconsanpham;
                collision.gameObject.GetComponent<VatNuoi>().ske.AnimationName = "stand 2";
                collision.gameObject.GetComponent<VatNuoi>().th = false;
                GameManager.instance.dataVatNuoi.data[3].sl_sanpham++;
                GameManager.instance.datanhachinh.data[GameManager.instance.dataui.data[2].giatri - 1].KinhNghiem +=
                    GameManager.instance.dataVatNuoi.data[3].exp;
            }

        }
        if (collision.gameObject.tag == "conde")
        {

            if (collision.gameObject.GetComponent<VatNuoi>().th == true && tag == "thuhoachde")
            {
                GameObject ob = Instantiate(iconFly, transform.position, Quaternion.identity);
                GameObject obj = Instantiate(iconFlykinhnghiem, transform.position, Quaternion.identity);
                ob.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite =
                    GameManager.instance.dataVatNuoi.data[id].iconsanpham;
                collision.gameObject.GetComponent<VatNuoi>().ske.AnimationName = "stand 2";
                collision.gameObject.GetComponent<VatNuoi>().th = false;
                GameManager.instance.dataVatNuoi.data[4].sl_sanpham++;
                GameManager.instance.datanhachinh.data[GameManager.instance.dataui.data[2].giatri - 1].KinhNghiem +=
                    GameManager.instance.dataVatNuoi.data[4].exp;
            }

        }
        if (collision.gameObject.tag == "concuu")
        {

            if (collision.gameObject.GetComponent<VatNuoi>().th == true && tag == "thuhoachcuu")
            {
                GameObject ob = Instantiate(iconFly, transform.position, Quaternion.identity);
                GameObject obj = Instantiate(iconFlykinhnghiem, transform.position, Quaternion.identity);
                ob.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite =
                    GameManager.instance.dataVatNuoi.data[id].iconsanpham;
                collision.gameObject.GetComponent<VatNuoi>().ske.AnimationName = "stand 2";
                collision.gameObject.GetComponent<VatNuoi>().th = false;
                GameManager.instance.dataVatNuoi.data[5].sl_sanpham++;
                GameManager.instance.datanhachinh.data[GameManager.instance.dataui.data[2].giatri - 1].KinhNghiem +=
                    GameManager.instance.dataVatNuoi.data[5].exp;
            }

        }
    }
}
