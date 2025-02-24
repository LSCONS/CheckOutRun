using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : MonoBehaviour ,IItem
{
    public int speedStat = 1;               //충돌시 올려야할 speed 수치
    public int speedType = 0;
    
    public void OnCollisionEffect()
    {
        //애니메이션 동작 후 삭제 로직 필요
    }
}

public enum SpeedType
{
    Slow,
    Fast,
    Max
}