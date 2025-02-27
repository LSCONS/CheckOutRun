using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveCheck : MonoBehaviour
{
    Vector3 beforePosition;
    Vector3 currentPosition;

    private void Update()
    {
        if (Vector3.Magnitude(currentPosition - beforePosition) <= 0.01f &&
            Time.timeScale > 0f)
        {
            transform.position = transform.position + new Vector3(-0.1f, 0f, 0);
        }
        beforePosition = currentPosition;
        currentPosition = transform.position;
    }
}
