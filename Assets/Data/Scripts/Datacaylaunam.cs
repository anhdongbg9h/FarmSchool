using UnityEngine;

public class Datacaylaunam : ScriptableObject
{

    [System.Serializable]

    public struct CayLauNam
    {
        //public int ID;
        public string nameVNI, nameENG;
        public int time1, time2, capmo, giamua, giaban, exp, sanluong;
        //public SkeletonAnimation skeleton;
        public Sprite iconsanpham,gd1, gd2, gd3;
    }
    public CayLauNam[] data;

}
