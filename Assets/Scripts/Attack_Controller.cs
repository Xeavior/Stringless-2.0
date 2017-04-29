using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Controller : MonoBehaviour {

    // attack range and aggro range for the creatures
    public float range = 2f;

    // amount of damage the creature can do
    public int damage = 10;

    // attack delay
    public float atk_delay = 2f;
    public float atk_width = 1f;
    public float atk_height = 1f;
    public float atk_offset = 1f;
    public float knockback_force = 1f;
    private float atk_delay_frames;
    private float initial_delay;

    // The transform of the source which is attacking.
    private Transform source;

    // used to ignore roots
    private float range_squared;

    // the target of the enemy
    private GameObject target;

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

        range_squared = range * range;

        atk_delay_frames = atk_delay * 60;

        initial_delay = atk_delay_frames;
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

        if ( this.gameObject.transform.position.x > target.transform.position.x )
        {
            directionX = -1;
        }
        else{
            directionX = 1;
        }

        if ( distance_to_player <= range_squared && atk_delay_frames == 0.0f )
        {
            hitbox = Instantiate( Resources.Load( "Hitbox" ), source ) as GameObject;
            hitbox.transform.position = new Vector2(
                this.gameObject.transform.position.x + atk_offset * directionX,
                this.gameObject.transform.position.y
            );

            Hitbox_Controller hc = hitbox.GetComponent<Hitbox_Controller>();
            hc.width = atk_width;
            hc.height = atk_height;
            hc.damage = damage;
            hc.knockbackForce = knockback_force;
            hc.kbDirection = new Vector2(directionX, 1);
            atk_delay_frames = initial_delay;
        }
        else if ( !( atk_delay_frames <= 0f ) )
        {
            atk_delay_frames -= 1.0f;
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
