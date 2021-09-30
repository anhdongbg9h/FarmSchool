using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using BitBenderGames;


public class text_script : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log(" tọa độ của x là: " + Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
        Debug.Log(" tọa độ của y là: " + Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
    }
}
