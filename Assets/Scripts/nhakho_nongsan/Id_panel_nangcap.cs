using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Id_panel_nangcap : MonoBehaviour
{
    public static Id_panel_nangcap instance;
    public int id;
    private void Awake()
    {
        instance = this;
    }
}
