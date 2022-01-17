using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    Rigidbody2D rb;

    float playerHorizontal;
    public float playerSpeed;
    public float playerJumpValue;

    public bool isGrounded;
    public Transform feetPosition;
    public float checkRadius;
    public LayerMask whatGround;

    float jumpTimeCounter;
    public float jumpTime;
    bool isJumping;

    bool crouch, jump;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHorizontal = Input.GetAxisRaw("Horizontal");

        PlayerJump();
        PlayerMovement(playerHorizontal);
        PlayerFlip(playerHorizontal);

        PlayerCrouch();
    }
    void PlayerMovement(float playerHorizontal)
    {
        Vector3 playerMovement = transform.position;
        playerMovement.x += playerHorizontal * playerSpeed * Time.deltaTime;
        transform.position = playerMovement;
    }
    void PlayerFlip(float playerHorizontal)
    {
        animator.SetFloat("Speed", Mathf.Abs(playerHorizontal));
        Vector3 playerFlip = transform.localScale;
        if (playerHorizontal < 0) playerFlip.x = -1f * Mathf.Abs(playerFlip.x);
        else if (playerHorizontal > 0) playerFlip.x = Mathf.Abs(playerFlip.x);
        transform.localScale = playerFlip;
    }

    void PlayerJump()
    {
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, whatGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            //jump = true;
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * playerJumpValue;
            //animator.SetBool("Jump", jump);
        }
        else
        {
            jump = false;
            animator.SetBool("Jump", jump);
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * playerJumpValue;
                jumpTimeCounter -= Time.deltaTime;
                jump = true;
                animator.SetBool("Jump", jump);
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            jump = false;
            isJumping = false;
            animator.SetBool("Jump", jump);
        }
    }
    void PlayerCrouch()
    {
        if (Input.GetKey(KeyCode.C))
        {
            crouch = true;
            animator.SetBool("Crouch", crouch);
        }
        else
        {
            crouch = false;
            animator.SetBool("Crouch", crouch);
        }
    }
}
