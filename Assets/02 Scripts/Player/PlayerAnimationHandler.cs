using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    public static readonly int IsInvincible = Animator.StringToHash("IsInvincible");
    public static readonly int IsJump1 = Animator.StringToHash("IsJump1");
    public static readonly int IsJump2 = Animator.StringToHash("IsJump2");

    private Animator playerAnimator;

    private void Awake()
    {
        playerAnimator = GetComponentInChildren<Animator>();
    }

    public void Jump1Animation()
    {

    }


    public void Jump2Animation()
    {

    }


    public void InvincibleAnimation()
    {

    }


    public void DamageAnimation()
    {

    }
}
