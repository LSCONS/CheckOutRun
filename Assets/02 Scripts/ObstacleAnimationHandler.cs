using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAnimationHandler : MonoBehaviour
{
    private readonly int ObstacleAnimationKey = Animator.StringToHash("IsStart");
    private Animator animator;


    //초기화
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    //애니메이션 실행
    public void AnimationStart()
    {
        animator.SetBool(ObstacleAnimationKey, true);
    }
}
