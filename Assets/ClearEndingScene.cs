using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearEndingScene : MonoBehaviour
{
    float sceneSpeed = 5f;

    public GameObject[] textObjects;


    private void Update()
    {
        float speed = Time.deltaTime * sceneSpeed;

        transform.position = transform.position - new Vector3(0, speed, 0);

        for (int i = 0; i < textObjects.Length; i++)
        {
            textObjects[i].transform.position = textObjects[i].transform.position + new Vector3(0, speed / 2, 0);
        }


        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            GameManager1.Instance.GameOver();
        }
    }
}
