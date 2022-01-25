using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    PlayerController playerController;
    //PlayerHealth playerHealth;
    private bool mustPatorl;
    private bool mustFlip;

    [SerializeField] private float enemySpeed;
    public Transform enemyGroundCheckPos;
    public LayerMask groundLayer;

    private Rigidbody2D enemyRigidbody2D;
    public Collider2D enemyBodyCollider;

    private void Start()
    {
        enemyRigidbody2D = GetComponent<Rigidbody2D>();
        mustPatorl = true;
    }

    private void Update()
    {
        if (mustPatorl)
        {
            EnemyPatrol();
        }
    }

    private void FixedUpdate()
    {
        if (mustPatorl)
        {
            mustFlip = !Physics2D.OverlapCircle(enemyGroundCheckPos.position, 0.1f, groundLayer);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            //playerdamage value
            //playerHealth.TakeDamage(10);
            playerController.KillPlayer();
        }
    }

    private void EnemyPatrol()
    {
        if (mustFlip || enemyBodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }
        enemyRigidbody2D.velocity = new Vector2(enemySpeed, enemyRigidbody2D.velocity.y);
    }

    private void Flip()
    {
        mustPatorl = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        enemySpeed *= -1;
        mustPatorl = true;
    }
}