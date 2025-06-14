using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameClear : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(1 << collision.gameObject.layer == ReadonlyData.PlayerLayerMask)
        {
            GameManager.Instance.GameOver();
        }
    }
}
