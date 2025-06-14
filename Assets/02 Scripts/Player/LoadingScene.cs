using System.Collections;
using UnityEngine;

public class LoadingScene : MonoBehaviour
{
    
    private Rigidbody2D rigidPlayer;
    private PlayerAnimationHandler animationHandler;
    private float moveSpeed = 3f;
    public GameObject SettingObject;
    

    private void Awake()
    {
        animationHandler    = GetComponent<PlayerAnimationHandler>();
        rigidPlayer         = GetComponent<Rigidbody2D>();
        StartCoroutine(Move());
    }


    //특정 시간 이후 오브젝트 활성화 및 플레이어를 오른쪽 위로 날려보냄.
    IEnumerator Move()
    {
        yield return new WaitForSeconds(0.7f);
        SettingObject.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        rigidPlayer.AddForce(new Vector2(200, 300));
        animationHandler.IsJump1Parameter = true;
    }


    //땅에 착지할 경우 걷는 모션과 함께 오른쪽으로 이동시킴.
    private void OnCollisionStay2D(Collision2D collision)
    {
        animationHandler.IsJump1Parameter = false;
        if (1 << collision.gameObject.layer == ReadonlyData.GroundLayerMask)
        {
            rigidPlayer.velocity = new Vector2(moveSpeed, rigidPlayer.velocity.y);
            animationHandler.IsGroundParameter = true;
        }
    }
}
