using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAnimationController : MonoBehaviour {

    private Rigidbody2D rb;
    public GameObject target;
    private Animator anim;
    private Vector2 dir;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("PlayerCharacter");
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        dir = (target.transform.position - transform.position).normalized;

        if (target != null)
        {
            if (rb.velocity.x < 0)
            {
                anim.SetTrigger("walkLeft");
                anim.ResetTrigger("walkRight");
                anim.ResetTrigger("faceLeft");
            }
            else if (rb.velocity.x > 0)
            {
                anim.SetTrigger("walkRight");
                anim.ResetTrigger("walkLeft");
                anim.ResetTrigger("faceLeft");
            }
            else if (rb.velocity.x == 0)
            {
                anim.SetTrigger("faceLeft");
                anim.ResetTrigger("walkLeft");
            }

        }
    }
}
