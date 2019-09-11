using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot2 : MonoBehaviour {
    
    public GameObject redZone;
    public float maxY;
    private int Rand;
    float[] spR = new float[]{ -4.65f, -1.6f, 1.46f, 4.6f };
    static Random rnd = new Random();
    int r;
    private void Start()
    {
        Invoke("RepeatZone", 10f);
        Invoke("RepeatZone2", 31f);
        Debug.Log("ZoneOnTheWay");
    }
    public void RepeatZone()
    {
        InvokeRepeating("RepeatRedZone", 1, 7);
      
    }
    public void RepeatZone2()
    {
        InvokeRepeating("RepeatRedZone", 1, 5);

    }

    public void RepeatRedZone()
    {
        StartCoroutine("SpawnRedZone");
        //StartCoroutine("SpawnRedZone");
    }
    public void StopFire()
    {
        CancelInvoke("RepeatRedZone");
    }
    IEnumerator SpawnRedZone()
    {
        redZone.SetActive(true);
       // redZone.GetComponent<Animator>().Play("RedZone");
        Rand = Random.Range(0,3);
        Vector3 pos1 = new Vector3(0, spR[Rand], 0);
        GameObject f1 = Instantiate(redZone, pos1, Quaternion.identity) as GameObject;
        Destroy(f1, 5f);

        yield return new WaitForSeconds(2f);
        Debug.Log("BoxColliderAdded");
        var boxCollider2 = f1.AddComponent<BoxCollider2D>();



    }
}
