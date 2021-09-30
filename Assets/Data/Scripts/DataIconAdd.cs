using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DataIconAdd : ScriptableObject
{

    [System.Serializable]

    public struct Icon
    {
        public Sprite icon;
    }
    public Icon[] data;

}
