using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot1 : MonoBehaviour {
    public GameObject fireball;
    public GameObject warning;
    public float thrust;
    public float maxY;
    public float musictime;
    float spawn = 2.52f;
    float Rand;
    Vector3 pos1, pos2, pos3, pos4;
    
    private void Start()
    {
            Invoke("RepeatFire", 1f);
            Debug.Log("FireOnTheWay");
    }
    public void RepeatFire()
    {
        InvokeRepeating("SpawnWarningFire",0,musictime);
      //  InvokeRepeating("SpawnWarningFire", 20f-2*musictime, musictime);
    }
    public void SpawnWarningFire()
    {
        StartCoroutine("SpawnFire");
    }
    public void StopFire()
    {
        CancelInvoke("SpawnWarningFire");
        
    }

    IEnumerator SpawnFire()
    {
        Debug.Log("Warning");
        float Rand = Random.Range(-5.5f, maxY);
         pos1 = new Vector3(-3, Rand, 0);
         pos2 = new Vector3(3, Rand, 0);
        //WarningSpawn
         pos3 = new Vector3(spawn, Rand, 0);
         pos4 = new Vector3(-spawn, Rand, 0);
        GameObject Wrg = Instantiate(warning, pos3, Quaternion.identity) as GameObject;
        GameObject Wrg2 = Instantiate(warning, pos4, Quaternion.identity) as GameObject;
        Destroy(Wrg, 1f);
        Destroy(Wrg2, 1f);
        //1s Gap
        yield return new WaitForSeconds(1f);
        //FireSpawn
        Debug.Log("Fire");
        GameObject f1=Instantiate(fireball, pos1, Quaternion.Euler(0, 0, 100)) as GameObject;
        GameObject f2 = Instantiate(fireball, pos2, Quaternion.Euler(0,0,230)) as GameObject;
        f1.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust, thrust/2), ForceMode2D.Impulse);
        f2.GetComponent<Rigidbody2D>().AddForce(new Vector2(-thrust, thrust/2), ForceMode2D.Impulse);
        Destroy(f1, 3f);
        Destroy(f2, 3f);
        
    }
    
}
