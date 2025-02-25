using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    private PlayerController playerController;
    public Transform pausePopUp;
    public Transform dimPanel;

    private void Awake()
    {
        if(GameObject.Find("Player") != null)
        {
            playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        }
    }

    public void LoadLoadingPage() //결과씬에서 다시하기 버튼 클릭시 이 함수 사용
    {
        SceneManager.LoadScene("LoadingScene");
    }

    //public void LoadTutorialPage() //튜토리얼 구현시 사용
    //{
    //    SceneManager.LoadScene("TutorialScene")
    //}

    public void LoadResultPage() //GameScene에서 GameOver시 사용
    {
        SceneManager.LoadScene("ResultScene");
    }

    public void LoadMainPage() //ResultScene에서 나가기or 메인화면으로 돌아가기 버튼 클릭시 이 함수 사용 
    {
        SceneManager.LoadScene("MainScene");
    }

    public void PlayerJumpButton()
    {
        playerController.isFlap = true; 
        playerController.HandleJump();
    }

    public void PlayerSlideButton()
    {
        playerController.isSlide = true; 
        playerController.HandleSlide();
    }

    public void PlayerReleaseSlideButton()
    {
        playerController.isSlide = false; 
        playerController.HandleSlide();
    }
}
