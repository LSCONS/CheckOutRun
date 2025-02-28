using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ResultAudio는 결과 화면에서 재생되는 오디오를 관리하는 클래스입니다.
/// 게임의 승리 또는 패배에 따라 다른 오디오 클립을 재생합니다.
/// </summary>
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
