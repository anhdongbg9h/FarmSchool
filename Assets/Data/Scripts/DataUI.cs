using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "SPCheBien", menuName = "dataUI")]

public class DataUI : ScriptableObject
{
    [System.Serializable]

    public struct dataui
    {
        public string nameVNI;
        public int giatri;
    }
    public dataui[] data;
}
