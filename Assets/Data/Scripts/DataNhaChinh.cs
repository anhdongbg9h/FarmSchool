using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[CreateAssetMenu(fileName = "NhaChinh", menuName = "NhaChinh")]

public class DataNhaChinh : ScriptableObject
{
    [System.Serializable]


    public struct NhaChinh
    {
        public string name_lv;
        public int Cap, KinhNghiem, GioiHanKinhNghiem;
    }
    public NhaChinh[] data;
}
