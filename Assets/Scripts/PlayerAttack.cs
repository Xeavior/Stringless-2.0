using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

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

    private GameObject hitbox;

    private bool canAttack = true;

    // Use this for initialization
    void Start () {
        atk_delay_frames = atk_delay * 60;

        initial_delay = atk_delay_frames;

        atk_delay_frames = 0f;

        source = this.gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
        if ( canAttack && Input.GetMouseButtonDown(0))
        {
            hitbox = Instantiate(Resources.Load("Hitbox"), source) as GameObject;

            hitbox.transform.position = new Vector3(
                transform.position.x + ( atk_offset * GetComponent<PlayerMovement>().facingRight ),
                transform.position.y,
                0
            );

            Hitbox_Controller hc = hitbox.GetComponent<Hitbox_Controller>();
            hc.height = atk_height;
            hc.width = atk_width;
            hc.knockbackForce = knockback_force;

            atk_delay_frames = initial_delay;
        }
	}

    void FixedUpdate()
    {
        if (atk_delay_frames > 0f)
        {
            atk_delay_frames--;
            canAttack = false;
        }
        else
        {
            canAttack = true;
        }
    }
}
