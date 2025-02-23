using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    BoxCollider2D coll;
    public float jumpForce = 5f;
    public float forwardSpeed = 5f;
    public int maxJumpCount = 1;
    public int jumpCount = 0;
    private Vector2 originalColliderSize;

    void Start()
    {
        rigid = GetComponentInChildren<Rigidbody2D>();
        coll = GetComponentInChildren<BoxCollider2D>();
        originalColliderSize = coll.size;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(jumpCount<=maxJumpCount)
            {
                Jump();
                jumpCount++;
            }
        }
        if(rigid.velocity.y == 0)
        {
            jumpCount = 0;
        }
        if(Input.GetMouseButtonDown(0))
        {
            Slide();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            ResetSlide();
        }
    
    }

    void FixedUpdate()
    {
        if (rigid != null)
        {
            rigid.velocity = new Vector2(forwardSpeed, rigid.velocity.y);
        }
    }

    void Jump()
    {
        if (rigid != null)
        {
            rigid.velocity = new Vector2(forwardSpeed, jumpForce);
        }
    }
    public void Slide()
    {
        coll.size = new Vector2(originalColliderSize.x, originalColliderSize.y * 0.5f);
    }

    public void ResetSlide()
    {
        coll.size = originalColliderSize;
    }
}
