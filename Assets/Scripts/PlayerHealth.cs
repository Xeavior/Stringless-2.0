using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int max_health;

    private int current_health;

	// Use this for initialization
	void Start () {
        current_health = max_health;
	}

    void FixedUpdate()
    {
        if ( current_health == 0 )
        {
            // TODO: player death
            Debug.Log( "DED\n\n" );
        }
    }

    public
    void DamageDealt( int damage )
    {
        current_health -= damage;
        if ( current_health < 0 )
        {
            current_health = 0;
        }

        Debug.Log( "Damage taken: " + damage.ToString() );
    }
}
