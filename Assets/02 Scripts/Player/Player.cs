using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigid { get; private set; }
    public CapsuleCollider2D coll { get; private set; }

    public int playerMaxHealth = 100;
    public int playerHealth = 100;
    public float jumpForce = 5f;
    public float playerSpeed = 5f;
    public int maxJumpCount = 2;
    public bool isAlive = true;
    public bool isInvincible = false;
    private float invincibleTime = 1.5f;
    public float InvincibleTime { get { return invincibleTime; } }

    public Vector2 originalColliderSize { get; private set; }
    public Vector2 originalColliderOffset { get; private set; }
    StatHandler statHandler;

    void Awake()
    {
        rigid = GetComponentInChildren<Rigidbody2D>();
        coll = GetComponentInChildren<CapsuleCollider2D>();

        if (rigid == null)
        {
            Debug.LogError("Player: Rigidbody2D를 찾을 수 없습니다!");
        }
        if (coll == null)
        {
            Debug.LogError("Player: CapsuleCollider2D를 찾을 수 없습니다!");
        }

        originalColliderSize = coll != null ? coll.size : Vector2.zero;
    }

    private void Start()
    {
        statHandler = GetComponent<StatHandler>();
        StartCoroutine(DecreaseHealthOverTime());
        TimeManager.Instance.AddGameTime(transform.position.x);
    }
    private void Update()
    {
        TimeManager.Instance.AddGameTime(transform.position.x); //한픽셀움직인거리당 3분씩 더해지도록
    }

    private IEnumerator DecreaseHealthOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            statHandler.Damage(1);
            //Debug.Log(playerHealth);

            if (playerHealth <= 0) break;
        }

    }
}


