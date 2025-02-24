using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigid { get; private set; }
    public BoxCollider2D coll { get; private set; }

    public int playerMaxHealth = 100;
    public int playerHealth = 100;
    public float jumpForce = 5f;
    public float playerSpeed = 5f;
    public int maxJumpCount = 2;
    public int jumpCount = 0;
    public bool isAlive = true;
    public bool isDamage = false;
    public bool isInvincible = false;
    public float invincibleTime = 1.5f;

    public Vector2 originalColliderSize { get; private set; }

    void Awake()
    {
        rigid = GetComponentInChildren<Rigidbody2D>();
        coll = GetComponentInChildren<BoxCollider2D>();

        if (rigid == null)
        {
            Debug.LogError("Player: Rigidbody2D를 찾을 수 없습니다!");
        }
        if (coll == null)
        {
            Debug.LogError("Player: BoxCollider2D를 찾을 수 없습니다!");
        }

        originalColliderSize = coll != null ? coll.size : Vector2.zero;
    }
    private void Update()
    {
        if (transform.position.x > 0f)
        {
            TimeManager.Instance.AddGameTime(transform.position.x); //한픽셀움직인거리당 3분씩 더해지도록
        }
    }
}


