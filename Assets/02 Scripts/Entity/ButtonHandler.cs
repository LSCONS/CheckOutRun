using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private PlayerController playerController;
    public bool isFlap = false;
    public bool isSlide = false;

    private void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player가 할당되지 않았습니다.");
            return;
        }
    }

    public void LoadGamePage() //변수명 수정했습니다. + ResultScene에서 다시하기 클릭시 이 함수 사용
    {
        SceneManager.LoadScene("GameScene");
    }

    //public void LoadTutorialPage() 튜토리얼 관련 기획 후 수정 예정
    //{
    //    SceneManager.LoadScene("TutorialScene")
    //}

    public void LoadResultPage() //GameScene에서 게임오버될때 사용 함수
    {
        SceneManager.LoadScene("ResultScene");
    }

    public void LoadMainPage() //ResultScene에서 다시하기/메인화면 중 메인화면 클릭시 사용 함수
    {
        SceneManager.LoadScene("MainScene");
    }

    public void PlayerJumpButton() 
    {
        isFlap = true;
        playerController.HandleJump();
    }
    public void PlayerSlideButton() 
    {
        isSlide = true;
        playerController.HandleSlide();
    }
    public void PlayerReleaseSlideButton() 
    {
        isSlide = false;
        playerController.HandleSlide();
    }

}
