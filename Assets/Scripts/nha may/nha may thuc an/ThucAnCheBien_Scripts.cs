using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThucAnCheBien_Scripts : MonoBehaviour
{
    public static ThucAnCheBien_Scripts instance;
    public int id;

    [HideInInspector] public int[] mang;
    [HideInInspector] public int[] mang_LT;
    public int sl_thanhphan;

    

    private void Awake()
    {
        instance = this;
    }
}
