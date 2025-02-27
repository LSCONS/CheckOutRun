using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : MonoBehaviour, IItem
{
    private int coinScore = 1;          //충돌시 올라가는 점수 수치
    private int EventScore = 2;
    private static bool isEvented = false;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] ParticleSystem particle;

    public int CoinScore { get { return isEvented ? EventScore : coinScore; } }

    public void OnCollisionEffect()
    {
        if (spriteRenderer == null)
        {
            Destroy(gameObject);
        }
        else
        {
            particle.Play();
            Destroy(spriteRenderer.gameObject);
            Destroy(gameObject, 1f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (SoundManager.Instance != null)
            {
                SoundManager.Instance.sfxManager.PlaySFX(SoundLibrary.Instance.sfxPickupCoin, 0.2f);
            }
            DataManager.Instance.AddScore(CoinScore);
            OnCollisionEffect();
        }
    }
    public static void ActivateCoinEvent(float duration)
    {
        isEvented = true;
        Debug.Log("코인 점수 상승! " + duration + "초 동안 유지됨.");
        GameManager.Instance.StartCoroutine(DeactivateEventAfterTime(duration));
    }

    private static IEnumerator DeactivateEventAfterTime(float duration)
    {
        yield return new WaitForSeconds(duration);
        isEvented = false;
        Debug.Log("코인 점수 원래대로 복귀.");
    }
}
