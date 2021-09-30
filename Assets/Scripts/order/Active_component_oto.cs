using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_component_oto : MonoBehaviour
{

    Animator ani;
    O_to_move oto_move;
    
    void Start()
    {
        ani = GetComponent<Animator>();
        oto_move = GetComponent<O_to_move>();
    }
    public void Set_active()
    {
        ani.enabled = !ani.enabled;
        oto_move.enabled = !oto_move.enabled;

        /*if (ani.enabled == true || oto_move.enabled == true)
        {
            ani.enabled = false;
            oto_move.enabled = false;
        }
        else
        {
            ani.enabled = true;
            oto_move.enabled = true;
        }*/

    }
    
}
