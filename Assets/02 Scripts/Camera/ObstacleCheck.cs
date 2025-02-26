using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            ObstacleAnimationHandler animator = collision.GetComponent<ObstacleAnimationHandler>();
            if(animator != null)
            {
                animator.AnimationStart();
            }
        }
    }
}
