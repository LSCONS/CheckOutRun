using UnityEngine;

public class ComponentManage : MonoBehaviour
{
    private LayerMask interactionLayer; //충돌했을 경우 없앨 레이어 정리

    private void Awake()
    {
        interactionLayer = (ReadonlyData.ObstacleLayerMask | ReadonlyData.ItemLayerMask| ReadonlyData.GroundLayerMask);
    }


    /// <summary>
    /// 충돌한 객체가 특정 레이어에 속하는 경우 해당 객체를 파괴.
    /// </summary>
    /// <param name="collision">충돌한 Collider2D 객체</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LayerMask checkLayer = 1 << collision.gameObject.layer | interactionLayer;
        if(checkLayer == interactionLayer) Destroy(collision.gameObject);
    }
}
