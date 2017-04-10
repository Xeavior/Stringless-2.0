using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockedBox : MonoBehaviour {

    private Rigidbody2D rb;
    public GameObject button;
    private Animator anim;
    private bool closed = false, opened = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        button = GameObject.Find("button");
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (button != null)
        {
            if (!button.GetComponent<ButtonScript>().isPushed)
            {
                anim.SetTrigger("doorClose");
                anim.SetTrigger("isClosed");
                anim.ResetTrigger("doorOpen");
                anim.ResetTrigger("isOpened");
            }
            else if (button.GetComponent<ButtonScript>().isPushed)
            {
                anim.SetTrigger("doorOpen");
                anim.SetTrigger("isOpened");
                anim.ResetTrigger("doorClose");
                anim.ResetTrigger("isClosed");                
            }
        }
    }
}
