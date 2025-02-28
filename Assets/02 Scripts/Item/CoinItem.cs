using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : MonoBehaviour, IItem
{
    private int coinScore = 1;          //충돌시 올라가는 점수 수치
    private int EventScore = 5;
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
    public void ActivateCoinEvent(float duration)
    {
        isEvented = true;

        if (Eventparticle != null)
        {
            if (!Eventparticle.isPlaying)
            {
                Eventparticle.Play();  // 파티클 재생
            }
        }

        GameManager.Instance.StartCoroutine(DeactivateEventAfterTime(duration, this));
    }


    private static IEnumerator DeactivateEventAfterTime(float duration, CoinItem instance)
    {
        yield return new WaitForSeconds(duration);

        isEvented = false;


        if (instance != null && instance.Eventparticle != null && instance.Eventparticle.isPlaying)
        {
            instance.Eventparticle.Stop();  // 파티클 정지
        }
    }

}
