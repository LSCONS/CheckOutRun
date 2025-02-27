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
    [SerializeField] ParticleSystem Eventparticle;


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

        // 현재 씬에서 CoinItem 인스턴스 찾기
        CoinItem instance = FindObjectOfType<CoinItem>();
        if (instance != null && instance.Eventparticle != null)
        {
            instance.Eventparticle.Play();  // 이벤트 파티클 재생
        }

        // 이벤트 종료 후 복귀
        GameManager.Instance.StartCoroutine(DeactivateEventAfterTime(duration, instance));
    }

    // 이벤트 종료 후 점수 복귀 및 파티클 정지
    private static IEnumerator DeactivateEventAfterTime(float duration, CoinItem instance)
    {
        yield return new WaitForSeconds(duration);
        isEvented = false;
        Debug.Log("코인 점수 원래대로 복귀.");

        if (instance != null && instance.Eventparticle != null)
        {
            instance.Eventparticle.Stop();  // 이벤트 파티클 정지
        }
    }
}
