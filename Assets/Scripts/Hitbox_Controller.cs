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

    // the target of this thingy.
    private GameObject target;
    private PlayerStats ph;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag( "player" );
        rb2d = target.GetComponent<Rigidbody2D>();
        ph = target.GetComponent<PlayerStats>();

        //compensating knockback force
        knockbackForce *= 100;

        this.transform.localScale = new Vector3( width, height, 0f );
	}

	// Update is called once per frame
	void Update () {
        float dx = transform.position.x - target.transform.position.x;
        float dy = transform.position.y - target.transform.position.y;

        float dx2 = dx * dx;
        float dy2 = dy * dy;

        if ( dx2 + dy2 < width/2 )
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
}
