using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool isWin = false;

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

    public void GameOver(bool isAlive)
    {
        isWin = isAlive;                                    //플레이어 생사여부 확인하여 게임 승리 여부 판단
        DataManager.Instance.UpdateBestScore();
        TimeManager.Instance.UpdateBestTime();
        SceneManager.LoadScene("ResultScene");
    }
}
