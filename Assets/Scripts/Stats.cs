using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

    public int max_health;

    public int current_health;

    public float waitTime;

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

public void DamageDealt(int damage)
    {
        current_health -= damage;

        this.gameObject.GetComponent<Health>().UpdateHealth(current_health);

        //make the player flash red using this.
        StartCoroutine(ColorFlash());

        if (current_health < 0)
        {
            current_health = 0;
        }

        Debug.Log("Damage taken: " + damage.ToString());
    }

    IEnumerator ColorFlash()
    {

        transform.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(waitTime);
        transform.GetComponent<SpriteRenderer>().color = Color.white;

    }
}
