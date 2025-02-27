using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearEndingScene : MonoBehaviour
{
    float sceneSpeed = 5f;
    private void Update()
    {
        transform.position = transform.position - new Vector3(0, Time.deltaTime * sceneSpeed, 0);
    }
}
