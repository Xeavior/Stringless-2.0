using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAnimController : MonoBehaviour
{

    private Rigidbody2D rb;
    public GameObject target;
    private Animator anim;
    private Vector2 dir;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("PlayerCharacter");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        dir = (target.transform.position - transform.position).normalized;

        if (target != null)
        {
            if (rb.velocity.x<0)
            {
                anim.SetTrigger("isLeft");
                anim.ResetTrigger("isRight");
            }
            else if (rb.velocity.x > 0)
            {
                anim.SetTrigger("isRight");
                anim.ResetTrigger("isLeft");
            }

        }
    }

}
