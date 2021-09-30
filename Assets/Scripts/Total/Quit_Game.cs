using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit_Game : MonoBehaviour
{
    private void OnApplicationQuit()
    {
        GameData.unitdata.Save(GameManager.instance.Grid);
        DontDestroyOnLoad(gameObject);
    }
}
