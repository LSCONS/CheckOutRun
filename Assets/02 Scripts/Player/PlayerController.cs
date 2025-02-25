using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Player player;
    private StatHandler statHandler;
    private DataManager dataManager;
    public AudioClip hitSFX, pickupCoinSFX;
    public bool isFlap = false;
    public bool isSlide = false;
    private bool isGrounded = false;
    private bool wasGrounded = false;
    void Start()
    {
        player = GetComponent<Player>();
        statHandler = GetComponent<StatHandler>();
        dataManager = DataManager.Instance;
        dataManager.Init();
    }

    void Update()
    {
        if (player == null) return;
        if (!isSlide&&Input.GetKeyDown(KeyCode.Space)) // 스페이스바로 점프
        {
            isFlap = true;
        }

        if (Input.GetKey(KeyCode.RightShift)) // 쉬프트가 눌려 있는 동안 슬라이드
        {
            isSlide = true;
        }
        else
        {
            isSlide = false; // 쉬프트가 눌리지 않으면 슬라이드 해제
        }

        Move();
    }

    void FixedUpdate()
    {
        if (player == null) return;
        
        HandleJump();
        if (!isFlap) HandleSlide();
    }

    private void Move()
    {
        if (player.rigid == null) return;

        player.rigid.velocity = new Vector2(player.playerSpeed, player.rigid.velocity.y);
        
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down*0.9f, 1f, LayerMask.GetMask("Ground"));
        Debug.DrawRay(transform.position, Vector2.down*0.8f, Color.green);
        if (isGrounded && !wasGrounded)
        {
            player.jumpCount = 0;
            isFlap = false;
        }

        wasGrounded = isGrounded;
    }

    public void HandleJump()
    {

        if (!isFlap) return;
        if (!isFlap || player.jumpCount >= player.maxJumpCount) return; // 점프 횟수 초과 시 실행 방지

        Jump();
        isFlap = false;
    }

    private void Jump()
    {
        if (player.rigid != null)
        {
            player.rigid.velocity = new Vector2(player.rigid.velocity.x, player.jumpForce);
            player.jumpCount++;
        }
    }

    public void HandleSlide()
    {
        if (isFlap || !isGrounded) return;
        if (isSlide) Slide();
        else ResetSlide();
    }

    private void Slide()
    {
        if (player.coll != null)
        {
            player.coll.size = new Vector2(player.originalColliderSize.x, player.originalColliderSize.y * 0.5f);
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }

    private void ResetSlide()
    {
        if (player.coll != null)
        {
            player.coll.size = player.originalColliderSize;
            transform.rotation = Quaternion.identity;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null)
        {
            return;
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            if (collision.GetComponent<PotionItem>().GetType() == typeof(PotionItem))
            {
                PotionItem item = collision.gameObject.GetComponent<PotionItem>();
                if (item != null)
                {
                    statHandler.Heal(item);
                    item.OnCollisionEffect();
                }
            }

            if (collision.GetComponent<SpeedItem>().GetType() == typeof(SpeedItem))
            {
                SpeedItem item = collision.gameObject.GetComponent<SpeedItem>();
                if (item != null)
                {
                    statHandler.ChangeSpeed(item);
                    item.OnCollisionEffect();
                }
            }

            if (collision.GetComponent<CoinItem>().GetType() == typeof(CoinItem))
            {
                CoinItem item = collision.gameObject.GetComponent<CoinItem>();
                if (item != null)
                {
                    dataManager.AddScore(item.CoinScore);
                    item.OnCollisionEffect();
                }
            }
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            if (SoundManager.Instance != null)
            {
                SoundManager.Instance.sfxManager.PlaySFX(hitSFX, 0.5f);
            }
            statHandler.Damage();
        }
    }
}