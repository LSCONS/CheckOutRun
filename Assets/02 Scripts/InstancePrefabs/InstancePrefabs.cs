using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancePrefabs : MonoBehaviour
{
    public GameObject[] Platforms;
    [SerializeField] private int instanceNum = 40;
    [SerializeField] private int startPositionX = -3;
    [SerializeField] private int startPositionY = -1;
    [SerializeField] private int width = 5;
    [SerializeField] private float minusY = 0.4f;


    private void Awake()
    {
        for(int i = 0; i < instanceNum; i++)
        {
            int rand = Random.Range(0, Platforms.Length);
            GameObject instacne = Instantiate(Platforms[rand], new Vector3(startPositionX + (i * width), startPositionY, 0), Quaternion.identity);
            BoxCollider2D box = instacne.AddComponent<BoxCollider2D>();
            box.size = new Vector2(box.size.x, box.size.y - (minusY / instacne.transform.localScale.y));
            box.offset = new Vector2(box.offset.x, box.offset.y - ((minusY/ 2) / instacne.transform.localScale.y));
        }
    }
}
