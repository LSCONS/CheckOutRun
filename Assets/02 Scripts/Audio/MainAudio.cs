using UnityEngine;

/// <summary>
/// MainAudio는 메인 화면에서 재생되는 오디오를 관리하는 클래스입니다.
/// 메인 화면에 진입할 때 BGM을 재생합니다.
/// </summary>
public class MainAudio : MonoBehaviour
{
    private void Start()
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.bgmManager.PlayBGM(SoundLibrary.Instance.bgmMain, 0.4f);
        }
    }
}
