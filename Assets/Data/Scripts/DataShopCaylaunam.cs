using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataShopCayLauNam", menuName = "DataShopCayLauNam")]


public class DataShopCaylaunam : ScriptableObject
{
    [System.Serializable]
    public struct ShopCayLauNam
    {
        public string name;
        public int Gia, sl, GioiHan, Capmo;
    }
    public ShopCayLauNam[] data;
}
