using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public GameObject lHeart, mHeart, rHeart;
    private Image heart1, heart2, heart3;
    public Sprite heartFull, heartHalf, heartEmpty;
    public PlayerStats health;
    private GameObject player;
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        heart1 = lHeart.GetComponent<Image>();
        heart2 = mHeart.GetComponent<Image>();
        heart3 = rHeart.GetComponent<Image>();
        health = player.GetComponent<PlayerStats>();
    }
    public void UpdateHealth(int health)
{  
        switch(health)
            {
             case 0:
                heart1.sprite = heartEmpty;
                break;
             case 10:
                heart1.sprite = heartHalf;
                break;
             case 20:
                heart2.sprite = heartEmpty;
                break;
            case 30:
                heart2.sprite = heartHalf;
                break;
            case 40:
                heart3.sprite = heartEmpty;
                break;
            case 50:
                heart3.sprite = heartHalf;
                break;
            case 60:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                break;
        }
    }


}

