using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RecieveKN : MonoBehaviour
{
    private bool isRun;
    private bool PointedCoin;
    private int indexArrayCoin;
    private int numberPointsCoin = 15;
    private float speed = 5f;
    private Vector3[] positionCoin;
    public Transform pointerCoin;
    public int numberCoin;
    public int id;
    [SerializeField] GameObject Coin;        //doi tuong bay
    [SerializeField] Text NumberCoinText;   //so coin
    [SerializeField] Transform pointerRight;//vi tri luon xuong
    void Start()
    {
        //if(id==1)
        //    pointerCoin = GameObject.Find("btnHome").transform;
        //if(id==0)
        //    pointerCoin = GameObject.Find("Kinhnghiem").transform;
        pointerCoin = GameObject.Find("iconcoin1234").transform;
        positionCoin = new Vector3[numberPointsCoin];
        //NumberCoinText.text = "+" + numberCoin;
        DrawQuadraticCurveItem();
        StartCoroutine(waitRun());
        isRun = true;
    }
    void DrawQuadraticCurveItem()
    {
        for (int i = 1; i < numberPointsCoin + 1; i++)
        {
            float t = i / (float)numberPointsCoin;
            positionCoin[i - 1] = CalculateQuadraticBezierPoint(t, transform.position,
                pointerRight.position, pointerCoin.position);
        }
    }
    Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 p = uu * p0;
        p += 2 * u * t * p1;
        p += tt * p2;
        p.z = 0;
        return p;
    }
    IEnumerator upSpeed()
    {
        yield return new WaitForSeconds(0.3f);
        speed += 2f;
        StartCoroutine(upSpeed());
    }
    IEnumerator waitRun()
    {

        yield return new WaitForSeconds(1.5f);
        //gameObject.GetComponent<Animator>().enabled = false;
        isRun = true;
        StartCoroutine(upSpeed());
        yield return new WaitForSeconds(0.3f);
        Coin.SetActive(true);
    }
    void ItemFly()
    {
        DrawQuadraticCurveItem();
        if (Vector3.Distance(Coin.transform.position, positionCoin[indexArrayCoin]) < 0.1f)
        {
            if (indexArrayCoin < positionCoin.Length - 1) indexArrayCoin = indexArrayCoin + 1;
        }
        if (Vector3.Distance(Coin.transform.position, positionCoin[numberPointsCoin - 1]) < 0.1f)
        {
            if (PointedCoin == false)
            {
                //bay den vi tri va cong tien
                //if (id == 0)
                //    BatDauGame.instance.tangkinhnghiem(numberCoin);
                Coin.SetActive(false);
                PointedCoin = true;
            }
        }
        Coin.transform.position = Vector3.MoveTowards(Coin.transform.position, positionCoin[indexArrayCoin], Time.deltaTime * speed);
    }
    void Update()
    {
        if (isRun == true)
        {
            ItemFly();
            if (PointedCoin == true)
                Destroy(gameObject);
        }
    }
}
