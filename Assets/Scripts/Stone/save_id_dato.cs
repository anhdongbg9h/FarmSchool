using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save_id_dato : MonoBehaviour
{
    public static save_id_dato instance;
    public int[] mang_id_dato;
    public int dem_da_to;

    private void Awake()
    {
        instance = this;
        dem_da_to = 0;
        mang_id_dato = new int[20];
        for (int i = 0; i < 20; i++)
        {
            mang_id_dato[i] = -1;
        }
    }
}
