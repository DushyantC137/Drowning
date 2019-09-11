using UnityEngine;

public class Movement : MonoBehaviour {
    public float jumpPower;
    public bool GameOver = false;
    Rigidbody2D rb;
    public GameObject Slayer;
    public GameObject particle;
    public GameObject Evil;
   
    


    private void Start()
    {
        rb = Slayer.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {                
         if (Input.touchCount>0)//Input.GetKey(KeyCode.Space))
         { 
          rb.AddForce(Vector2.up * jumpPower);
            rb.gravityScale = 1;
        } 
    }  
}

