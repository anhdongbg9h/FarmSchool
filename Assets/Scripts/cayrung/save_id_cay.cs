using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save_id_cay : MonoBehaviour
{
    public static save_id_cay instance;
    public int[] mang_id_chatcay;
    public int[] mang_id_da;
    public int dem_cay;
    public int dem_da;

    private void Awake()
    {
        instance = this;
        dem_cay = 0;
        mang_id_chatcay = new int[350];
        for (int i = 0; i < 350; i++)
        {
            mang_id_chatcay[i] = -1;
        }
        dem_da = 0;
        mang_id_da = new int[50];
        for (int i = 0; i < 50; i++)
        {
            mang_id_da[i] = -1;
        }
    }

}
