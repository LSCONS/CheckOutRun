using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Player player;
    private StatHandler statHandler;
    private DataManager dataManager;
    private PlayerAnimationHandler playerAnimationHandler;
    public bool isJumpFlag = false; // 점프 
    public bool isSlideFlag = false; // 슬라이드
    private bool isGrounded = false; // 플랫폼 오브젝트에

    private void Awake()
    {
        player = GetComponent<Player>();
        statHandler = GetComponent<StatHandler>();
        playerAnimationHandler = GetComponent<PlayerAnimationHandler>();  
    }


    void Start()
    {
        dataManager = DataManager.Instance;
        dataManager.Init();
    }


    void Update()
    {
        if (player == null) return;
        CheckInputAction();
        CancelSlide();
    }


    void FixedUpdate()
    {
        if (player?.RigidPlayer == null) return;
        if (GameManager.Instance.isWin) return;
        CheckGround();
        Move();
        HandleJump();
        HandleSlide();
    }


    /// <summary>
    /// 점프나 슬라이딩 키를 입력했는지 확인하는 메서드
    /// </summary>
    private void CheckInputAction()
    {
        if (!isSlideFlag && Input.GetKeyDown(KeyCode.Space)) // 스페이스바로 점프
        {
            isJumpFlag = true;
            isSlideFlag = false;
        }
        else if (playerAnimationHandler.IsJump1Parameter == false && 
                (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)))
        {
            isSlideFlag = true;
        }
    }


    /// <summary>
    /// 슬라이딩을 취소했을 때 실행하는 메서드
    /// </summary>
    private void CancelSlide()
    {
        if (Input.GetKeyUp(KeyCode.RightShift) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSlideFlag = false;
        }
    }

    
    /// <summary>
    /// 현재 플레이어가 바닥에 닿은 상태인지 확인하는 메서드
    /// </summary>
    private void CheckGround()
    {
        Vector3 temp = transform.position - new Vector3(0.3f, 0, 0);
        isGrounded = Physics2D.Raycast(temp, Vector2.down, 1f, ReadonlyData.GroundLayerMask);
#if UNITY_EDITOR
        Debug.DrawRay(temp, Vector2.down * 1f, Color.green);
#endif

        if (isGrounded == false)
        {
            isSlideFlag = false;
        }
        playerAnimationHandler.PlayerIsGround(isGrounded);
    }


    /// <summary>
    /// 플레이어의 움직임을 처리하는 메서드
    /// </summary>
    private void Move() // 플레이어가 X축으로 쭉 이동하도록 구현
    {
        player.RigidPlayer.velocity = new Vector2(player.playerSpeed, player.RigidPlayer.velocity.y);
    }


    /// <summary>
    /// 플레이어가 점프 가능 여부를 확인하는 메서드
    /// </summary>
    public void HandleJump() 
    {
        if (!(isJumpFlag)) return;
        if (playerAnimationHandler.IsJump2Parameter == true) 
        { 
            isJumpFlag = false; 
            return; 
        } 
        Jump();
        isJumpFlag = false;
    }


    /// <summary>
    /// 플레이어의 velocity.y를 올리는 메서드
    /// </summary>
    private void Jump()
    {
        // 점프 동작 수행
        if (playerAnimationHandler.IsJump1Parameter) playerAnimationHandler.IsJump2Parameter = true;
        player.RigidPlayer.velocity = new Vector2(player.RigidPlayer.velocity.x, player.jumpForce);
        SoundManager.Instance.sfxManager.PlaySFX(SoundLibrary.Instance.sfxJump, 0.5f);
    }


    /// <summary>
    /// 슬라이딩이 가능한지 확인하는 메서드
    /// </summary>
    public void HandleSlide()
    {
        // 버튼 입력 또는 키보드 입력 감지 되면 해당 함수 호출
        if (isJumpFlag || !isGrounded) return;
        if (isSlideFlag) Slide();
        else ResetSlide();
    }


    /// <summary>
    /// 슬라이딩 동작을 실행하는 메서드
    /// </summary>
    private void Slide()
    {
        // 슬라이드 동작 수행
        if (player.ColliderPlayer != null)
        {
            playerAnimationHandler.IsSlideParameter = true;
            player.ColliderPlayer.size = new Vector2(player.originalColliderSize.x, player.originalColliderSize.y - 1f);
            player.ColliderPlayer.offset = new Vector2(player.originalColliderOffset.x, player.originalColliderOffset.y - 0.5f);
        }
    }


    /// <summary>
    /// 슬라이딩 상태에서 빠져나올 때 실행하는 메서드
    /// </summary>
    private void ResetSlide()
    {
        // 슬라이드 해제 및 원래 상태로 복구
        if (player.ColliderPlayer != null)
        {
            playerAnimationHandler.IsSlideParameter = false;
            player.ColliderPlayer.size = player.originalColliderSize;
            player.ColliderPlayer.offset = player.originalColliderOffset;
            transform.rotation = Quaternion.identity;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 아이템 충독 감지 및 처리
        if (collision == null) return;

        if (1 << collision.gameObject.layer == ReadonlyData.ItemLayerMask)
        {
            if (collision.GetComponent<IItem>()?.GetType() == typeof(PotionItem))
            {
                PotionItem item = collision.gameObject.GetComponent<PotionItem>();
                if (item != null)
                {
                    statHandler.Heal(item);
                    item.OnCollisionEffect();
                }
            }
            else if (collision.GetComponent<IItem>()?.GetType() == typeof(SpeedItem))
            {
                SpeedItem item = collision.gameObject.GetComponent<SpeedItem>();
                if (item != null)
                {
                    statHandler.ChangeSpeed(item);
                    item.OnCollisionEffect();
                }
            }
            else if (collision.GetComponentInParent<IItem>().GetType() == typeof(MagnetItem))
            {
                MagnetItem item = collision.gameObject.GetComponentInParent<MagnetItem>();
                if (item != null)
                {
                    item.OnCollisionEffect();
                }
            }
            else if (collision.GetComponent<IItem>()?.GetType() == typeof(StarItem))
            {
                StarItem item = collision.gameObject.GetComponent<StarItem>();
                if (item != null)
                {
                    item.OnCollisionEffect();
                }
            }

        }

        if (1 << collision.gameObject.layer == ReadonlyData.ObstacleLayerMask)
        {
            if (SoundManager.Instance != null)
            {
                SoundManager.Instance.sfxManager.PlaySFX(SoundLibrary.Instance.sfxHit, 0.5f);
            }
            statHandler.Damage(10, collision);
        }
    }
}