using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlScript : MonoBehaviour
{
    //public GameObject heart1, heart2, heart3, heart4, heart5, heart6;
    public GameObject[] heart; //, heart2, heart3, heart4, heart5, heart6;

    public static int health;
    public PlayerController playerController;

    private void Awake()
    {
        
        playerController = FindObjectOfType<PlayerController>();
        
    }
    private void Start()
    {
        ControlHeart();
    }

    private void ControlHeart()
    {
        health = 6;
        heart = GameObject.FindGameObjectsWithTag("FullHealth");

        for (int i = 0; i < heart.Length; i++)
        {
            heart[i].SetActive(true);
        }
    }

    private void Update()
    {
        if (health > 6) health = 6;
        if (health <= 0) health = 0;

        int startingHealth = heart.Length;
        int currentHealth = health;
        //if (health < startingHealth)
        //{
        //    heart[health].SetActive(false);
        //}

        if (currentHealth != startingHealth)
        {
            heart[health].SetActive(false);
        }
        if (health <= 0)
        {
            playerController.PlayerKill();
        }
    }
}
/*
        switch (health)
        {
            case 6:
                {
                    heart1.SetActive(true);
                    heart2.SetActive(true);
                    heart3.SetActive(true);
                    heart4.SetActive(true);
                    heart5.SetActive(true);
                    heart6.SetActive(true);
                }
                break;
            case 5:
                {
                    heart1.SetActive(true);
                    heart2.SetActive(true);
                    heart3.SetActive(true);
                    heart4.SetActive(true);
                    heart5.SetActive(true);
                    heart6.SetActive(false);
                }
                break;
            case 4:
                {
                    heart1.SetActive(true);
                    heart2.SetActive(true);
                    heart3.SetActive(true);
                    heart4.SetActive(true);
                    heart5.SetActive(false);
                    heart6.SetActive(false);
                }
                break;
            case 3:
                {
                    heart1.SetActive(true);
                    heart2.SetActive(true);
                    heart3.SetActive(true);
                    heart4.SetActive(false);
                    heart5.SetActive(false);
                    heart6.SetActive(false);
                }
                break;
            case 2:

                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(false);
                heart4.SetActive(false);
                heart5.SetActive(false);
                heart6.SetActive(false);

                break;
            case 1:

                heart1.SetActive(true);
                heart2.SetActive(false);
                heart3.SetActive(false);
                heart4.SetActive(false);
                heart5.SetActive(false);
                heart6.SetActive(false);

                break;
            case 0:

                heart1.SetActive(false);
                heart2.SetActive(false);
                heart3.SetActive(false);
                heart4.SetActive(false);
                heart5.SetActive(false);
                heart6.SetActive(false);
                playerController.PlayerKill();
                break;
        }

        currentHealth = health;
    }    
}
    */