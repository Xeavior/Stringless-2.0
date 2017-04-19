using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public float speed, jumpForce;

    public bool facingRight;

    private Rigidbody2D rb2d;
    private int hasJumped;
    private Animator anim;

    // Use this for initialization
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //this section of if statements represents the movement of the player, allows diagonal movement
        /*if (Input.GetKey("w"))
        {
            transform.Translate(new Vector2(0, 1) * speed * Time.deltaTime);
        }

        if (Input.GetKey("s"))
        {
            transform.Translate(new Vector2(0, -1) * speed * Time.deltaTime);
        }*/

        if (hasJumped > 0 && Input.GetKey("d"))
        {
            transform.Translate(new Vector2(1, 0) * speed * Time.deltaTime);
            anim.SetTrigger("WasRight");
            anim.ResetTrigger("MovingRight");
            facingRight = true;
        }
        else if (Input.GetKey("d"))
        {
            transform.Translate(new Vector2(1, 0) * speed * Time.deltaTime);
            anim.SetTrigger("MovingRight");
            anim.ResetTrigger("MovingLeft");
            anim.ResetTrigger("WasLeft");
            anim.ResetTrigger("WasRight");
            facingRight = true;
        }

        if (hasJumped > 0 && Input.GetKey("a"))
        {
            transform.Translate(new Vector2(-1, 0) * speed * Time.deltaTime);
            anim.SetTrigger("WasLeft");
            anim.ResetTrigger("MovingLeft");
            facingRight = false;
        }
        else if (Input.GetKey("a"))
        {
            transform.Translate(new Vector2(-1, 0) * speed * Time.deltaTime);
            anim.SetTrigger("MovingLeft");
            anim.ResetTrigger("MovingRight");
            anim.ResetTrigger("WasLeft");
            anim.ResetTrigger("WasRight");
            facingRight = false;
        }

        if (Input.GetKeyUp("a"))
        {
            anim.SetTrigger("WasLeft");
            anim.ResetTrigger("MovingLeft");
        }


        

        if (Input.GetKeyUp("d"))
        {
            anim.SetTrigger("WasRight");
            anim.ResetTrigger("MovingRight");
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (hasJumped != 2)
            {
                rb2d.velocity = new Vector2(0, 1 * jumpForce);
                hasJumped++;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "platform")
        {
            hasJumped = 0;
        }
    }
}
