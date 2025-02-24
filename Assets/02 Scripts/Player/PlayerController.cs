using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = GetComponent<Player>();

        if (player == null)
        {
            Debug.LogError("PlayerController: Player 컴포넌트를 찾을 수 없습니다!");
            return;
        }
    }

    void Update()
    {
        if (player == null) return;

        HandleJump();
        HandleSlide();
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

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (player.jumpCount < player.maxJumpCount)
            {
                Jump();
                player.jumpCount++;
            }
        }
        if (player.rigid.velocity.y == 0)
        {
            player.jumpCount = 0;
        }
    }

    private void Jump()
    {
        if (player.rigid != null)
        {
            player.rigid.velocity = new Vector2(player.rigid.velocity.x, player.jumpForce);
        }
    }

    private void HandleSlide()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Slide();
        }
        else if (Input.GetMouseButtonUp(0))
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


