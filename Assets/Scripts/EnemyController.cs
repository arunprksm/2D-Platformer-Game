using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    PlayerController playerController;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.KillPlayer();
        }
    }
}
