using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //public GameObject gb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            Vector3 vt_camera = transform.position;
            vt_camera = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = vt_camera;
        }
       
    }
}
