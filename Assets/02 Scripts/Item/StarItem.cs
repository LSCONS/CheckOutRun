using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarItem : MonoBehaviour, IItem
{
    public float EventDuration = 5f;

    public void OnCollisionEffect()
    {
        CoinItem[] coinItems = FindObjectsOfType<CoinItem>();  
        foreach (CoinItem coinItem in coinItems)
        {
            coinItem.ActivateCoinEvent(EventDuration);  
        }

        Destroy(gameObject);  
    }
}
