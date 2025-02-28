using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAnimationHandler : MonoBehaviour
{
    private readonly int ObstacleAnimationKey = Animator.StringToHash("IsStart");
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void AnimationStart()
    {
        animator.SetBool(ObstacleAnimationKey, true);
    }
}
