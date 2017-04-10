using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//private GameObject HUDCamera;
//private GameObject HUDSprite;

public class Grass : MonoBehaviour {

    public float force;
    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {

        rb2d = GetComponent<Rigidbody2D>();
     //   spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        //this section of if statements represents the movement of the player, allows diagonal movement
        if (Input.GetKey("w"))
        {
            transform.Translate(new Vector2(0, 1) * force * Time.deltaTime);
        }

        if(Input.GetKey("s"))
        {
            transform.Translate(new Vector2(0, -1) * force * Time.deltaTime);
        }

        if(Input.GetKey("d"))
        {
            transform.Translate(new Vector2(1, 0) * force * Time.deltaTime);
        }

        if (Input.GetKey("a"))
        {
            transform.Translate(new Vector2(-1, 0) * force * Time.deltaTime);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.tag == "box")
        {
            rb2d.Sleep();
        }
    }

}
