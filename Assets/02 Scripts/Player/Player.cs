using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D RigidPlayer { get; private set; }
    public CapsuleCollider2D ColliderPlayer { get; private set; }
    public PlayerAnimationHandler PlayerAnimationHandler { get; private set; }
    public int playerMaxHealth = 100;
    public int playerHealth = 100;
    public float jumpForce = 5f;
    public float playerSpeed = 5f;
    public int maxJumpCount = 2;
    public bool isAlive = true;
    private float invincibleTime = 1.5f;
    public float InvincibleTime { get { return invincibleTime; } }

    public Vector2 originalColliderSize { get; private set; }
    public Vector2 originalColliderOffset { get; private set; }
    StatHandler statHandler;

    void Awake()
    {
        RigidPlayer = GetComponentInChildren<Rigidbody2D>();
        ColliderPlayer = GetComponentInChildren<CapsuleCollider2D>();
        PlayerAnimationHandler = GetComponentInChildren<PlayerAnimationHandler>();
        statHandler = GetComponent<StatHandler>();

        if (RigidPlayer == null)
        {
            Debug.LogError("Player: Rigidbody2D를 찾을 수 없습니다!");
        }
        if (ColliderPlayer == null)
        {
            Debug.LogError("Player: CapsuleCollider2D를 찾을 수 없습니다!");
        }

        originalColliderSize = ColliderPlayer != null ? ColliderPlayer.size : Vector2.zero;
    }


    private void Start()
    {
        StartCoroutine(DecreaseHealthOverTime());
        TimeManager.Instance.AddGameTime(transform.position.x);
    }


    private void Update()
    {
        TimeManager.Instance.AddGameTime(transform.position.x); //한픽셀움직인거리당 3분씩 더해지도록
    }


    private IEnumerator DecreaseHealthOverTime()
    {
        while (GameManager.Instance.isWin == false)
        {
            yield return new WaitForSeconds(1f);
            if (GameManager.Instance.isWin) yield break;

            statHandler.Damage(1);

            if (playerHealth <= 0) break;
        }
    }
}


