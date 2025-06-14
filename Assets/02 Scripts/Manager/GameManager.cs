using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool isWin = false;

    /// <summary>
    /// 싱글톤 인스턴스를 초기화하고, 프레임 속도와 VSync 설정을 구성.
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
        IsGameClear isGameClear = TimeManager.Instance.GetNowState();   //사망 시점의 거리에 따라 enum을 다르게 배정
        if (isGameClear == IsGameClear.Clear) isWin = true;             //클리어한 경우 isWin true
        DataManager.Instance.UpdateBestScore();                         //PlayerPrefabs에 최고기록 업데이트 시도
        SceneManager.LoadScene(ReadonlyData.ResultSceneName);           //결과 씬으로 이동
        SoundManager.Instance.bgmManager.StopBGM();                     //BGM 종료
    }
}
