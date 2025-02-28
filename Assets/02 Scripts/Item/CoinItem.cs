using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : MonoBehaviour, IItem
{
    private int coinScore = 1;          //충돌시 올라가는 점수 수치
    private int eventScore = 5;  // 코인 점수 증가 아이템(StarItem)을 먹으면 코인 점수 증가
    private static bool isEvented = false; // 코인 점수 증가 이벤트 여부
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] ParticleSystem particle;
    [SerializeField] ParticleSystem Eventparticle;

    // 이벤트 여부가 true이면 eventScore, false면 coinScore을 반영
    public int CoinScore { get { return isEvented ? eventScore : coinScore; } }

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
    public void ActivateCoinEvent(float duration)
    {
        // 코인 증가 이벤트 실행 (파티클 재생)
        isEvented = true; 

        if (Eventparticle != null)
        {
            if (!Eventparticle.isPlaying)
            {
                Eventparticle.Play(); 
            }
        }

        GameManager.Instance.StartCoroutine(DeactivateEventAfterTime(duration, this));
    }


    private static IEnumerator DeactivateEventAfterTime(float duration, CoinItem instance)
    {
        // 5초 후 코인 증가 이벤트 종료 (파티클 정지)
        yield return new WaitForSeconds(duration);

        isEvented = false;


        if (instance != null && instance.Eventparticle != null && instance.Eventparticle.isPlaying)
        {
            instance.Eventparticle.Stop();
        }
    }

}
