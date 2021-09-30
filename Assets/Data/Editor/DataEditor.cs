using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class DataEditor  {

    [MenuItem("Data/Data/NongSan")]
    public static void DetailSeeds()
    {
        DataNongSan seed = ScriptableObject.CreateInstance<DataNongSan>();
        AssetDatabase.CreateAsset(seed, "Assets/Data/Data/NongSan.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = seed;
    }
    
}
