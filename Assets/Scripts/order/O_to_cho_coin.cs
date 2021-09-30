using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_to_cho_coin : MonoBehaviour
{
    public GameObject O_to_khong;
    public GameObject icon_thuhoach;
    public GameObject icon_thuhoachkinhnghiem;
    public GameObject point2;


    private void OnMouseDown()
    {
        StartCoroutine(wait());
        O_to_khong.SetActive(true);
        
        GameObject obj = Instantiate(icon_thuhoach, transform.position, Quaternion.identity);
        GameObject obj1 = Instantiate(icon_thuhoachkinhnghiem, transform.position, Quaternion.identity);
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(.5f);
        gameObject.transform.position = point2.transform.position;
        gameObject.SetActive(false);
    }
}
