using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DataShopXd", menuName = "DataShopXd")]
public class DataShopXD : ScriptableObject
{
    [System.Serializable]
    public struct ShopXD
    {
        public string name;
        public int Gia, sl, GioiHan, Capmo;
    }
    public ShopXD[] data;
}
