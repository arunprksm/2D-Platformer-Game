using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    public GameObject gameOverTextObject;

    public Animator animator;

    private Rigidbody2D rb;

    public float SpeedProperty
    {
        get
        {
            return playerSpeed;
        }
        set
        {
            SetPlayerSpeed(value);
        }
    }

    //public GameObject die;

    private float playerHorizontal;

    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerJumpValue;

    private bool playerAlive;

    public bool isGrounded;
    public Transform feetPosition;
    public float checkRadius;
    public LayerMask whatGround;

    public float jumpTime, jumpTimeCounter;
    private bool crouchAnimation, jumpAnimation, deathAnimation;
    private bool jumpPressed, isJumping, jumpPressing, jumpPressedReleased, crouchPressed;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        playerAlive = true;
        gameOverTextObject.SetActive(false);
        SetPlayerSpeed(playerSpeed);
    }

    private void Update()
    {
        HandleInput();
        playerFall();
        PlayerJump();
        PlayerMovement(playerHorizontal);
        PlayerFlip(playerHorizontal);
        PlayerCrouch();

        //if( something happens)
        //SetPlayerSpeed(playerSpeed);
    }

    private void HandleInput()
    {
        playerHorizontal = Input.GetAxisRaw("Horizontal");

        jumpPressed = Input.GetKeyDown(KeyCode.Space);
        jumpPressing = Input.GetKey(KeyCode.Space);
        jumpPressedReleased = Input.GetKeyUp(KeyCode.Space);

        crouchPressed = Input.GetKey(KeyCode.C);
    }


    private bool PlayerIsAlive()
    {
        return playerAlive;
        //if (playerAlive == true) return true;
        //else return false;
    }

    public void SetMyProperty(float value)
    {
        playerSpeed = value;
    }
    public void SetPlayerSpeed(float newSpeedValue)
    {
        playerSpeed = newSpeedValue;
        var roundedPlayerSpeed = Mathf.RoundToInt(playerSpeed);
        //UpdatePlayerSpeedUI(roundedPlayerSpeed);
    }

    private void PlayerMovement(float playerHorizontal)
    {
        //SoundManager.Instance.PlayerMove(Sounds.PlayerMove);
        if (PlayerIsAlive() && !PlayerCrouch())
        {
            Vector2 playerMovement = transform.position;
            playerMovement.x += playerHorizontal * playerSpeed * Time.deltaTime;
            transform.position = playerMovement;
        }
    }
    private void PlayerFlip(float playerHorizontal)
    {
        //Guard Clause
        if (!PlayerIsAlive())
        {
            return;
        }

        animator.SetFloat("Speed", Mathf.Abs(playerHorizontal));

        Vector2 playerFlip = transform.localScale;
        if (playerHorizontal < 0) playerFlip.x = -1f * Mathf.Abs(playerFlip.x);
        else if (playerHorizontal > 0) playerFlip.x = Mathf.Abs(playerFlip.x);
        transform.localScale = playerFlip;
    }

    private void playerFall()
    {
        if (!isGrounded && PlayerIsAlive())
        {
            animator.SetBool("Fall", true);
        }
        else
        {
            animator.SetBool("Fall", false);
        }
    }

    private void PlayerJump()
    {
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, whatGround);

        if (isGrounded == true && jumpPressed)
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

        if (jumpPressing && isJumping == true)
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

        if (jumpPressedReleased)
        {
            jumpAnimation = false;
            isJumping = false;
            animator.SetBool("Jump", jumpAnimation);
        }
    }

    private bool PlayerCrouch()
    {
        if (crouchPressed && isGrounded == true && PlayerIsAlive())
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

    internal void PickUpKey()
    {
        scoreController.IncrementScore(10);
    }

    public void PlayerKill()
    {
        StartCoroutine(PlayerDead());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeadLimit")
        {
            PlayerKill();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            animator.SetBool("Hurt", false);
        }
    }
    public IEnumerator PlayerHurt()
    {
        animator.SetBool("Hurt", true);

        yield return new WaitForSeconds(0.2f);
        animator.SetBool("Hurt", false);
    }

    public IEnumerator PlayerDead()
    {
        SoundManager.Instance.PlaySFX(Sounds.PlayerDeath);
        deathAnimation = true;
        animator.SetBool("Death", deathAnimation);
        playerAlive = false;

        yield return new WaitForSeconds(2);
        gameOverTextObject.SetActive(true);
    }
}



//private void UpdatePlayerSpeedUI(float speedTOShow)
//{
//    // TextMesh.text = playerSpeed;
//}



//public void SetMyProperty(float value)
//{
//    playerSpeed = value;
//}

//public float GetMyProeperty()
//{
//    return playerSpeed;
//}