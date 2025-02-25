using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private float moveSpeed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (rb == null) return;

        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }
}
