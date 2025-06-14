using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    public bool IsGroundParameter
    { 
        get => playerAnimator.GetBool(ReadonlyData.IsGroundKey);
        set => playerAnimator.SetBool(ReadonlyData.IsGroundKey, value);
    }
    public bool IsJump1Parameter
    {
        get => playerAnimator.GetBool(ReadonlyData.IsJump1KeY);
        set => playerAnimator.SetBool(ReadonlyData.IsJump1KeY, value);
    }
    public bool IsJump2Parameter
    {
        get => playerAnimator.GetBool(ReadonlyData.IsJump2Key);
        set => playerAnimator.SetBool(ReadonlyData.IsJump2Key, value);
    }
    public bool IsInvincibleParameter
    {
        get => playerAnimator.GetBool(ReadonlyData.IsInvincibleKey);
        set => playerAnimator.SetBool(ReadonlyData.IsInvincibleKey, value);
    }
    public bool IsSlideParameter
    {
        get => playerAnimator.GetBool(ReadonlyData.IsSlideKey);
        set => playerAnimator.SetBool(ReadonlyData.IsSlideKey, value);
    }
    public bool IsClearParameter
    {
        get => playerAnimator.GetBool(ReadonlyData.IsClearKey);
        set => playerAnimator.SetBool(ReadonlyData.IsClearKey, value);
    }

    public Animator playerAnimator;

    private void Awake()
    {
        playerAnimator = GetComponentInChildren<Animator>();
    }


    //플레이어가 땅에 닿고 있을 때랑 닿지 않을 때를 비교해서 파라미터를 변경
    public void PlayerIsGround(bool isGround)
    {
        if (isGround)
        {
            IsGroundParameter = true;
            IsJump1Parameter = false;
            IsJump2Parameter = false;
            IsSlideParameter = false;
        }
        else
        {
            IsSlideParameter = false;
            IsGroundParameter = false;
            IsJump1Parameter = true;
        }
    }
}