using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private AudioSource bgmSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // 씬 변경 시 유지

        bgmSource = gameObject.AddComponent<AudioSource>();
        bgmSource.loop = true;
    }

    public void PlayBGM(AudioClip clip, float volume = 1.0f)
    {
        if (bgmSource.clip == clip) return; // 같은 음악이면 재생 안 함

        bgmSource.clip = clip;
        bgmSource.volume = volume * SoundManager.Instance.bgmVolume;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }

    public void SetVolume(float volume)
    {
        bgmSource.volume = volume;
    }
}
