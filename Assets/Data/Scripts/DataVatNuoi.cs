using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataVatNuoi : ScriptableObject
{
   
    [System.Serializable]

    public struct VatNuoi
    {
        public string nameVNI, nameENG;
        public int time, capmo, giamua, giaban, exp, sl_sanpham;
        public Sprite iconsanpham,thuan, thuhoach;
    }
    public VatNuoi[] data;

}
