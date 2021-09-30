using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ClickUIShop : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject ic;
    [SerializeField] GameObject ob;
    [SerializeField] GameObject ob1;
    [SerializeField] GameObject ob2;
    [SerializeField] GameObject Panel_bat;
    [SerializeField] GameObject Panel_tat;
    [SerializeField] GameObject Panel_tat1;
    [SerializeField] GameObject Panel_Tat2;
    public void OnPointerDown(PointerEventData eventData)
    {
        ic.SetActive(true);
        ob.SetActive(false);
        ob1.SetActive(false);
        ob2.SetActive(false);

        Panel_bat.SetActive(true);
        Panel_tat.SetActive(false);
        Panel_tat1.SetActive(false);
        Panel_Tat2.SetActive(false);

    }
}
