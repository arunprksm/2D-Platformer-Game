using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    PlayerController playerController;
    PlayerHealth playerHealth;
    private bool mustPatorl;
    private bool mustFlip;

    [SerializeField] private float enemySpeed;
    public Transform enemyGroundCheckPos;
    public LayerMask groundLayer;

    public GameObject player;
    private Transform playerPos;
    private Vector2 currentPos;
    [SerializeField] private float playerDistance;

    private Rigidbody2D enemyRigidbody2D;
    public Collider2D enemyBodyCollider;

    private Animator enemyAnimator;

    private void Start()
    {
        enemyRigidbody2D = GetComponent<Rigidbody2D>();
        mustPatorl = true;

        playerPos = player.GetComponent<Transform>();
        currentPos = GetComponent<Transform>().position;
        enemyAnimator = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (mustPatorl)
        {
            EnemyPatrol();
            EnemyChase();
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
            StartCoroutine(playerController.PlayerHurt());
            GameControlScript.health -= 1;
            
            //playerdamage value
            //playerHealth.TakeDamage(10);
        }

        if (collision.gameObject.tag == "DeadLimit")
        {
            Destroy(gameObject);
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


    private void EnemyChase()
    {
        if (Vector2.Distance(transform.position, playerPos.position) < playerDistance)
        {
            float chaseSpeed = enemySpeed * 3;
            enemyRigidbody2D.velocity = new Vector2(chaseSpeed, enemyRigidbody2D.velocity.y);
            enemyAnimator.SetBool("EnemyRun", true);
        }
        else
        {
            enemyAnimator.SetBool("EnemyRun", false);
        }
    }
}