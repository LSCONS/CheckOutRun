using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
