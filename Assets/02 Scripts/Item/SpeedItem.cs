using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : MonoBehaviour ,IItem
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] ParticleSystem particle;
    public float speedStat = 0.5f;               //충돌시 올려야할 speed 수치
    public SpeedType speedType = SpeedType.Slow;
    
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

/**
 * SpeedType
 * Slow = 느려지게 하는 타입
 * Fast = 빨라지게 하는 타입
 * Max = 최고속도로 만들어주는 타입(사용 X)
 * */
public enum SpeedType
{
    Slow = 0,
    Fast,
    Max
}