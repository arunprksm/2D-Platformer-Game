using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerFlip();
        //PlayerJump();
    }

    void PlayerFlip()
    {
        speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));
        Vector3 playerFlip = transform.localScale;
        if (speed < 0) playerFlip.x = -1f * Mathf.Abs(playerFlip.x);
        else if (speed > 0) playerFlip.x = Mathf.Abs(playerFlip.x);
        transform.localScale = playerFlip;
    }
}
