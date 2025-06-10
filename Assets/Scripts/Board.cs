using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    public GameObject cardPref;
    public GameObject parentObject;

    void Start()
    {
        int[] arr = new int[24];

        for(int i = 0; i < 24; i++)
        {
            arr[i] = i%12;

        }
        
        arr = arr.OrderBy(x => Random.Range(0f,11f)).ToArray();
        GameManager2.Instance.cardCount = arr.Length;

        

        for(int i = 0; i < 24 ; i++)
        {

            float x = i%4*1.2f -1.8f;
            float y = i/4*1.4f -4.0f;

            GameObject go = Instantiate(cardPref, new Vector3(x, y, 0), Quaternion.identity, parentObject.transform);

            go.GetComponent<Card>().Setting(arr[i]);
            
        }
        
    }
}
