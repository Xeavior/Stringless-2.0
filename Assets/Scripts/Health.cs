using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    public GameObject heart1, heart2, heart3;
    public Sprite heartFull, heartHalf, heartEmpty;
    public PlayerStats health;

    public void UpdateHealth(int health)
{  
        switch(health)
            {
             case 0:
                heart1.GetComponent<SpriteRenderer>().sprite = this.heartEmpty;
                heart2.GetComponent<SpriteRenderer>().sprite = this.heartEmpty;
                heart3.GetComponent<SpriteRenderer>().sprite = this.heartEmpty;
                break;
             case 10:
                heart1.GetComponent<SpriteRenderer>().sprite = this.heartHalf;
                heart2.GetComponent<SpriteRenderer>().sprite = this.heartEmpty;
                heart3.GetComponent<SpriteRenderer>().sprite = this.heartEmpty;
                break;
             case 20:
                heart1.GetComponent<SpriteRenderer>().sprite = this.heartFull;
                heart2.GetComponent<SpriteRenderer>().sprite = this.heartEmpty;
                heart3.GetComponent<SpriteRenderer>().sprite = this.heartEmpty;
                break;
            case 30:
                heart1.GetComponent<SpriteRenderer>().sprite = this.heartFull;
                heart2.GetComponent<SpriteRenderer>().sprite = this.heartHalf;
                heart3.GetComponent<SpriteRenderer>().sprite = this.heartEmpty;
                break;
            case 40:
                heart1.GetComponent<SpriteRenderer>().sprite = this.heartFull;
                heart2.GetComponent<SpriteRenderer>().sprite = this.heartFull;
                heart3.GetComponent<SpriteRenderer>().sprite = this.heartEmpty;
                break;
            case 50:
                heart1.GetComponent<SpriteRenderer>().sprite = this.heartFull;
                heart2.GetComponent<SpriteRenderer>().sprite = this.heartFull;
                heart3.GetComponent<SpriteRenderer>().sprite = this.heartHalf;
                break;
            case 60:
                heart1.GetComponent<SpriteRenderer>().sprite = this.heartFull;
                heart2.GetComponent<SpriteRenderer>().sprite = this.heartFull;
                heart3.GetComponent<SpriteRenderer>().sprite = this.heartFull;
                break;
        }
    }


}

