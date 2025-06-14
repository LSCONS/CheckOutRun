using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(1 << collision.gameObject.layer == ReadonlyData.ObstacleLayerMask)
        {
            ObstacleAnimationHandler animator = collision.GetComponent<ObstacleAnimationHandler>();
            if(animator != null)
            {
                animator.AnimationStart();
            }
        }
    }
}
