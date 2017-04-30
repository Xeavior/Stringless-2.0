using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox_Controller : MonoBehaviour {

    // how long the hitbox can live.
    public float time_to_live;

    // the size of the hitbox.
    public float width;
    public float height;

    // the damage and knockback the hitbox is to deal.
    public int damage;
    public float knockbackForce;
    public Vector2 kbDirection;

    // Use this for initialization
    void Start () {
        //compensating knockback force
        knockbackForce *= 100;

        this.transform.localScale = new Vector3( width, height, 0f );
	}

	// Update is called once per frame
	void Update () {
	}

    void FixedUpdate () {
        if ( time_to_live <= 0.0f )
        {
            Destroy( this.gameObject );
        }
        else
        {
            time_to_live -= 0.5f;
        }
    }

    void OnTriggerEnter2D( Collider2D other )
    {
        //Debug.Log(other.tag);

        //have to handle stats-less objects in scene
        if (other.tag == "platform")
            return;

        Stats stats = other.GetComponent<Stats>();

        stats.DamageDealt( damage );
        other.GetComponent<Rigidbody2D>().AddForce(kbDirection * knockbackForce);

        Destroy( this.gameObject );
    }
}
