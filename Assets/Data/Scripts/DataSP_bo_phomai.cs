using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DataSP_bo_phomai : ScriptableObject
{
    [System.Serializable]

    public struct SP_bo_phomai
    {
        public string nameVNI;
        public int time;
        public Sprite iconsanpham;
    }
    public SP_bo_phomai[] data;
}
