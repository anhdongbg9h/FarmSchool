using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_StarGame : MonoBehaviour
{

    public GameObject canvas_chinh;
    void Start()
    {
        GameManager.instance.dataui.data[2].giatri = GameData.unitdata.lvplayer;


        //canvas_chinh.transform.GetChild(2).GetChild(0).GetComponent<Show_lv_game>().Start_Game();
    }
}
