using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    float offsetX = 4; // ī�޶� �ʱ� x��ġ

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = target.position.x + offsetX;
        transform.position = pos;
    }
}
