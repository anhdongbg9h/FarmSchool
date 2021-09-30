using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_dialog : MonoBehaviour
{
    public static Get_dialog instance;


    private void Awake()
    {
        instance = this;
    }
}
