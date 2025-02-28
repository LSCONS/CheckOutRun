using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    GameManager gameManager;
    Player player;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        player = GetComponent<Player>();
        animator = GetComponentInChildren<Animator>();
    }

    /// <summary>
    /// 아이템에 따라 플레이어의 속도를 변경합니다.
    /// </summary>
    /// <param name="item">속도를 변경할 아이템</param>
    public void ChangeSpeed(IItem item)
    {
        if (item == null || !player.isAlive)
        {
            return;
        }
        if (item.GetType() == typeof(SpeedItem))
        {
            SpeedItem speedItem = (SpeedItem)item;
            if (Enum.Equals(speedItem.speedType, SpeedType.Slow))
            {
                player.playerSpeed = speedItem.speedStat - speedItem.speedStat < 3 ? 3 : player.playerSpeed - speedItem.speedStat;
            }
            else if (Enum.Equals(speedItem.speedType, SpeedType.Fast))
            {
                player.playerSpeed = player.playerSpeed + speedItem.speedStat > 5 ? 5 : player.playerSpeed + speedItem.speedStat;
            }
        }
    }

    /// <summary>
    /// 아이템에 따라 플레이어의 체력을 회복합니다.
    /// </summary>
    /// <param name="item">체력을 회복할 아이템</param>
    public void Heal(IItem item)
    {
        if (item == null || !player.isAlive)
        {
            return;
        }
        if (item.GetType() == typeof(PotionItem))
        {
            PotionItem potionItem = (PotionItem)item;
            player.playerHealth = player.playerHealth + potionItem.Heal > player.playerMaxHealth ? player.playerMaxHealth : player.playerHealth + potionItem.Heal;
        }
    }

    /// <summary>
    /// 플레이어에게 데미지를 입힙니다.
    /// </summary>
    /// <param name="damage">입힐 데미지 양</param>
    /// <param name="collider">충돌한 Collider2D 객체 (선택 사항)</param>
    public void Damage(int damage, Collider2D collider = null)
    {
        if (player.isInvincible)
        {
            return;
        }

        if (player.playerHealth - damage <= 0)
        {
            player.playerHealth = 0;
        }
        else if (collider != null)                       //충돌처리됐을때
        {
            player.playerHealth -= damage;
            StartCoroutine(InvincibilityRoutine());
        }
        else                                            //그게 아닐시 무적처리 없는 데미지
        {
            player.playerHealth -= damage;
        }

        if (player.playerHealth <= 0)                   //체력 0일때 게임오버처리
        {
            gameManager.GameOver();
        }
    }

    /// <summary>
    /// 피격 시 무적 처리를 합니다.
    /// </summary>
    IEnumerator InvincibilityRoutine()
    {
        player.isInvincible = true; // 무적 시작
        animator.SetBool("IsInvincible", true);
        StartCoroutine(ObstacleRoutine());
        yield return new WaitForSeconds(player.InvincibleTime);

        player.isInvincible = false; // 무적 종료
        animator.SetBool("IsInvincible", false); //애니메이션 OFF
    }

    /// <summary>
    /// 장애물에 부딪혔을 때 플레이어의 속도를 일시적으로 감소시킵니다.
    /// </summary>
    IEnumerator ObstacleRoutine()
    {
        float playerSpeed = player.playerSpeed;

        player.playerSpeed = playerSpeed / 2f;
        yield return new WaitForSeconds(0.1f);

        player.playerSpeed = playerSpeed;
    }
}

