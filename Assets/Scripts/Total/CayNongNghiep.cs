using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CayNongNghiep : MonoBehaviour
{


    private GameObject game;

    public GameObject Giong;
    void Update()
    {
        Vector3 _vtGiong = transform.position;
        Vector3 _chuot = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _chuot.z = 0;
        if (Input.GetMouseButtonDown(1))
        {
            if ((_chuot == _vtGiong) || (_chuot.y < _vtGiong.y + 0.2f && _chuot.x < _vtGiong.x + 0.2f) && (_chuot.y > _vtGiong.y - 0.2f && _chuot.x > _vtGiong.x - 0.2f))
            {
                game = Instantiate(Giong, _chuot, Quaternion.identity);
                //Destroy(HienThi_Scripts.instance.image);
            }
        }
        if (Input.GetMouseButton(1))
        {
            game.transform.position = _chuot;
        }
        if (Input.GetMouseButtonUp(1))
        {
            Destroy(game);

        }
    }
}
