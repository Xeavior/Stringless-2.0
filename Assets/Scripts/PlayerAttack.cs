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
    private float atk_delay_adj;
    private float initial_delay;

    // The transform of the source which is attacking.
    private Transform source;

    private GameObject hitbox;

    private bool canAttack = true;

    // Use this for initialization
    void Start () {
        atk_delay_adj = atk_delay * 10;

        initial_delay = atk_delay_adj;

        atk_delay_adj = 0f;

        source = this.gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
        if ( canAttack && Input.GetMouseButtonDown(0))
        {
            hitbox = Instantiate(Resources.Load("Hitbox"), source) as GameObject;
            //TODO: Add in directional offset for hitbox, located in PlayerMovement.
        }
	}

    void FixedUpdate()
    {
        if (atk_delay_adj > 0f)
        {
            atk_delay_adj--;
            canAttack = false;
        }
        else
        {
            canAttack = true;
        }
    }
}
