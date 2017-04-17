using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox_Controller : MonoBehaviour {

    // how long the hitbox can live.
    public float time_to_live;

    // the size of the hitbox.
    public float width;
    public float height;

    // the damage the hitbox is to deal.
    public int damage;

    // the target of this thingy.
    private GameObject target;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag( "player" );

        this.transform.localScale = new Vector3( width, height, 0f );
	}

	// Update is called once per frame
	void Update () {
        float dx = this.gameObject.transform.position.x - target.transform.position.x;
        float dy = this.gameObject.transform.position.y - target.transform.position.y;

        float dx2 = dx * dx;
        float dy2 = dy * dy;

        if ( dx2 + dy2 < width/2 )
        {
            PlayerHealth ph = target.GetComponent( typeof( PlayerHealth ) ) as PlayerHealth;
            ph.DamageDealt( damage );
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
