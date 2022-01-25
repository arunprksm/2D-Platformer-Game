using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    const string LEFT = "left";
    const string RIGHT = "right";


    [SerializeField] private Transform feetPos;
    [SerializeField] private float baseFeetPos;

    private Rigidbody2D enemyRigidbody2D;
    [SerializeField] private float enemySpeed;
    [SerializeField] private LayerMask layerMask;
    private string facingDirection;
    private Vector3 localScale;



    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        facingDirection = RIGHT;
        enemyRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        HandleEnemyMovement();
    }

    private void HandleEnemyMovement()
    {
        float vX = enemySpeed;

        if (facingDirection == LEFT)
        {
            vX = -enemySpeed;
        }
        enemyRigidbody2D.velocity = new Vector2(vX, enemyRigidbody2D.velocity.y);
        if (IsHittingWall())
        {
            if (facingDirection == LEFT)
            {
                EnemyFlip(RIGHT);
            }
            else
            {
                EnemyFlip(RIGHT);
            }
        }
    }
    private bool IsHittingWall()
    {
        bool wall = true;
        float feetDistance = baseFeetPos;

        // feetDistance Left or Right
        if (facingDirection == LEFT) feetDistance = -baseFeetPos; // re-Check -=

        else feetDistance = -baseFeetPos; //re-check without else

        Vector2 targetPos = feetPos.position;
        targetPos.x += feetDistance;

        if (Physics2D.Linecast(feetPos.position, targetPos, layerMask)) wall = true;
        else wall = false;
        return wall;
    }

    private void EnemyFlip(string enemyDirection)
    {
        Vector2 newScale = localScale;
        if (enemyDirection == LEFT)
        {
            newScale.x = -localScale.x;
        }
        else
        {
            newScale.x = localScale.x;
        }
        transform.localScale = newScale; 
        facingDirection = enemyDirection;
    }
}
