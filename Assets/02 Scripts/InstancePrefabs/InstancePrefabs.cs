using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancePrefabs : MonoBehaviour
{
    public GameObject[] backgroundPrefabs;
    private float maxWidthX = 400;
    private float maxRandHeightY = 2;
    private float minRandHeightY = 0;
    private float minRandWidthX = 3;
    private float maxRandWidthX = 7;


    private void Awake()
    {
        float nowWidthX = 0;
        while(nowWidthX < maxWidthX)
        {
            int randIndex = Random.Range(0, backgroundPrefabs.Length);
            float randHeightY = Random.Range(minRandHeightY, maxRandHeightY);
            float randWidthX = Random.Range(minRandWidthX, maxRandWidthX);
            Vector3 tempVector = new Vector3(nowWidthX, randHeightY, 0f);
            GameObject gameObject = Instantiate(backgroundPrefabs[randIndex], tempVector, Quaternion.identity);
            gameObject.transform.parent = this.transform;

            Renderer renderer = gameObject.GetComponent<Renderer>();
            if(renderer != null)
            {
                nowWidthX += renderer.bounds.size.x + randWidthX;
                Color beforeColor = renderer.material.color;
                renderer.material.color = new Color(beforeColor.r, beforeColor.g, beforeColor.b, 0.6f);
            }
            else
            {
                Debug.LogError("renderer is null");
            }
        }
    }
}
