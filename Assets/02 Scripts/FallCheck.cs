using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FallCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;

        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("플레이어는 죽었어요");
            GameManager.Instance.GameOver();
        }
    }
}
