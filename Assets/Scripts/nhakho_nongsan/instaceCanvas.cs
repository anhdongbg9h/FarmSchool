using BitBenderGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class instaceCanvas : MonoBehaviour, IPointerDownHandler
{
    public static instaceCanvas instance;

    [SerializeField] private GameObject chua_sp;

    public int id;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("ấn vào đây");
        chua_sp.SetActive(false);
    }

    private void Awake()
    {
        instance = this;
    }
}
