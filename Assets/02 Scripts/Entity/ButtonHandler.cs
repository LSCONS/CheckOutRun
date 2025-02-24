using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private PlayerController playerController;
    public Button pauseButton;
    public GameObject pausePopUp;
    private void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player이 할당되지 않았습니다.");
            return;
        }
    }

    public void LoadGamePage() //결과씬에서 다시하기 버튼 클릭시 이 함수 사용
    {
        SceneManager.LoadScene("GameScene");
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

    public void OpenPuasePopUpPage()
    {
        Time.timeScale = 0f;
        pauseButton = GetComponentInChildren<Button>(true);
        pausePopUp = GetComponentInChildren<GameObject>(true);
        pausePopUp.SetActive(true);
    }

    public void OnClickContinue()
    {
        pausePopUp.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnClickExit()
    {
        //pausePopUp.SetActive(false);
        LoadMainPage();
    }

}
