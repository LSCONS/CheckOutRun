using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

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

    public void Damage()
    {
        int damage = 20;
        if (player.isInvincible)
        {
            return;
        }

        if (player.playerHealth - damage <= 0)
        {
            player.playerHealth = 0;
            gameManager.GameOver();
        }
        else
        {
            player.playerHealth -= damage;
            StartCoroutine(InvincibilityRoutine());
        }
    }

    //피격시 무적처리
    IEnumerator InvincibilityRoutine()
    {
        player.isInvincible = true; // 무적 시작
        animator.SetBool("IsInvincible", true);
        yield return new WaitForSeconds(player.InvincibleTime);

        player.isInvincible = false; // 무적 종료
        animator.SetBool("IsInvincible", false); //애니메이션 OFF
    }
}
