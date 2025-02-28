using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveCheck : MonoBehaviour
{
    Vector3 beforePosition;
    Vector3 currentPosition;


    //플레이어가 프레임마다 얼마나 움직였는지 확인하고 움직인 값이 0.01f 이하일 경우 왼쪽으로 밀어내는 메서드
    private void Update()
    {
        if (Vector3.Magnitude(currentPosition - beforePosition) <= 0.01f &&
            Time.timeScale > 0f)
        {
            transform.position = transform.position + new Vector3(-0.1f, 0f, 0);
        }
        beforePosition = currentPosition;
        currentPosition = transform.position;
    }
}
