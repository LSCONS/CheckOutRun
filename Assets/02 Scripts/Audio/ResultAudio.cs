using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultAudio : MonoBehaviour
{
    public AudioClip winBGM; // Inspector에서 할당
    public AudioClip defeatSFX;

    private void Start()
    {
        if (GameManager.Instance != null && SoundManager.Instance != null)
        {
            if (GameManager.Instance.isWin == false)
            {
                SoundManager.Instance.sfxManager.PlaySFX(defeatSFX, 0.5f);
            }
            else
            {
                SoundManager.Instance.bgmManager.PlayBGM(winBGM, 0.4f);
            }
        }
    }
}
