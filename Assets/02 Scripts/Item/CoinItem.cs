using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : MonoBehaviour, IItem
{
    private int coinScore = 1;          //충돌시 올라가는 점수 수치

    public int CoinScore { get { return coinScore; } }

    public void OnCollisionEffect()
    {
        Destroy(gameObject);
        //애니메이션 동작 후 삭제 로직 필요
    }
}
