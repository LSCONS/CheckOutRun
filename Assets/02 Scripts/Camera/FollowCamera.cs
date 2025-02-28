using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public Transform backGround;

    [SerializeField] private float parallaxFactor = 0.5f;

    void Start()
    {
        if (backGround != null)
        {
            backGround.position = new Vector3((transform.position.x * parallaxFactor) - 3, 0f, 0f);
        }
    }

    private void LateUpdate()
    {
        if(target == null || target.position.x < 0) return;
        
        //카메라의 목표 지점을 결정함.
        Vector3 targetPosition;

        if (GameManager.Instance.isWin == false)
        {
            targetPosition = new Vector3(target.position.x + 4, 0, -10f);
            transform.position = targetPosition;

            //배경이 카메라를 기준으로 따라가게 함.
            if (backGround != null)
            {
                backGround.position = new Vector3((transform.position.x * parallaxFactor) - 3, 0f, 0f);
            }
        }
    }
}
