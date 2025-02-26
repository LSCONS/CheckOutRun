using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultAudio : MonoBehaviour
{
    private void Start()
    {
        if (GameManager.Instance != null && SoundManager.Instance != null)
        {
            if (GameManager.Instance.isWin == false)
            {
                SoundManager.Instance.sfxManager.PlaySFX(SoundLibrary.Instance.sfxLose, 0.5f);
            }
            else
            {
                SoundManager.Instance.bgmManager.PlayBGM(SoundLibrary.Instance.bgmWin, 0.4f);
            }
        }
    }
}
