using UnityEngine;

public static class ReadonlyData
{
    public readonly static LayerMask GroundLayerMask        = 1 << LayerMask.NameToLayer("Ground");
    public readonly static LayerMask ObstacleLayerMask      = 1 << LayerMask.NameToLayer("Obstacle");
    public readonly static LayerMask BackGroundLayerMask    = 1 << LayerMask.NameToLayer("BackGround");
    public readonly static LayerMask ItemLayerMask          = 1 << LayerMask.NameToLayer("Item");
    public readonly static LayerMask PlayerLayerMask        = 1 << LayerMask.NameToLayer("Player");

    public static readonly int IsInvincibleKey  = Animator.StringToHash("IsInvincible");
    public static readonly int IsJump1KeY       = Animator.StringToHash("IsJump1");
    public static readonly int IsJump2Key       = Animator.StringToHash("IsJump2");
    public static readonly int IsGroundKey      = Animator.StringToHash("IsGround");
    public static readonly int IsSlideKey       = Animator.StringToHash("IsSlide");
    public static readonly int IsClearKey       = Animator.StringToHash("IsClear");
    public static readonly int IsStartKey       = Animator.StringToHash("IsStart");

    public static readonly string PlayerTagName = "Player";

    public static readonly string MainSceneName = "MainScene";
    public static readonly string LoadingSceneName = "LoadingScene";
    public static readonly string ResultSceneName = "ResultScene";
    public static readonly string GameSceneName = "GameScene";

    public static readonly string BestScorePlayerPrefabs = "bestTime";
    public static readonly string BGMVolumePlayerPrefabs = "BGMVolume";
    public static readonly string SFXVolumePlayerPrefabs = "SFXVolume";
}
