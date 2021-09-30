using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public GameObject bt;
   
    

    private void OnMouseDown()
    {
        Destroy(bt);
    }


}
