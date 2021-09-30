using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HienLuaChon : MonoBehaviour
{
    [SerializeField]
    private GameObject image;

    [SerializeField]
    private GameObject but;
    void Start()
    {
        
    }
    void Update()
    {
        Vector3 _vt_odat = transform.position;
        Vector3 _vt_chuot = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetMouseButtonDown(0))
        {
            
            if ((_vt_chuot == _vt_odat) || (_vt_chuot.y < _vt_odat.y + 0.4f && _vt_chuot.x < _vt_odat.x + 0.7f)
                && (_vt_chuot.y > _vt_odat.y - 0.4f && _vt_chuot.x > _vt_odat.x - 0.7f))
            {
                image.GetComponent<RectTransform>().anchoredPosition = _vt_odat + new Vector3(-0.3f, 0.3f, 0);
            }
            else
            {
                image.GetComponent<RectTransform>().anchoredPosition = but.transform.position;
            }
        }
    }
}
