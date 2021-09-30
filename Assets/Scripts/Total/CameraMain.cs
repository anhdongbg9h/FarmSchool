using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMain : MonoBehaviour
{
    //public Transform target;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            // lay vi tri chuot khi click tren man hinh
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast
                (ray.origin,ray.direction, out hit))
            {
                pos = hit.point;
                Debug.Log("pos"+ pos);
            }
        }
        //transform.LookAt(pos);
    }
}
