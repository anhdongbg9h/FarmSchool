using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject Canvas_setting;
    public GameObject Canvas_Thoatgame;


    public void Button_setting()
    {
        gameObject.SetActive(true);
        Canvas_setting.SetActive(true);
        Canvas.SetActive(true);
    }
    public void Button_exit_setting()
    {
        gameObject.SetActive(false);
        Canvas.SetActive(false);
    }
    public void Button_Thoatgame() {
        Canvas_setting.SetActive(false);
        Canvas_Thoatgame.SetActive(true);
    }

    public void Button_khongthoatgame()
    {
        Canvas.SetActive(false);
        Canvas_Thoatgame.SetActive(false);
        gameObject.SetActive(false);
    }

    public void Quiz_game()
    {
        Debug.Log("có");
        GameData.unitdata.Save(GameManager.instance.Grid);
        SceneManager.LoadScene("EndScene");
    }
}
