using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DataShopTrangTri", menuName = "DataShopTrangTri")]
public class DataShopTrangTri : ScriptableObject
{
    [System.Serializable]
    public struct ShopTrangTri
    {
        public string name;
        public int Gia, sl, GioiHan, Capmo;
    }
    public ShopTrangTri[] data;
}
