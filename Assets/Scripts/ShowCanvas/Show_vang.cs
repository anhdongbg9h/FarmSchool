using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Show_vang : MonoBehaviour
{
    
    void Update()
    {
        gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = 
            GameManager.instance.dataui.data[0].giatri.ToString();
    }
}
