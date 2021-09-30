using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class nhakho_nongsan : MonoBehaviour
{
    public static nhakho_nongsan instance;

    [SerializeField] private GameObject nhakhonongsan;
    [SerializeField] private GameObject canvas_total;
    [SerializeField] private GameObject chua_sp;
    [HideInInspector] public int lv_nhakho = 1;
    [HideInInspector] public int suc_chua=50;
    private int sl;

    [HideInInspector] public int dem;     // đếm số hạt giống đã được mở
    [HideInInspector] public int[] mang;// lưu vị trí của các hạt đã được mở
    private void Start()
    {
        instance = this;
        mang = new int[30];
        dem = 0;
    }
    private void OnMouseDown()
    {
        nhakhonongsan.SetActive(true);
        chua_sp.SetActive(true);
        canvas_total.SetActive(false);
        Update_sl();
    }

    // cập  nhật số lượng hạt giống trong kho chứa
    public void Update_sl()
    {
        // số lượng hạt cây nông nghiệp có thể sử dụng
        for(int i=0;i<GameManager.instance.dataNongSan.data.Length;i++)
        {
            instaceCanvas.instance.transform.GetChild(0).GetChild(0).GetChild(i).gameObject.SetActive(false);
            if (GameManager.instance.dataNongSan.data[i].capmo <= GameManager.instance.dataui.data[2].giatri
                && GameManager.instance.dataNongSan.data[i].capmo != 0)
            {
                dem++;
                mang[dem-1] = i;
                sl += GameManager.instance.dataNongSan.data[i].sanluong;
            }
        }
        // active ô chứa hạt giống và show lên thông tin về những hạt giống trong kho
        for(int i =0;i<dem;i++)
        {
            instaceCanvas.instance.transform.GetChild(0).GetChild(0).GetChild(i).gameObject.SetActive(true);
            instaceCanvas.instance.transform.GetChild(0).GetChild(0).GetChild(i).GetChild(1).GetComponent<Image>().sprite =
                 GameManager.instance.dataNongSan.data[mang[i]].iconsanpham;
            instaceCanvas.instance.transform.GetChild(0).GetChild(0).GetChild(i).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = 
                GameManager.instance.dataNongSan.data[mang[i]].sanluong.ToString();
        }
        instaceCanvas.instance.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text =
            sl.ToString() + "/" + suc_chua.ToString();
        sl = 0;
        dem = 0;
    }

}
