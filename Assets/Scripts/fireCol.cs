using UnityEngine;

public class fireCol : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Evil;
    public GameObject particle; 
    private void OnCollisionEnter2D(Collision2D col)
    {
        
            
        if (col.gameObject.tag == "FireBall" || col.gameObject.tag=="RedZone")
        {
            GameManagerScript.instance.GameOver();
            this.gameObject.SetActive(false);
            Instantiate(particle, transform.position, Quaternion.Euler(90, 0, 0));
            Evil.GetComponent<Shoot1>().StopFire();
            Camera.GetComponent<Animator>().Play("CameraShake");
            FindObjectOfType<AudioMan>().Play("Fire");
            FindObjectOfType<AudioMan>().Play("RedZone");
        }

        Debug.Log("Collision");


    }
}

    //-------------------------Dead
    