using UnityEngine;

public class ObstacleCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //장애물 레이어일 경우 해당 장애물의 Animation을 실행.
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


