using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : MonoBehaviour ,IItem
{
    public int speedStat = 1;               //충돌시 올려야할 speed 수치
    public int speedType = 0;
    
    public void OnCollisionEffect()
    {

    }
}

public enum SpeedType
{
    Slow,
    Fast,
    Max
}