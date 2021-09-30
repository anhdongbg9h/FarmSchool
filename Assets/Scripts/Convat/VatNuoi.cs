using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class VatNuoi : MonoBehaviour, IInteractable
{
    public static VatNuoi instance;

    [HideInInspector]
    public SkeletonAnimation ske;
    [SerializeField] private int id_convat;
    [SerializeField] private int timeeat;
    [SerializeField] private int Maxtime;
    [HideInInspector]
    public bool th = false;
    private GameObject obj;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        ske = GetComponent<SkeletonAnimation>();
        transform.position.Set(transform.position.x, transform.position.y, -1);
        ske.AnimationName = "stand 2";
    }

    private void clickUIConvat()
    {
        if (timeeat > 0)
        {
            obj.transform.position = transform.position + new Vector3(-0.5f, 1f, 0);
            StartCoroutine(day_timerangoai());
        }
        else
        {
            GameManager.instance.canvasga.transform.position = transform.position + new Vector3(-1f, 1f, 0);
            GameManager.instance.canvasga.GetComponent<VatNuoiPopUp>().doianh(id_convat);
        }
    }
    private void OnMouseDown()
    {
        GameManager.instance.dayCanvas_rangoai();
        clickUIConvat();
    }

    public void ChangeAnim(int id)
    {
        obj = Instantiate(GameManager.instance.hienthoigian);
        timeeat = GameManager.instance.dataVatNuoi.data[id].time;
        Maxtime = GameManager.instance.dataVatNuoi.data[id].time;
        ske.AnimationName = "eating";
        StartCoroutine(wait(id));
    }
    IEnumerator day_timerangoai()
    {
        yield return new WaitForSeconds(2f);
        obj.transform.position = new Vector3(999f, 999f, 0);
    }

    IEnumerator wait(int id)
    {
        obj.GetComponent<hienthoigian>().UpdateTime(timeeat, Maxtime);
        yield return new WaitForSeconds(1f);
        timeeat--;
        if (timeeat > 0)
        {
            StartCoroutine(wait(id));
        }
        else if (timeeat == 0)
        {
            ske.AnimationName = "stand 1";
            Destroy(obj);
            th = true;
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("chuongga"))
        {
            if (gameObject.transform.CompareTag("conga"))
            {

                if (GameManager.instance.dataui.data[0].giatri >= GameManager.instance.datashopconvat.data[1].Gia)
                {
                    if (collision.gameObject.transform.GetChild(1).gameObject.activeSelf == false)
                    {
                        collision.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                        gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
                        GameManager.instance.datashopconvat.data[1].sl++;
                        GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopconvat.data[1].Gia;
                    }
                    else
                    {
                        if (collision.gameObject.transform.GetChild(2).gameObject.activeSelf == false)
                        {
                            collision.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                            gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
                            GameManager.instance.datashopconvat.data[1].sl++;
                            GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopconvat.data[1].Gia;
                        }
                        else
                        {
                            if (collision.gameObject.transform.GetChild(3).gameObject.activeSelf == false)
                            {
                                collision.gameObject.transform.GetChild(3).gameObject.SetActive(true);
                                gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
                                GameManager.instance.datashopconvat.data[1].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopconvat.data[1].Gia;
                            }
                        }
                    }
                    
                }
                else
                {
                    Debug.Log("lượng vàng không đủ");
                }

            }
        }
        else if (collision.gameObject.CompareTag("chuongbo"))
        {
            if (gameObject.transform.CompareTag("conbo"))
            {
                if (GameManager.instance.dataui.data[0].giatri >= GameManager.instance.datashopconvat.data[3].Gia)
                {
                    if (collision.gameObject.transform.GetChild(1).gameObject.activeSelf == false)
                    {
                        collision.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                        gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
                        GameManager.instance.datashopconvat.data[3].sl++;
                        GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopconvat.data[3].Gia;
                    }
                    else
                    {
                        if (collision.gameObject.transform.GetChild(2).gameObject.activeSelf == false)
                        {
                            collision.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                            gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
                            GameManager.instance.datashopconvat.data[3].sl++;
                            GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopconvat.data[3].Gia;
                        }
                        else
                        {
                            if (collision.gameObject.transform.GetChild(3).gameObject.activeSelf == false)
                            {
                                collision.gameObject.transform.GetChild(3).gameObject.SetActive(true);
                                gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
                                GameManager.instance.datashopconvat.data[3].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopconvat.data[3].Gia;
                            }
                        }
                    }
                    
                }
                else
                {
                    Debug.Log("lượng vàng không đủ");
                }
            }
        }
        else if (collision.gameObject.CompareTag("chuonglon"))
        {
            if (gameObject.transform.CompareTag("conlon"))
            {
                if (GameManager.instance.dataui.data[0].giatri >= GameManager.instance.datashopconvat.data[5].Gia)
                {
                    if (collision.gameObject.transform.GetChild(1).gameObject.activeSelf == false)
                    {
                        collision.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                        GameManager.instance.datashopconvat.data[5].sl++;
                        GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopconvat.data[5].Gia;
                    }
                    else
                    {
                        if (collision.gameObject.transform.GetChild(2).gameObject.activeSelf == false)
                        {
                            collision.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                            GameManager.instance.datashopconvat.data[5].sl++;
                            GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopconvat.data[5].Gia;

                        }
                        else
                        {
                            if (collision.gameObject.transform.GetChild(3).gameObject.activeSelf == false)
                            {
                                collision.gameObject.transform.GetChild(3).gameObject.SetActive(true);
                                gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                                GameManager.instance.datashopconvat.data[5].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopconvat.data[5].Gia;
                            }
                        }
                    }
                    
                }
                else
                {
                    Debug.Log("lượng vàng không đủ");
                }
            }
        }
        else if (collision.gameObject.CompareTag("chuongcuu"))
        {
            if (gameObject.transform.CompareTag("concuu"))
            {
                if (GameManager.instance.dataui.data[0].giatri >= GameManager.instance.datashopconvat.data[7].Gia)
                {
                    if (collision.gameObject.transform.GetChild(1).gameObject.activeSelf == false)
                    {
                        collision.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                        GameManager.instance.datashopconvat.data[7].sl++;
                        GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopconvat.data[7].Gia;

                    }
                    else
                    {
                        if (collision.gameObject.transform.GetChild(2).gameObject.activeSelf == false)
                        {
                            collision.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                            GameManager.instance.datashopconvat.data[7].sl++;
                            GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopconvat.data[7].Gia;
                        }
                        else
                        {
                            if (collision.gameObject.transform.GetChild(3).gameObject.activeSelf == false)
                            {
                                collision.gameObject.transform.GetChild(3).gameObject.SetActive(true);
                                gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                                GameManager.instance.datashopconvat.data[7].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopconvat.data[7].Gia;
                            }
                        }
                    }
                    
                }
                else
                {
                    Debug.Log("lượng vàng không đủ");
                }
            }
        }
        else if (collision.gameObject.CompareTag("chuongde"))
        {
            if (gameObject.transform.CompareTag("conde"))
            {
                if (GameManager.instance.dataui.data[0].giatri >= GameManager.instance.datashopconvat.data[9].Gia)
                {
                    if (collision.gameObject.transform.GetChild(1).gameObject.activeSelf == false)
                    {
                        collision.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                        GameManager.instance.datashopconvat.data[9].sl++;
                        GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopconvat.data[9].Gia;
                    }
                    else
                    {
                        if (collision.gameObject.transform.GetChild(2).gameObject.activeSelf == false)
                        {
                            collision.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                            GameManager.instance.datashopconvat.data[9].sl++;
                            GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopconvat.data[9].Gia;
                        }
                        else
                        {
                            if (collision.gameObject.transform.GetChild(3).gameObject.activeSelf == false)
                            {
                                collision.gameObject.transform.GetChild(3).gameObject.SetActive(true);
                                gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                                GameManager.instance.datashopconvat.data[9].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopconvat.data[9].Gia;
                            }
                        }
                    }
                    
                }
                else
                {
                    Debug.Log("lượng vàng không đủ");
                }

            }
        }
        else if (collision.gameObject.CompareTag("chuongngua"))
        {
            if (gameObject.transform.CompareTag("conngua"))
            {
                if (GameManager.instance.dataui.data[0].giatri >= GameManager.instance.datashopconvat.data[11].Gia)
                {
                    if (collision.gameObject.transform.GetChild(1).gameObject.activeSelf == false)
                    {
                        collision.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                        GameManager.instance.datashopconvat.data[11].sl++;
                        GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopconvat.data[11].Gia;
                    }
                    else
                    {
                        if (collision.gameObject.transform.GetChild(2).gameObject.activeSelf == false)
                        {
                            collision.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                            GameManager.instance.datashopconvat.data[11].sl++;
                            GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopconvat.data[11].Gia;
                        }
                        else
                        {
                            if (collision.gameObject.transform.GetChild(3).gameObject.activeSelf == false)
                            {
                                collision.gameObject.transform.GetChild(3).gameObject.SetActive(true);
                                gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                                GameManager.instance.datashopconvat.data[11].sl++;
                                GameManager.instance.dataui.data[0].giatri -= GameManager.instance.datashopconvat.data[11].Gia;
                            }
                        }
                    }
                    
                }
                else
                {
                    Debug.Log("lượng vàng không đủ");
                }
            }
        }
    }

    public void ShowSeedUI()
    {

    }

}
