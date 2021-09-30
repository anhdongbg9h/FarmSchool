using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private GameObject goInteractable;
    void Start()
    {
        GameManager.instance.dialogHG = 
            Instantiate(GameManager.instance.dialogHG, new Vector3(999f, 999f, 0), Quaternion.identity);
        GameManager.instance.thuhoach = 
            Instantiate(GameManager.instance.thuhoach, new Vector3(999f, 999f, 0), Quaternion.identity);
        GameManager.instance.canvasga = 
            Instantiate(GameManager.instance.canvasga, new Vector3(999f, 999f, 0), Quaternion.identity);
        GameManager.instance.hienthoigian = 
            Instantiate(GameManager.instance.hienthoigian, new Vector3(999f, 999f, 0), Quaternion.identity);
        GameManager.instance.thuhoachqua = 
            Instantiate(GameManager.instance.thuhoachqua, new Vector3(999f, 999f, 0), Quaternion.identity);
        GameManager.instance.CanvasSXthuanconvat = 
            Instantiate(GameManager.instance.CanvasSXthuanconvat, new Vector3(999f, 999f, 0), Quaternion.identity);
        GameManager.instance.canvasChatcay = 
            Instantiate(GameManager.instance.canvasChatcay, new Vector3(999f, 999f, 0), Quaternion.identity);
        GameManager.instance.canvas_bo_phomai =
            Instantiate(GameManager.instance.canvas_bo_phomai, new Vector3(999f, 999f, 0), Quaternion.identity);
        GameManager.instance.canvas_nhamayhoaqua =
            Instantiate(GameManager.instance.canvas_nhamayhoaqua, new Vector3(999f, 999f, 0), Quaternion.identity);
        GameManager.instance.canvas_lonuongbanh_pizza =
            Instantiate(GameManager.instance.canvas_lonuongbanh_pizza, new Vector3(999f, 999f, 0), Quaternion.identity);
        GameManager.instance.canvas_lonuong_thit =
            Instantiate(GameManager.instance.canvas_lonuong_thit, new Vector3(999f, 999f, 0), Quaternion.identity);
        GameManager.instance.canvas_nhamat_ong =
            Instantiate(GameManager.instance.canvas_nhamat_ong, new Vector3(999f, 999f, 0), Quaternion.identity);
        GameManager.instance.canvas_nhamay_duong =
            Instantiate(GameManager.instance.canvas_nhamay_duong, new Vector3(999f, 999f, 0), Quaternion.identity);
        GameManager.instance.canvas_nhamay_bot =
            Instantiate(GameManager.instance.canvas_nhamay_bot, new Vector3(999f, 999f, 0), Quaternion.identity);
        GameManager.instance.canvas_nhamay_quang =
            Instantiate(GameManager.instance.canvas_nhamay_quang, new Vector3(999f, 999f, 0), Quaternion.identity);
        GameManager.instance.canvas_nhamay_suahop =
            Instantiate(GameManager.instance.canvas_nhamay_suahop, new Vector3(999f, 999f, 0), Quaternion.identity);
        GameManager.instance.canvas_nhamay_sxruou =
            Instantiate(GameManager.instance.canvas_nhamay_sxruou, new Vector3(999f, 999f, 0), Quaternion.identity);
        GameManager.instance.canvas_phahuy_da = 
            Instantiate(GameManager.instance.canvas_phahuy_da, new Vector3(999f, 999f, 0), Quaternion.identity);
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            goInteractable = GetGameObject(GetMousePosition());
            ShowSeedUI(goInteractable);
        }
    }
    private Vector3 GetMousePosition()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // lay vi tri cua chuot tren man hinh
        mousePos.z = 0;
        return mousePos;
    }
    private GameObject GetGameObject(Vector3 startPoint)
    {
        Collider2D hitInfo = Physics2D.OverlapCircle(startPoint,0.1f);
        if (hitInfo)
        {
            GameObject go = hitInfo.gameObject;
            if (go != null)
            {
                return go;
            }
            else
            return null;
        }
        else
        return null;
    }
    private void ShowSeedUI(GameObject go)
    {
        if (go==null)
        {
            DisableSeedUI();
            return;
        }
       
        /*if (GameManager.instance.nmSX!=go)
        {
            DisableSeedUI();
            return;
        }*/
        IInteractable Interactable = go.GetComponent<IInteractable>();
        if(Interactable == null)
        {
            DisableSeedUI();
            
        }
        else if(Interactable != null)
        {
            Interactable.ShowSeedUI();
        }
    }
    private void DisableSeedUI()
    {
        GameManager.instance.dialogHG.transform.position = new Vector3(999f, 999f, 0);
        GameManager.instance.thuhoach.transform.position = new Vector3(999f, 999f, 0);
        GameManager.instance.canvasga.transform.position = new Vector3(999f, 999f, 0);
        GameManager.instance.hienthoigian.transform.position = new Vector3(999f, 999f, 0);
        GameManager.instance.thuhoachqua.transform.position = new Vector3(999f, 999f, 0);
        GameManager.instance.CanvasSXthuanconvat.transform.position= new Vector3(999f, 999f, 0);
        GameManager.instance.canvasChatcay.transform.position= new Vector3(999f, 999f, 0);
        GameManager.instance.canvas_bo_phomai.transform.position = new Vector3(999f, 999f, 0);
        GameManager.instance.canvas_nhamayhoaqua.transform.position = new Vector3(999f, 999f, 0);
        GameManager.instance.canvas_lonuongbanh_pizza.transform.position = new Vector3(999f, 999f, 0);
        GameManager.instance.canvas_lonuong_thit.transform.position = new Vector3(999f, 999f, 0);
        GameManager.instance.canvas_nhamat_ong.transform.position = new Vector3(999f, 999f, 0);
        GameManager.instance.canvas_nhamay_duong.transform.position = new Vector3(999f, 999f, 0);
        GameManager.instance.canvas_nhamay_bot.transform.position = new Vector3(999f, 999f, 0);
        GameManager.instance.canvas_nhamay_quang.transform.position = new Vector3(999f, 999f, 0);
        GameManager.instance.canvas_nhamay_suahop.transform.position = new Vector3(999f, 999f, 0);
        GameManager.instance.canvas_nhamay_sxruou.transform.position = new Vector3(999f, 999f, 0);
        GameManager.instance.canvas_phahuy_da.transform.position = new Vector3(999f, 999f, 0);
    }
    private void OnApplicationQuit()
    {
        GameData.unitdata.Save(GameManager.instance.Grid);
        DontDestroyOnLoad(this);
    }
    private void OnDestroy()
    {
        Debug.Log("đã thoát đã lưu");
    }
}
