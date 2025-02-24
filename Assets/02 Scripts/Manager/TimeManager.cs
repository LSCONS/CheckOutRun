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

    private void Update()
    {
        //속도 증가 아이템을 먹었다면 gameTime에 speedMultipler을 곱해야 함
        //24시간 기준으로 시간 제한
        if(gameTime >= endHour)
        {
            //바로 다음날 9시로 넘어가는게 아니라, 보스전동안 잠시 대기하는 조건문 필요
            //if(isBoss == true)
            //{

            //}
            //else
            gameTime = startHour;
        }
    }

    public void AddGameTime(float moveDistance)
    {
        float TimetoAdd = moveDistance * 3f; // 플레이어 이동거리에 따라 더해주는거라 Time.deltaTime을 곱해주지 않아도 됨
        gameTime = TimetoAdd + startHour;

        if (gameTime >= endHour)
        {
            //보스전 동안 moveDistance를 카운트하면 안됨

            gameTime = startHour;
        }
    }
}
