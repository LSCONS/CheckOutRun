using UnityEngine;

public class GameAudio : MonoBehaviour
{
    /// <summary>
    /// 게임 씬에 진입할 때 BGM을 재생합니다.
    /// </summary>
    private void Start()
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.bgmManager.PlayBGM(SoundLibrary.Instance.bgmGame, 0.4f);
        }
    }
}
