using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Player player;
    private ButtonHandler buttonHandler;
    public bool isFlap = false;
    public bool isSlide = false;
    private bool isGrounded = false;

    void Start()
    {
        player = GetComponent<Player>();
        buttonHandler = FindObjectOfType<ButtonHandler>();
    }

    void Update()
    {
        if (player == null) return;

        HandleJump();
        if (!isFlap) HandleSlide();
    }

    void FixedUpdate()
    {
        if (player == null) return;
        Move();
    }

    private void Move()
    {
        if (player.rigid == null) return;

        player.rigid.velocity = new Vector2(player.playerSpeed, player.rigid.velocity.y);
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, LayerMask.GetMask("Ground"));

        if (isGrounded)
        {
            player.jumpCount = 0;
            isFlap = false;
        }
    }

    public void HandleJump()
    {
        if (!isFlap || player.jumpCount >= player.maxJumpCount) return;

        Jump();
        player.jumpCount++;
        isFlap = false;
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
        if (isFlap) return;
        if (isSlide) Slide();
        else ResetSlide();
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