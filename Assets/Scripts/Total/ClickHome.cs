using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHome : MonoBehaviour
{
    public GameObject doituong_dexacdinh_layer;
    public float kc;
    private void Start()
    {
        kc = Mathf.Abs(gameObject.transform.position.y - doituong_dexacdinh_layer.transform.position.y)*10;
        gameObject.transform.GetComponent<SpriteRenderer>().sortingOrder = (int)kc;
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().sortingOrder = (int)kc+1;
            for (int j = 0; j < gameObject.transform.GetChild(i).childCount; j++)
            {
                gameObject.transform.GetChild(i).GetChild(j).GetComponent<SpriteRenderer>().sortingOrder = (int)kc + 2;
            }
        }
    }
}
