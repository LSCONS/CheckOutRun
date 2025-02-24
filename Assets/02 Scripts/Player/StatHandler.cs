using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class StatHandler : MonoBehaviour
{
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
    }

    public void ChangeSpeed(IItem item)
    {
        if (item == null)
        {
            return;
        }
        if (item.GetType() == typeof(SpeedItem))
        {
            SpeedItem speedItem = (SpeedItem)item;
            if (Enum.Equals(speedItem.speedType, SpeedType.Slow))
            {
                player.playerSpeed -= speedItem.speedStat;
            }
            else if (Enum.Equals(speedItem.speedType, SpeedType.Fast))
            {
                player.playerSpeed += speedItem.speedStat;
            }
        }
    }

    public void Heal(IItem item)
    {
        if (item == null)
        {
            return;
        }
        if (item.GetType() == typeof(PotionItem))
        {
            PotionItem potionItem = (PotionItem)item;
            player.playerHealth += potionItem.Heal;
        }
    }
}
