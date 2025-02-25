using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FallCheck : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;

        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("플레이어는 죽었어요");
            GameManager.Instance.isWin = false;
            GameManager.Instance.GameOver(false);
        }
    }
}
