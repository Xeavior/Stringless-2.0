using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public int max_health;

    private int current_health;

    // Use this for initialization
    void Start()
    {
        current_health = max_health;
    }

    void FixedUpdate()
    {
        if (current_health == 0)
        {
            GameObject gco = GameObject.FindGameObjectWithTag("GameController");
            GameController gc = gco.GetComponent<GameController>();

            Destroy(this.gameObject);
            gc.Death();
        }
    }

    public
    void DamageDealt(int damage)
    {
        current_health -= damage;
        if (current_health < 0)
        {
            current_health = 0;
        }

        Debug.Log("Damage taken: " + damage.ToString());
    }
}
