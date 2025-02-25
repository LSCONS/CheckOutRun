using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    public static readonly int IsInvincibleKey = Animator.StringToHash("IsInvincible");
    public static readonly int IsJump1KeY = Animator.StringToHash("IsJump1");
    public static readonly int IsJump2Key = Animator.StringToHash("IsJump2");
    public static readonly int IsGroundKey = Animator.StringToHash("IsGround");

    public bool IsGround
    { 
        get => playerAnimator.GetBool(IsGroundKey);
        set => playerAnimator.SetBool(IsGroundKey, value);
    }

    public bool IsJump1
    {
        get => playerAnimator.GetBool(IsJump1KeY);
        set => playerAnimator.SetBool(IsJump1KeY, value);
    }

    public bool IsJump2
    {
        get => playerAnimator.GetBool(IsJump2Key);
        set => playerAnimator.SetBool(IsJump2Key, value);
    }

    public bool IsInvincible
    {
        get => playerAnimator.GetBool(IsInvincibleKey);
        set => playerAnimator.SetBool(IsInvincibleKey, value);
    }

    public Animator playerAnimator;

    private void Awake()
    {
        playerAnimator = GetComponentInChildren<Animator>();
    }
}
