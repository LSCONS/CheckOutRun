using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    private void Start()
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.bgmManager.PlayBGM(SoundLibrary.Instance.bgmGame, 0.4f);
        }
    }
}
