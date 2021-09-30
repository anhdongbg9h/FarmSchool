using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilemap : MonoBehaviour
{
    public GameObject Grid;
    [HideInInspector] public int[,] tilemap;


    
    public void Start_Tilemap()
    {

        tilemap = new int[250, 250];
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.1f);
        Khoitao();
        Xac_Dinh_vtri_cac_doi_tuong_daugame();
    }
    void Khoitao()
    {
        for(int i = 0; i < 250; i++)
        {
            for(int j = 0; j < 250; j++)
            {
                tilemap[i, j] = 0;
            }
        }
    }
    public void Xac_Dinh_vtri_cac_doi_tuong_daugame()
    {
        if(Grid.transform.childCount > 0)
        {
            for (int a = 1; a < Grid.transform.childCount; a++)
            {
                if (Grid.transform.GetChild(a).GetComponent<Get_Id_component>().id == 0)
                {
                    for (int b = 0; b < Grid.transform.GetChild(a).childCount; b++)
                    {
                        Set_ToaDo(1, Grid.transform.GetChild(a).GetChild(b).gameObject, 0);
                    }
                }
                else if (Grid.transform.GetChild(a).GetComponent<Get_Id_component>().id == 3)
                {
                    for (int b = 0; b < Grid.transform.GetChild(a).childCount; b++)
                    {
                        Set_ToaDo(1, Grid.transform.GetChild(a).GetChild(b).gameObject, 3);
                    }
                }
                else if (Grid.transform.GetChild(a).GetComponent<Get_Id_component>().id == 4)
                {
                    for (int b = 0; b < Grid.transform.GetChild(a).childCount; b++)
                    {
                        Set_ToaDo(1, Grid.transform.GetChild(a).GetChild(b).gameObject, 4);
                    }
                }
                else if (Grid.transform.GetChild(a).GetComponent<Get_Id_component>().id == 5)
                {
                    for(int b = 0; b < Grid.transform.GetChild(a).childCount; b++)
                    {
                        Set_ToaDo(1, Grid.transform.GetChild(a).GetChild(b).gameObject, 5);
                    }
                }
                else if (Grid.transform.GetChild(a).GetComponent<Get_Id_component>().id == 6)
                {
                    for (int b = 0; b < Grid.transform.GetChild(a).childCount; b++)
                    {
                        Set_ToaDo(1, Grid.transform.GetChild(a).GetChild(b).gameObject, 6);
                    }
                }
                else if (Grid.transform.GetChild(a).GetComponent<Get_Id_component>().id == 7)
                {
                    for (int b = 0; b < Grid.transform.GetChild(a).childCount; b++)
                    {
                        Set_ToaDo(1, Grid.transform.GetChild(a).GetChild(b).gameObject, 7);
                    }
                }
                else if (Grid.transform.GetChild(a).GetComponent<Get_Id_component>().id == 8)
                {
                    for (int b = 0; b < Grid.transform.GetChild(a).childCount; b++)
                    {
                        Set_ToaDo(1, Grid.transform.GetChild(a).GetChild(b).gameObject, 8);
                    }
                }
                else if (Grid.transform.GetChild(a).GetComponent<Get_Id_component>().id == 9)
                {
                    for (int b = 0; b < Grid.transform.GetChild(a).childCount; b++)
                    {
                        Set_ToaDo(1, Grid.transform.GetChild(a).GetChild(b).gameObject, 9);
                    }
                }
                else if (Grid.transform.GetChild(a).GetComponent<Get_Id_component>().id == 10)
                {
                    for (int b = 0; b < Grid.transform.GetChild(a).childCount; b++)
                    {
                        Set_ToaDo(1, Grid.transform.GetChild(a).GetChild(b).gameObject, 10);
                    }
                }
                else if (Grid.transform.GetChild(a).GetComponent<Get_Id_component>().id == 11)
                {
                    for (int b = 0; b < Grid.transform.GetChild(a).childCount; b++)
                    {
                        Set_ToaDo(1, Grid.transform.GetChild(a).GetChild(b).gameObject, 11);
                    }
                }
            }
        }
    }

    public void Set_ToaDo(int gt, GameObject obj, int id)
    {
        float toado_x, toado_y;
        float TG1, TG2;
        toado_x = obj.transform.position.x - Grid.transform.position.x;
        toado_y = obj.transform.position.y - Grid.transform.position.y;

        TG1 = Mathf.Abs(transform.position.x - obj.transform.position.x);
        TG2 = Mathf.Abs(transform.position.y - obj.transform.position.y);


        XacDinh_goc(gt, TG1, TG2, toado_x, toado_y,id/*, obj*/);
    }

    public void XacDinh_goc(int gt, float TG1, float TG2, float toado_x, float toado_y, int id/*, GameObject obj*/)
    {
        int x = 0, y = 0;
        if (TG1 == System.Math.Truncate(TG1) + 0.5f)
        {
            TG1 = (float)System.Math.Truncate(TG1) + 1f;
        }
        else if(TG1 == System.Math.Truncate(TG1))
        {
            TG1 = (float)System.Math.Truncate(TG1);
        }

        if(TG2 == (float)System.Math.Truncate(TG2))                     
        {
            TG2 = (float)System.Math.Truncate(TG2) * 2;
        }
        else if(TG2 == (float)System.Math.Truncate(TG2) + 0.25f || TG2 == (float)System.Math.Truncate(TG2) + 0.5f)
        {
            TG2 = (float)System.Math.Truncate(TG2) * 2 + 1;
        }
        else if(TG2 == (float)System.Math.Truncate(TG2) + 0.75f)
        {
            TG2 = (float)System.Math.Truncate(TG2) * 2 + 2;
        }

        //Debug.Log("TG1 - TG2: " + TG1 + "-" + TG2);

        if(toado_y > 0)
        {
            if(toado_x == (float)System.Math.Truncate(toado_x))
            {
                x = (int)(TG1 - TG2 + 1);
                y = (int)(TG1 + TG2);
            }
            else if(toado_x == (float)System.Math.Truncate(toado_x) + 0.5f)
            {
                x = (int)(TG1 - TG2);
                y = (int)(TG1 + TG2);
            }
        }
        else if(toado_y < 0)
        {
            if (toado_x == (float)System.Math.Truncate(toado_x))
            {
                y = (int)(TG1 - TG2 + 1);
                x = (int)(TG1 + TG2);
            }
            else if (toado_x == (float)System.Math.Truncate(toado_x) + 0.5f)
            {
                y = (int)(TG1 - TG2);
                x = (int)(TG1 + TG2);
            }
        }
        else if(toado_y == 0)
        {
            x = (int)TG1;
            y = (int)TG1;
        }
        
        gan(x, y, gt, id);
    }

    public void gan(int x, int y, int gt,int id)
    {
        if (id == 0)
        {
            for (int i = x; i >= x - 1; i--)
            {
                for (int j = y; j <= y + 1; j++)
                {
                    tilemap[i, j] = gt;
                }
            }
        }
        else if (id == 3)
        {
            tilemap[x, y] = gt;
        }
        else if (id == 4)
        {
            tilemap[x, y] = gt;
        }
        else if (id==5)
        {
            tilemap[x, y] = gt;
        }
        else if (id == 6)
        {
            for (int i = x; i >= x - 2; i--)
            {
                for (int j = y; j <= y + 2; j++)
                {
                    tilemap[i, j] = gt;
                }
            }
        }
        else if (id == 7)
        {
            for (int i = x; i >= x - 2; i--)
            {
                for (int j = y; j <= y + 5; j++)
                {
                    tilemap[i, j] = gt;
                }
            }
        }
        else if (id == 8)
        {
            for (int i = x; i >= x - 3; i--)
            {
                for (int j = y; j <= y + 4; j++)
                {
                    tilemap[i, j] = gt;
                }
            }
        }
        else if (id == 9)
        {
            for (int i = x; i >= x - 5; i--)
            {
                for (int j = y; j <= y + 6; j++)
                {
                    tilemap[i, j] = gt;
                }
            }
        }
        else if (id == 10)
        {
            for (int i = x; i >= x - 1; i--)
            {
                for (int j = y - 9; j <= y + 9; j++)
                {
                    tilemap[i, j] = gt;
                }
            }

            for (int a = x + 12; a >= x - 4; a--)
            {
                for (int b = y; b <= y + 1; b++)
                {
                    tilemap[a, b] = gt;
                }
            }

        }
        else if (id == 11)
        {
            for (int i = x; i >= x - 2; i--)
            {
                for (int j = y - 67; j <= y + 54; j++)
                {
                    tilemap[i, j] = gt;
                }
            }

            for (int i = x; i >= x - 7; i--)
            {
                for (int j = y; j <= y + 2; j++)
                {
                    tilemap[i, j] = gt;
                }
            }

            for (int i = x + 1; i <= x + 25; i++)
            {
                for (int j = y + 6; j <= y + 8; j++)
                {
                    tilemap[i, j] = gt;
                }
            }
        }
    }
}
