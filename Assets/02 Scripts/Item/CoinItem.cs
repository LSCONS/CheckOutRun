using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : MonoBehaviour, IItem
{
    private int baseScore = 1;       // 기본 점수
    private int EventScore = 2;    // 강화된 점수
    private static bool isBoosted = false; // 점수 강화 상태 여부

    public int CoinScore { get { return isBoosted ? EventScore : baseScore; } } // 강화 상태면 boostedScore 반환

    public void OnCollisionEffect()
    {
        Destroy(gameObject);
        // 애니메이션 동작 후 삭제 로직 필요
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (SoundManager.Instance != null)
            {
                SoundManager.Instance.sfxManager.PlaySFX(SoundLibrary.Instance.sfxPickupCoin, 0.2f);
            }
            DataManager.Instance.AddScore(CoinScore); // 현재 상태에 따라 점수 추가
            OnCollisionEffect();
        }
    }

    public static void ActivateCoinEvent(float duration)
    {
        isBoosted = true;
        Debug.Log("코인 점수 상승! " + duration + "초 동안 유지됨.");
        GameManager.Instance.StartCoroutine(DeactivateEventAfterTime(duration));
    }

    private static IEnumerator DeactivateEventAfterTime(float duration)
    {
        yield return new WaitForSeconds(duration);
        isBoosted = false;
        Debug.Log("코인 점수 원래대로 복귀.");
    }
}
