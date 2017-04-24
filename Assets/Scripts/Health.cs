using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    public GameObject heart1, heart2, heart3;
    public Sprite heartFull, heartHalf, heartEmpty;
    public PlayerStats health;
    private GameObject player;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        health = player.GetComponent<PlayerStats>();
    }
    public void UpdateHealth()
{  
        switch(health.current_health)
            {
             case 0:
                heart1.GetComponent<SpriteRenderer>().sprite = heartEmpty;
                heart2.GetComponent<SpriteRenderer>().sprite = heartEmpty;
                heart3.GetComponent<SpriteRenderer>().sprite = heartEmpty;
                break;
             case 10:
                heart1.GetComponent<SpriteRenderer>().sprite = heartHalf;
                heart2.GetComponent<SpriteRenderer>().sprite = heartEmpty;
                heart3.GetComponent<SpriteRenderer>().sprite = heartEmpty;
                break;
             case 20:
                heart1.GetComponent<SpriteRenderer>().sprite = heartFull;
                heart2.GetComponent<SpriteRenderer>().sprite = heartEmpty;
                heart3.GetComponent<SpriteRenderer>().sprite = heartEmpty;
                break;
            case 30:
                heart1.GetComponent<SpriteRenderer>().sprite = heartFull;
                heart2.GetComponent<SpriteRenderer>().sprite = heartHalf;
                heart3.GetComponent<SpriteRenderer>().sprite = heartEmpty;
                break;
            case 40:
                heart1.GetComponent<SpriteRenderer>().sprite = heartFull;
                heart2.GetComponent<SpriteRenderer>().sprite = heartFull;
                heart3.GetComponent<SpriteRenderer>().sprite = heartEmpty;
                break;
            case 50:
                heart1.GetComponent<SpriteRenderer>().sprite = heartFull;
                heart2.GetComponent<SpriteRenderer>().sprite = heartFull;
                heart3.GetComponent<SpriteRenderer>().sprite = heartHalf;
                break;
            case 60:
                heart1.GetComponent<SpriteRenderer>().sprite = heartFull;
                heart2.GetComponent<SpriteRenderer>().sprite = heartFull;
                heart3.GetComponent<SpriteRenderer>().sprite = heartFull;
                break;
        }
    }


}

