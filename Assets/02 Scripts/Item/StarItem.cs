using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarItem : MonoBehaviour, IItem
{
    public float EventDuration = 5f;
    public void OnCollisionEffect()
    {
        CoinItem.ActivateCoinEvent(EventDuration);
        Destroy(gameObject);
    }
}
