using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    private Rigidbody2D box2;
    public bool isPushed;
	// Use this for initialization
	void Start () {
        isPushed = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<Collider2D>().tag == "box")
        {
            isPushed = true;
            Debug.Log("The button has been pushed.");
        }
            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.GetComponent<Collider2D>().tag == "box")
        {
            isPushed = false;
            Debug.Log("The button is not pushed.");
        }

    }
}
