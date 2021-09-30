using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DataEditorVatNuoi
{
    [MenuItem("Data/Data/VatNuoi")]
    public static void DetailSeeds()
    {
        DataVatNuoi assetVatNuoi = ScriptableObject.CreateInstance<DataVatNuoi>();
        AssetDatabase.CreateAsset(assetVatNuoi, "Assets/Data/Data/VatNuoi.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = assetVatNuoi;
    }
}
