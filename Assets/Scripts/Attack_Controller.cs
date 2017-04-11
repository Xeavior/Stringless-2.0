using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Controller : MonoBehaviour {

    // attack range and aggro range for the creatures
    public float range;

    // amount of damage the creature can do
    public int damage;

    // attack delay
    public float atk_delay;
    public float atk_width;
    public float atk_height;
    private float initial_delay;

    // The transform of the source which is attacking.
    private Transform source;

    // The player that the AI wishes to target.
    private GameObject target;
   // private PlayerHealth target_health;

    // used to ignore roots
    private float range_squared;

    // the distance to the player squared.
    private float distance_to_player;

    // the diffs
    private float dx;
    private float dy;

    private GameObject hitbox;

	// Use this for initialization
	void Start ()
    {
        source = this.GetComponent<Transform>();

        target = GameObject.FindGameObjectWithTag( "player" );

//<<<<<<< HEAD
        //target_health = target.GetComponent( typeof( PlayerHealth ) ) as PlayerHealth;

        range_squared = range * range;

        initial_delay = atk_delay;
//=======
        //target_health = target.GetComponent( typeof( PlayerHealth ) ) as PlayerHealth;
//>>>>>>> 20b7d6d241d932a9a009a5fa52664ed7f8dff990
	}

	// Update is called once per frame
	void Update ()
    {
        if ( target == null )
        {
            target = GameObject.FindGameObjectWithTag( "player" );
            distance_to_player = GetDistanceSquared( target );
        }

        // try to make signed integers for bit fun! :D
        float directionX;
        float directionY;

        if ( distance_to_player <= range_squared && atk_delay == 0.0f )
        {
            hitbox = Instantiate( Resources.Load( "Hitbox" ), source ) as GameObject;
            hitbox.transform.position = new Vector2(
                this.gameObject.transform.position.x,
                this.gameObject.transform.position.y
            );

            atk_delay = initial_delay;
        }
        else if ( distance_to_player <= range_squared )
        {
//<<<<<<< HEAD
            atk_delay -= 1.0f;
//=======
            //target_health.DamageDealt( damage );
//>>>>>>> 20b7d6d241d932a9a009a5fa52664ed7f8dff990
        }

        distance_to_player = GetDistanceSquared( target );
	}

    void FixedUpdate()
    {
    }

    private
    float GetDistanceSquared( GameObject other )
    {
        dx = GetDX( other );
        dy = GetDY( other );

        float dx2 = dx * dx;
        float dy2 = dy * dy;

        return dx2 + dy2;
    }

    private
    float GetDX( GameObject other )
    {
        return source.transform.position.x - other.transform.position.x;
    }

    private
    float GetDY( GameObject other )
    {
        return source.transform.position.y - other.transform.position.y;
    }
}
