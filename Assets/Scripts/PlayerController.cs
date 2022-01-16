using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    float playerHorizontal;
    public float playerSpeed;
    bool crouch, jump;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerHorizontal = Input.GetAxisRaw("Horizontal");

        PlayerMovement(playerHorizontal);
        PlayerFlip(playerHorizontal);
        //PlayerJump();
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

    //void PlayerJump()
    //{

    //}

    void PlayerCrouch()
    {
        crouch = Input.GetKeyDown(KeyCode.C);
    }
}
