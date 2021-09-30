using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinhraobjectgamethuhoach : MonoBehaviour
{
    [SerializeField] private SpriteRenderer obj;
    // Start is called before the first frame update
    private int id;
    private void Start()
    {
        o_dat od = GetComponent<o_dat>();
        if (od != null)
        {
            id = od.id_sp;
            Debug.Log(id);
        }
        obj.sprite = GameManager.instance.dataNongSan.data[id].iconsanpham;
    }
}
