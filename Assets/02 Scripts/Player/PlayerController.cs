using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Player player;
    private ButtonHandler buttonHandler;
    public bool isJumping = false;
    public bool isFlap = false; 
    public bool isSlide = false; 
    void Start()
    {
        player = GetComponent<Player>();
        buttonHandler = FindObjectOfType<ButtonHandler>();
    }

    void Update()
    {
        if (player == null) return;

        HandleJump();
        if (!isJumping)  
        {
            HandleSlide();
        }
    }

    void FixedUpdate()
    {
        if (player == null) return;

        Move();
    }

    private void Move()
    {
        if (player.rigid != null)
        {
            player.rigid.velocity = new Vector2(player.playerSpeed, player.rigid.velocity.y);
        }
    }

    public void HandleJump()
    {
        if (isFlap)
        {
            if (player.jumpCount < player.maxJumpCount)
            {
                Jump();
                player.jumpCount++;
                isFlap = false;
                isJumping = true;
            }
        }
        if (player.rigid.velocity.y == 0)
        {
            player.jumpCount = 0;
            isJumping = false;
        }
    }

    private void Jump()
    {
        if (player.rigid != null)
        {
            player.rigid.velocity = new Vector2(player.rigid.velocity.x, player.jumpForce);
        }
    }

    public void HandleSlide()
    {
        if (isJumping) return;
        if (isSlide)
        {
            Slide();
         
        }
        else 
        {
            ResetSlide();
        }
    }

    private void Slide()
    {
        if (player.coll != null)
        {
            player.coll.size = new Vector2(player.originalColliderSize.x, player.originalColliderSize.y * 0.5f);
        }
    }

    private void ResetSlide()
    {
        if (player.coll != null)
        {
            player.coll.size = player.originalColliderSize;
        }
    }
}


