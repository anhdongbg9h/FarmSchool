using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[CreateAssetMenu(fileName = "DataShopConVat", menuName = "DataShopConVat")]
public class DataShopConvat : ScriptableObject
{
    
    [System.Serializable]
    public struct ShopConVat
    {
        public string name;
        public int Gia, sl, GioiHan, Capmo;
    }
    public ShopConVat[] data;
}
