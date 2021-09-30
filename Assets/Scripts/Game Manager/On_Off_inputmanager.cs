using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On_Off_inputmanager : MonoBehaviour
{
    private InputManager in_put;

    private void Start()
    {
        in_put = GetComponent<InputManager>();
    }


    public void on_input()
    {
        in_put.enabled = true;
    }

    public void off_input()
    {
        in_put.enabled = false;
    }
}
