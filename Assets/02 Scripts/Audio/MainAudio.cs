using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAudio : MonoBehaviour
{
    public AudioClip mainBGM; // Inspector에서 할당

    private void Start()
    {
        if (SoundManager.Instance != null)
        {
            Debug.Log("브금 ON");
            SoundManager.Instance.bgmManager.PlayBGM(mainBGM, 0.4f);
        }
    }
}
