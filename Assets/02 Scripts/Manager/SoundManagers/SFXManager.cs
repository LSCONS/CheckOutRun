using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public int maxSFXSources = 10;
    private List<AudioSource> sfxSources = new List<AudioSource>();

    float sfxVolume;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // 씬 변경 시 유지

        for (int i = 0; i < maxSFXSources; i++)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            sfxSources.Add(source);
        }
    }

    public void PlaySFX(AudioClip clip, float volume = 1.0f)
    {
        foreach (var source in sfxSources)
        {
            if (!source.isPlaying)
            {
                source.clip = clip;
                source.volume = sfxVolume * volume;
                source.Play();
                return;
            }
        }
    }

    public void UpdateVolume(float volume)
    {
        foreach (var source in sfxSources)
        {
            sfxVolume = volume;
        }
    }
}
