using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : MonoBehaviour ,IItem
{
    public int speedStat = 1;               //�浹�� �÷����� speed ��ġ
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