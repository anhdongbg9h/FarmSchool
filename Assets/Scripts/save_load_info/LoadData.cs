using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;
using System.Threading;

public class LoadData : MonoBehaviour
{
    public string nextScene;
    private string KEY_DATA = "unitdata";

    private void Awake()
    {
        /*for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(500);
        }*/
        load_data();
        SceneManager.LoadScene(nextScene);
    }

    void load_data()
    {
        PlayerPrefs.SetString(KEY_DATA, null);

        string s = PlayerPrefs.GetString(KEY_DATA);
        if (string.IsNullOrEmpty(s))
        {
            GameData.unitdata = new UnitData();
            return;
        }

        // Dùng JsonDotNet convert dữ liệu từ string sang object
        GameData.unitdata = JsonConvert.DeserializeObject<UnitData>(s);
        // Thu hoạch từ cây lâu năm
    }
}
