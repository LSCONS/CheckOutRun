using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public BGMManager bgmManager;
    public SFXManager sfxManager;

    private float _bgmVolume = 1.0f;
    private float _sfxVolume = 1.0f;

    /// <summary>
    /// BGM 볼륨을 가져오거나 설정합니다. 설정 시 PlayerPrefs에 저장됩니다.
    /// </summary>
    public float BGMVolume
    {
        get { return _bgmVolume; }
        set
        {
            _bgmVolume = Mathf.Clamp01(value);
            PlayerPrefs.SetFloat(ReadonlyData.BGMVolumePlayerPrefabs, _bgmVolume);
            PlayerPrefs.Save();

            if (bgmManager != null)
                bgmManager.UpdateVolume(_bgmVolume);
        }
    }

    /// <summary>
    /// SFX 볼륨을 가져오거나 설정합니다. 설정 시 PlayerPrefs에 저장됩니다.
    /// </summary>
    public float SFXVolume
    {
        get { return _sfxVolume; }
        set
        {
            _sfxVolume = Mathf.Clamp01(value);
            PlayerPrefs.SetFloat(ReadonlyData.SFXVolumePlayerPrefabs, _sfxVolume);
            PlayerPrefs.Save();

            if (sfxManager != null)
                sfxManager.UpdateVolume(_sfxVolume);
        }
    }

    /// <summary>
    /// 싱글톤 인스턴스를 초기화하고, BGMManager와 SFXManager를 설정합니다.
    /// </summary>
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
            return;
        }

        _bgmVolume = PlayerPrefs.GetFloat(ReadonlyData.BGMVolumePlayerPrefabs, 1.0f);
        _sfxVolume = PlayerPrefs.GetFloat(ReadonlyData.SFXVolumePlayerPrefabs, 1.0f);

        // BGMManager와 SFXManager도 DontDestroyOnLoad 유지
        if (bgmManager == null)
        {
            bgmManager = gameObject.AddComponent<BGMManager>();
            DontDestroyOnLoad(bgmManager);
        }
        if (sfxManager == null)
        {
            sfxManager = gameObject.AddComponent<SFXManager>();
            DontDestroyOnLoad(sfxManager);
        }

        bgmManager.UpdateVolume(_bgmVolume);
        sfxManager.UpdateVolume(_sfxVolume);
    }
}
