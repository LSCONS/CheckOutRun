using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAudio : MonoBehaviour
{
    private void Start()
    {
        if (SoundManager.Instance != null)
        {
            Debug.Log("브금 ON");
            SoundManager.Instance.bgmManager.PlayBGM(SoundLibrary.Instance.bgmMain, 0.4f);
        }
    }
}
