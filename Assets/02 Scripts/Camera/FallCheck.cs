using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// 플레이어가 추락했을 때 게임 오버를 처리하는 클래스입니다.
/// </summary>
public class FallCheck : MonoBehaviour
{
    /// <summary>
    /// 트리거 충돌이 발생했을 때 호출됩니다.
    /// 플레이어가 충돌하면 게임 오버를 처리합니다.
    /// </summary>
    /// <param name="collision">충돌한 콜라이더</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;

        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager1.Instance.GameOver();
        }
    }
}
