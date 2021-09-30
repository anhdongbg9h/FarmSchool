using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Datathucan : ScriptableObject
{

    [System.Serializable]

    public struct ThucAn
    {
        //public int ID;
        public string nameVNI, nameENG;
        public int time;
    }
    public ThucAn[] data;

}