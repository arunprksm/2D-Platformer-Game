using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    Rigidbody2D rb;

    public GameObject die;

    float playerHorizontal;
    public float playerSpeed;
    public float playerJumpValue;

    bool playerAlive;

    public bool isGrounded;
    public Transform feetPosition;
    public float checkRadius;
    public LayerMask whatGround;

    float jumpTimeCounter;
    
    public float jumpTime;
    bool isJumping;
    bool crouchAnimation, jumpAnimation, deathAnimation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAlive = true;
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

    bool PlayerIsAlive()
    {
        if (playerAlive == true) return true;
        else return false;
    }

    void PlayerMovement(float playerHorizontal)
    {
        if (PlayerIsAlive() == true && PlayerCrouch() == false)
        {
            Vector2 playerMovement = transform.position;
            playerMovement.x += playerHorizontal * playerSpeed * Time.deltaTime;
            transform.position = playerMovement;
        }

    }
    void PlayerFlip(float playerHorizontal)
    {
        if (PlayerIsAlive()== true)
        {
            animator.SetFloat("Speed", Mathf.Abs(playerHorizontal));

            Vector2 playerFlip = transform.localScale;
            if (playerHorizontal < 0) playerFlip.x = -1f * Mathf.Abs(playerFlip.x);
            else if (playerHorizontal > 0) playerFlip.x = Mathf.Abs(playerFlip.x);
            transform.localScale = playerFlip;
        }
    }

    void PlayerJump()
    {
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, whatGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;

            jumpAnimation = true;
            rb.velocity = Vector2.up * playerJumpValue;
            animator.SetBool("Jump", jumpAnimation);
        }
        else
        {
            jumpAnimation = false;
            animator.SetBool("Jump", jumpAnimation);
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * playerJumpValue;
                jumpTimeCounter -= Time.deltaTime;
                jumpAnimation = true;
                animator.SetBool("Jump", jumpAnimation);
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpAnimation = false;
            isJumping = false;
            animator.SetBool("Jump", jumpAnimation);
        }
    }
    bool PlayerCrouch()
    {
        if (Input.GetKey(KeyCode.C) && isGrounded == true)
        {
            crouchAnimation = true;
            animator.SetBool("Crouch", crouchAnimation);
            return true;
        }
        else
        {
            crouchAnimation = false;
            animator.SetBool("Crouch", crouchAnimation);
            return false;
        }
    }

    internal bool PickUpKey()
    {
        return true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            deathAnimation = true;
            animator.SetBool("Death", deathAnimation);
            playerAlive = false;
        }
    }
}
