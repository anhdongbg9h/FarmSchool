using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class hienthoigian : MonoBehaviour
{
    [SerializeField] Image processBar;
    [SerializeField] TextMeshProUGUI timetext;

    private void Start()
    {
        /*processBar.fillAmount = 0;
        timetext.text = "";*/
    }
    public void UpdateTime(int val, int maxVal)
    {
        if (val < 0)
        {
            return;
        }
        else if (val > 0 && val < 60)
        {
            timetext.text = val.ToString() + " giây";
        }
        else if (val > 59 && val < 3600)
        {
            timetext.text = (val / 60).ToString() + " phút " + (val % 60).ToString() + " giây";
        }
        else if (val > 3599)
        {
            timetext.text = (val / 60).ToString() + " giờ " + ((val % 60) / 60).ToString() + " phút " + ((val % 60) % 60).ToString() + " giây";
        }
        processBar.fillAmount = (float)val / (float)maxVal;
    }
    //cho phép chạy và show giá trị time
    public IEnumerator updatetime(int value, int maxvalue)
    {
        processBar.fillAmount = (float)value / (float)maxvalue;
        if (value <= 0)
        {
            yield return 0;
        }
        else if (value > 0 && value < 60)
        {
            timetext.text = value.ToString() + " giây";
            yield return new WaitForSeconds(1f);
            value--;
            timetext.text = value.ToString() + " giây";
            StartCoroutine(updatetime(value, maxvalue));
        }
        else if (value > 59 && value < 3600)
        {
            timetext.text = (value / 60).ToString() + " phút " + (value % 60).ToString() + " giây";
            yield return new WaitForSeconds(1f);
            value--;
            timetext.text = (value / 60).ToString() + " phút " + (value % 60).ToString() + " giây";
            StartCoroutine(updatetime(value, maxvalue));
        }
        else if (value > 3599)
        {
            timetext.text = (value / 60).ToString() + " giờ " + ((value % 60) / 60).ToString() + " phút " + ((value % 60) % 60).ToString() + " giây";
            yield return new WaitForSeconds(1f);
            value--;
            timetext.text = (value / 60).ToString() + " giờ " + ((value % 60) / 60).ToString() + " phút " + ((value % 60) % 60).ToString() + " giây";
            StartCoroutine(updatetime(value, maxvalue));
        }
    }
    public void StopTime()
    {
        StopAllCoroutines();
        processBar.fillAmount = 0;
        timetext.text = "";
    }
}
