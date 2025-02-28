using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// SoundUI는 게임 내의 사운드 설정 UI를 관리하는 클래스입니다.
/// BGM 및 SFX 볼륨을 조절할 수 있는 슬라이더를 제공합니다.
/// </summary>
public class SoundUI : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider sfxSlider;

    void Start()
    {
        bgmSlider.value = SoundManager.Instance.bgmVolume;
        sfxSlider.value = SoundManager.Instance.sfxVolume;
        bgmSlider.onValueChanged.AddListener(value => SoundManager.Instance.bgmVolume = value);
        sfxSlider.onValueChanged.AddListener(value => SoundManager.Instance.sfxVolume = value);
    }

    private void Update()
    {
        bgmSlider.onValueChanged.AddListener(value => SoundManager.Instance.bgmVolume = value);
        sfxSlider.onValueChanged.AddListener(value => SoundManager.Instance.sfxVolume = value);
    }
}
