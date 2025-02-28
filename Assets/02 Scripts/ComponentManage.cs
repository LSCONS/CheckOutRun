using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentManage : MonoBehaviour
{
    /// <summary>
    /// 충돌한 객체가 "Obstacle", "Item", "Ground" 레이어에 속하는 경우 해당 객체를 파괴합니다.
    /// </summary>
    /// <param name="collision">충돌한 Collider2D 객체</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null)
        {
            return;
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(collision.gameObject);
        }
    }
}
