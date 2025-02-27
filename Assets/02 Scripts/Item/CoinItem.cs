using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : MonoBehaviour, IItem
{
    private int coinScore = 1;          //충돌시 올라가는 점수 수치
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] ParticleSystem particle;

    public int CoinScore { get { return coinScore; } }

    public void OnCollisionEffect()
    {
        if (spriteRenderer == null)
        {
            Destroy(gameObject, 1f);
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
       if(collision.CompareTag("Player"))
       {
            if (SoundManager.Instance != null)
            {
                SoundManager.Instance.sfxManager.PlaySFX(SoundLibrary.Instance.sfxPickupCoin, 0.2f);
            }
            DataManager.Instance.AddScore(CoinScore);
            OnCollisionEffect();
       }
    }
}
