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

    private Stats ph;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start () {
        //compensating knockback force
        knockbackForce *= 100;

        this.transform.localScale = new Vector3( width, height, 0f );
	}

	// Update is called once per frame
	void Update () {
        if ( GetComponent<Collider2D>().IsTouching( ) )
        {
            ph.DamageDealt( damage );

            rb2d.AddForce(knockbackForce * Vector2.Scale(kbDirection,new Vector2(1,1)).normalized);

            Destroy( this.gameObject );
        }
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
    
    void OnCollisionEnter2D( Collider2D other )
    {
        //TODO: Add in damage to the player/enemy. Make it generic.
    }
}
