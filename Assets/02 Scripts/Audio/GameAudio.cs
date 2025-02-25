using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    public AudioClip myBGM; // Inspector에서 할당

    private void Start()
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.bgmManager.PlayBGM(myBGM, 0.4f);
        }
    }
}
