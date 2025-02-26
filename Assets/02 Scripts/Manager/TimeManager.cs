using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }
    //1시간당 20초가 흐르도록
    public float gameTime { get; private set; } = 0;
    public float gameSpeed = 3f; //1초당 3분이 흘러야 함(60분 = 20초)

    private float startHour = 9f * 60f; //출석 시간
    private float endHour = 21f * 60f; //퇴실 시간

    //private bool isBoss = false; //21시 직후, 보스전페이즈에 돌입했는지

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

    public void AddGameTime(float moveDistance)
    {
        float TimetoAdd = moveDistance; // 플레이어 이동거리에 따라 더해주는거라 Time.deltaTime을 곱해주지 않아도 됨
        gameTime = TimetoAdd + startHour;

        if (gameTime >= endHour)
        {
            //보스전 동안 moveDistance를 카운트하면 안됨

            gameTime = endHour;
        }
    }

    public void UpdateBestTime()
    {
        float bestTime = PlayerPrefs.GetFloat("bestTime");

        if (gameTime > bestTime)
        {
            PlayerPrefs.SetFloat("bestTime", gameTime);
        }
    }
}
