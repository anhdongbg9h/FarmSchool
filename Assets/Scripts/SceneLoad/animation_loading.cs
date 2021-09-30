using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation_loading : MonoBehaviour
{
    RectTransform re;

    private void Start()
    {
        re = GetComponent<RectTransform>();
        StartCoroutine(delay());
    }


    IEnumerator delay()
    {
        yield return new WaitForSeconds(.5f);
        re.Rotate(new Vector3(0, 0, 0), 2);
        StartCoroutine(delay());
    }
}
