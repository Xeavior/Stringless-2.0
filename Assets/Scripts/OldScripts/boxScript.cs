using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxScript : MonoBehaviour {

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
       // Debug.Log("IM BEING TOUCHED BY SOMETHING");
        if (collision.collider.tag == "player")
        {
           // Debug.Log("ITS PLAYER");
            rb.drag = 0;
        }
            
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "player")
        {
            rb.drag = 100;
            rb.Sleep();

        }
    }

}
