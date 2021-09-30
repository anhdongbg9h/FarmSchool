using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "SPCheBien", menuName = "SPCheBien")]
public class DataSPCheBien : ScriptableObject
{
    [System.Serializable]

    public struct SPCheBien
    {
        public string nameVNI,nguongoc;
        public int id;
        public int time, capmo,giaban,giamua,exp,sanluong;
        public Sprite iconsanpham;
    }
    public SPCheBien[] data;
}