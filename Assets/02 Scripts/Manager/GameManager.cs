using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool isWin = false;

    /// <summary>
    /// 싱글톤 인스턴스를 초기화하고, 프레임 속도와 VSync 설정을 구성합니다.
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
        }
        Application.targetFrameRate = 30;
        QualitySettings.vSyncCount = 0;
    }

    /// <summary>
    /// 게임 오버 상태를 처리하고, 결과 씬으로 전환합니다.
    /// </summary>
    public void GameOver()
    {
        IsGameClear isGameClear = TimeManager.Instance.GetNowState();
        if (isGameClear == IsGameClear.Clear) isWin = true;
        DataManager.Instance.UpdateBestScore();
        TimeManager.Instance.UpdateBestTime();
        SceneManager.LoadScene(ReadonlyData.ResultSceneName);
        SoundManager.Instance.bgmManager.StopBGM();
    }
}
