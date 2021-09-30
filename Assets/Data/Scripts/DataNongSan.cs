using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataNongSan : ScriptableObject {

    [System.Serializable]

    public struct NongSan
    {
        public string nameVNI, nameENG, nguongoc;
        public int ID;
        public int time1,time2, capmo, giamua, giaban, exp, sanluong;
        public Sprite gd1, gd2, gd3, iconsanpham;
    }
    public NongSan[] data;

}
