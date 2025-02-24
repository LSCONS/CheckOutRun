using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class Platform_BoxCollider : MonoBehaviour
{
    float minusY = 0.4f;
    private void Awake()
    {
        BoxCollider2D box2D = gameObject.AddComponent<BoxCollider2D>();
        box2D.size = new Vector2(box2D.size.x, box2D.size.y - (minusY / transform.localScale.y));
        box2D.offset = new Vector2(box2D.offset.x, box2D.offset.y - ((minusY / 2) / transform.localScale.y));
    }
}
