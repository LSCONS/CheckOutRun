using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }
    GameUI gameUI;

    private int score;

    public int Score { get { return score; } }

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
    }

    /// <summary>
    /// 점수 데이터 부분 초기화 작업
    /// </summary>
    public void Init()
    {
        score = 0;
        gameUI = FindObjectOfType<GameUI>();
    }

    /// <summary>
    /// 점수 더하기
    /// </summary>
    /// <param name="unitScore">추가할 점수</param>
    public void AddScore(int unitScore)
    {
        score += unitScore;
        gameUI.UpdateScoreUI();
    }

    /// <summary>
    /// 최고 기록 갱신
    /// </summary>
    public void UpdateBestScore()
    {
        int bestScore = PlayerPrefs.GetInt(ReadonlyData.BestScorePlayerPrefabs);
        if (score > bestScore)
        {
            PlayerPrefs.SetInt(ReadonlyData.BestScorePlayerPrefabs, score);
        }
    }
}
