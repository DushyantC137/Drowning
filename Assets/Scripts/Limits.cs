using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Limits : MonoBehaviour
{
    public bool GameOver = false;
    public GameObject particle;
    public GameObject slayer;
    public GameObject Evil;
    float angle;
    int flag = 0;
 
    Vector3 slayerpos;
    
    private void Update()
    {
        if (!GameOver)
        {
            try
            {
                slayerpos = slayer.transform.position;
            }
            catch (Exception)
            {
                GameOver = true;
            }
            }
        if (slayerpos.y >= 4.15 || slayerpos.y <= -4.1 || slayerpos.x >= 3 || slayerpos.x <= -3)
        {
            
            GameOver = true;
            
        }
        if (GameOver == true)
        {   //Stopping Fire 
            Evil.GetComponent<Shoot1>().StopFire();
            //Player Dead
            slayer.SetActive(false); 
            GameManagerScript.instance.GameOver();
            if (flag == 0)
            {
                Debug.Log("AudioFall");
                FindObjectOfType<AudioMan>().Play("Fall");
                flag = 1;
            }
            
        }
        
            

    }
}
