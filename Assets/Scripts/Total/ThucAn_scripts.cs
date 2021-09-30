using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThucAn_scripts : MonoBehaviour
{
    public int id;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // va chạm khi cho ăn
        {
            if (collision.gameObject.tag == "conga" &&
                    GameManager.instance.dataSPCheBien.data[0].sanluong > 0)
            {
                if (!collision.gameObject.GetComponent<VatNuoi>().th && tag == "thucanga")
                {
                    collision.gameObject.GetComponent<VatNuoi>().th = true;
                    collision.gameObject.GetComponent<VatNuoi>().ChangeAnim(id);
                    GameManager.instance.dataSPCheBien.data[0].sanluong--;

                }

            }
            if (collision.gameObject.tag == "conngua"&&
                GameManager.instance.dataSPCheBien.data[1].sanluong > 0)
            {
                if (!collision.gameObject.GetComponent<VatNuoi>().th && tag == "thucanngua")
                {
                    collision.gameObject.GetComponent<VatNuoi>().th = true;
                    collision.gameObject.GetComponent<VatNuoi>().ChangeAnim(id);
                    GameManager.instance.dataSPCheBien.data[1].sanluong--;
                }

            }
            if (collision.gameObject.tag == "conlon"&&
                GameManager.instance.dataSPCheBien.data[2].sanluong>0)
            {
                if (!collision.gameObject.GetComponent<VatNuoi>().th && tag == "thucanlon")
                {
                    collision.gameObject.GetComponent<VatNuoi>().th = true;
                    collision.gameObject.GetComponent<VatNuoi>().ChangeAnim(id);
                    GameManager.instance.dataSPCheBien.data[2].sanluong--;
                }

            }
            if (collision.gameObject.tag == "conbo"&&
                GameManager.instance.dataSPCheBien.data[3].sanluong>0)
            {
                if (!collision.gameObject.GetComponent<VatNuoi>().th && tag == "thucanbo")
                {
                    collision.gameObject.GetComponent<VatNuoi>().th = true;
                    collision.gameObject.GetComponent<VatNuoi>().ChangeAnim(id);
                    GameManager.instance.dataSPCheBien.data[3].sanluong--;
                }

            }
            if (collision.gameObject.tag == "conde"&&
                GameManager.instance.dataSPCheBien.data[4].sanluong>0)
            {
                if (!collision.gameObject.GetComponent<VatNuoi>().th && tag == "thucande")
                {
                    collision.gameObject.GetComponent<VatNuoi>().th = true;
                    collision.gameObject.GetComponent<VatNuoi>().ChangeAnim(id);
                    GameManager.instance.dataSPCheBien.data[4].sanluong--;
                }
            }
            if (collision.gameObject.tag == "concuu"&&
                GameManager.instance.dataSPCheBien.data[5].sanluong>0)
            {
                if (!collision.gameObject.GetComponent<VatNuoi>().th && tag == "thucancuu")
                {
                    collision.gameObject.GetComponent<VatNuoi>().th = true;
                    collision.gameObject.GetComponent<VatNuoi>().ChangeAnim(id);
                    GameManager.instance.dataSPCheBien.data[5].sanluong--;
                }
            }
        }
    }
}
