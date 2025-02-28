using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private AudioSource bgmSource;

    float bgmVolume;
    float bgmMult;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // 씬 변경 시 유지

        bgmSource = GetComponent<AudioSource>();
        if (bgmSource == null)
        {
            bgmSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayBGM(AudioClip clip, float volume = 1.0f)
    {
        if (bgmSource != null)
        {
            bgmMult = volume;
            bgmSource.clip = clip;
            UpdateVolume(SoundManager.Instance.bgmVolume);
            bgmSource.loop = true;
            bgmSource.Play();
        }
    }

    public void StopBGM()
    {
        if (bgmSource != null)
        {
            bgmSource.Stop();
        }
    }

    public void UpdateVolume(float volume)
    {
        if (bgmSource != null)
        {
            bgmVolume = volume;
            bgmSource.volume = bgmVolume * bgmMult;
        }
    }
}
