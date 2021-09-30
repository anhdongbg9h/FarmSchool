using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_component_oto_coin : MonoBehaviour
{
    Animator ani;
    O_to_cho_coin o_to_cho_coin;

    void Start()
    {
        ani = GetComponent<Animator>();
        o_to_cho_coin = GetComponent<O_to_cho_coin>();
    }


    public void Set_active()
    {
        ani.enabled = !ani.enabled;
        o_to_cho_coin.enabled = !o_to_cho_coin.enabled;


        /*if (ani.enabled == true || o_to_cho_coin.enabled == true)
        {
            ani.enabled = false;
            o_to_cho_coin.enabled = false;
        }
        else
        {
            ani.enabled = true;
            o_to_cho_coin.enabled = true;
        }*/
    }
}
