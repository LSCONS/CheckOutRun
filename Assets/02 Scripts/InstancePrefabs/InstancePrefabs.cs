using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class InstancePrefabs : MonoBehaviour
{
    public GameObject[] backgroundPrefabs;
    private float maxWidthX = 400;
    private float maxRandHeightY = 2;
    private float minRandHeightY = 0;
    private float minRandWidthX = 3;
    private float maxRandWidthX = 7;
    private SpriteRenderer[] backgroundsSpriteRenderer;
    private Color minusColor = new Color(0.1f, 0.1f, 0.1f, 0f);
    private GameObject player;
    [SerializeField]private Color beforeColor;
    [SerializeField]private Color nextColor;
    float playerPositionX;
    private bool isHourTime = false;
    private float nowTime = 60f;
    private float lerpT = 0;
    private float startColor = 0.9f;


    private void Awake()
    {
        player = GameObject.Find("Player");
        float nowWidthX = 0;
        while (nowWidthX < maxWidthX)
        {
            int randIndex = Random.Range(0, backgroundPrefabs.Length);
            float randHeightY = Random.Range(minRandHeightY, maxRandHeightY);
            float randWidthX = Random.Range(minRandWidthX, maxRandWidthX);
            Vector3 tempVector = new Vector3(nowWidthX, randHeightY, 0f);
            GameObject gameObject = Instantiate(backgroundPrefabs[randIndex], tempVector, Quaternion.identity);
            gameObject.transform.parent = this.transform;

            Renderer renderer = gameObject.GetComponent<Renderer>();
            if (renderer != null)
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

    private void Start()
    {
        backgroundsSpriteRenderer = GetComponentsInChildren<SpriteRenderer>();
        beforeColor = new Color(startColor, startColor, startColor, 1);
        nextColor = new Color(startColor, startColor, startColor, 1);
        for (int i = 0; i < backgroundsSpriteRenderer.Length; i++)
        {
            backgroundsSpriteRenderer[i].color = beforeColor;
        }
    }


    private void Update()
    {
        Debug.Log("playerPositionX = " + player.transform.position.x);
        if(nowTime <= player.transform.position.x)
        {
            if(nowTime < 299)
            {
                nextColor = nextColor + (minusColor / 4);
            }
            else
            {
                nextColor = nextColor - (minusColor / 0.9f);
            }
            lerpT = 0;
            nowTime += 60f;
            Debug.Log("before = " + beforeColor);
            Debug.Log("next = " + nextColor);
        }

        if(beforeColor != nextColor)
        {
            lerpT += Time.deltaTime * 2;
            if (lerpT >= 1) lerpT = 1;
            beforeColor = Color.Lerp(beforeColor, nextColor, lerpT);
            for (int i = 0; i < backgroundsSpriteRenderer.Length; i++)
            {
                backgroundsSpriteRenderer[i].color = beforeColor;
            }
        }
    }

}
