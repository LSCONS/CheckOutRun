using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SoundLibrary는 게임 내에서 사용되는 오디오 클립을 관리하는 클래스입니다.
/// 승리와 패배 시 재생되는 BGM 및 SFX 클립을 제공합니다.
/// </summary>
public class SoundLibrary : MonoBehaviour
{
    public static SoundLibrary Instance { get; private set; }

    [Header("BGM Clips")]
    public AudioClip bgmMain;
    public AudioClip bgmGame;
    public AudioClip bgmWin;

    [Header("SFX Clips")]
    public AudioClip sfxJump;
    public AudioClip sfxHit;
    public AudioClip sfxPickupCoin;
    public AudioClip sfxFanfare;
    public AudioClip sfxLose;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
