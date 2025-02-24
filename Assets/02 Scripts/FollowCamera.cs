using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public Transform backGround;
    //float offsetX; // ī�޶� �ʱ� x��ġ

    [SerializeField] private float followSpeed = 5f;
    [SerializeField] private float parallaxFactor = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        //offsetX = transform.position.x - target.position.x;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    Vector3 pos = transform.position;
    //    pos.x = target.position.x + offsetX;
    //    transform.position = pos;
    //}

    private void LateUpdate()
    {
        if( target == null) return;

        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        if(backGround != null)
        {
            backGround.position = new Vector3(transform.position.x * parallaxFactor, backGround.position.y, 0f); 
        }
    }
}
