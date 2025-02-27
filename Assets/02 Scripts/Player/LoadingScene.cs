using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private PlayerAnimationHandler animationHandler;
    private float moveSpeed = 3f;
    public GameObject SettingObject;
    
    // Start is called before the first frame update
    void Start()
    {
        animationHandler = GetComponent<PlayerAnimationHandler>();
        rb = GetComponent<Rigidbody2D>();
        if (animationHandler == null) Debug.LogError("animationHandler is null");
        if (rb == null) Debug.LogError("rigidbody is null");
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        Debug.Log("들어왔어");
        yield return new WaitForSeconds(0.7f);
        SettingObject.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        Debug.Log("나갔어");
        rb.AddForce(new Vector2(200, 300));
        animationHandler.IsJump1 = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        animationHandler.IsJump1 = false;
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            animationHandler.IsGround = true;
        }
    }
}
