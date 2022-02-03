using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private Transform playerGameObject;
    [SerializeField] private float agroRange;
    [SerializeField] private float enemySpeed;

    private Rigidbody2D rb;

    private void Start()
    {
        InitializeEnemyComponents();
    }

    private void InitializeEnemyComponents()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        float distToPlayer = Vector2.Distance(transform.position, playerGameObject.position);
        //print("distToPlayer: " + distToPlayer);

        if (distToPlayer < agroRange)
        {
            EnemyChasePlayer();
        }
        else
        {
            EnemyStopChasePlayer();
        }
    }

    private void EnemyChasePlayer()
    {
        if (transform.position.x < playerGameObject.position.x)
        {
            rb.velocity = new Vector2(enemySpeed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        else if (transform.position.x > playerGameObject.position.x)
        {
            rb.velocity = new Vector2(-enemySpeed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
    }
    private void EnemyStopChasePlayer()
    {
        rb.velocity = Vector2.zero;
    }
}
