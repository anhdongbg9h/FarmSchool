using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CayRung : ScriptableObject
{

    [System.Serializable]

    public struct cayrung
    {
        public string name;
        public Sprite sanpham;
    }
    public cayrung[] data;

}
