using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// 게임 시간 관리를 담당하는 클래스입니다.
/// 게임 시간의 증가, 최고 기록 갱신, 현재 상태 반환 등의 기능을 제공합니다.
/// </summary>
public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }
    public float gameTime { get; private set; } = 0;

    private float startHour = 9f * 60f; //출석 시간
    private float endHour = 21f * 60f; //퇴실 시간

    /// <summary>
    /// 싱글톤 인스턴스를 초기화합니다.
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
    }

    /// <summary>
    /// 플레이어의 이동 거리에 따라 게임 시간을 증가시킵니다.
    /// </summary>
    /// <param name="moveDistance">플레이어의 이동 거리</param>
    public void AddGameTime(float moveDistance)
    {
        if (moveDistance < 0) moveDistance = 0;
        float TimetoAdd = moveDistance; // 플레이어 이동거리에 따라 더해주는거라 Time.deltaTime을 곱해주지 않아도 됩니다.
        gameTime = TimetoAdd + startHour;

        if (gameTime >= endHour) //21시 이후는 출력되지 않도록 합니다.
        {
            gameTime = endHour;
        }
    }

    /// <summary>
    /// 최고 기록을 갱신합니다.
    /// </summary>
    public void UpdateBestTime()
    {
        float bestTime = PlayerPrefs.GetFloat(ReadonlyData.BestScorePlayerPrefabs);

        if (gameTime > bestTime)
        {
            PlayerPrefs.SetFloat(ReadonlyData.BestScorePlayerPrefabs, gameTime);
        }
    }

    /// <summary>
    /// 현재 게임 상태를 반환합니다.
    /// </summary>
    /// <returns>현재 게임 상태를 나타내는 IsGameClear 열거형 값</returns>
    public IsGameClear GetNowState()
    {
        if (gameTime >= 1260f)
        {
            return IsGameClear.Clear;
        }
        else if (gameTime >= 900f && gameTime < 1260f)
        {
            return IsGameClear.Perception;
        }
        else
        {
            return IsGameClear.Absence;
        }
    }
}

/// <summary>
/// 현재 게임 클리어 여부를 나타내는 열거형입니다.
/// </summary>
public enum IsGameClear
{
    Absence,        //결석
    Perception,     //지각
    Clear           //승리
}
