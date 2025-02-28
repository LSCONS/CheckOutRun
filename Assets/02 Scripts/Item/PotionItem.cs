using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionItem : MonoBehaviour, IItem
{
    [SerializeField] private int heal = 60;         //충돌시 회복되는 체력 수치
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] ParticleSystem particle;

    public int Heal { get { return heal; } }

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
}
