using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPlayer : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject clearBackground;
    public GameObject mainUI;
    public GameObject pauseUI;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(1 << collision.gameObject.layer == ReadonlyData.PlayerLayerMask)
        {
            StartCoroutine(ThrowNow(collision.gameObject));

        }
    }


    IEnumerator ThrowNow(GameObject player)
    {
        Rigidbody2D playerRigidbody = player.GetComponent<Rigidbody2D>();
        GameManager.Instance.isWin = true;
        playerRigidbody.gravityScale = 0f;
        mainUI.SetActive(false);
        pauseUI.SetActive(false);

        PlayerAnimationHandler playerAnimation = player.GetComponent<PlayerAnimationHandler>();

        Player player1 = player.GetComponent<Player>();

        playerRigidbody.AddForce(new Vector2(1000, 1000));

        yield return new WaitForSeconds(1f);

        playerAnimation.IsJump1Parameter = false;
        playerAnimation.IsJump2Parameter = false;
        playerAnimation.IsClearParameter = true;
        Destroy(playerRigidbody);
        Destroy(player.GetComponent<PlayerMoveCheck>());
        player.transform.position = new Vector3(800, 200, 0);
        //배경 움직이기 시작
        clearBackground.SetActive(true);

        yield return new WaitForSeconds(1f);
        Camera camera = Camera.main;
        camera.orthographicSize = 6;
        mainCamera.transform.position = player.transform.position + Vector3.back * 10;
    }
}
