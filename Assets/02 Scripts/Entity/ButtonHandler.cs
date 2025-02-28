using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 버튼 클릭 이벤트를 처리하는 클래스입니다.
/// 씬 전환, 플레이어 동작, 게임 종료 등의 기능을 제공합니다.
/// </summary>
public class ButtonHandler : MonoBehaviour
{
    private PlayerController playerController;
    private GameObject ReDesc;

    /// <summary>
    /// 플레이어 컨트롤러를 초기화합니다.
    /// </summary>
    private void Awake()
    {
        if(GameObject.Find("Player") != null)
        {
            playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        }
    }
    /// <summary>
    /// 메인씬에서 출석 버튼 클릭 시 호출됩니다.
    /// 로딩 씬을 로드합니다.
    /// </summary>
    public void LoadLoadingPage()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    /// <summary>
    /// 게임 씬에서 게임 오버 시 호출됩니다.
    /// 결과 씬을 로드합니다.
    /// </summary>
    public void LoadResultPage() 
    {
        SceneManager.LoadScene("ResultScene");
    }

    /// <summary>
    /// 결과 씬에서 메인화면 버튼 클릭 시 호출됩니다.
    /// 게임 씬에서 일시정지 후 나가기 버튼 클릭 시 호출됩니다.
    /// 메인 씬을 로드합니다.
    /// </summary>
    public void LoadMainPage()
    {
        SceneManager.LoadScene("MainScene");
    }

    /// <summary>
    /// 플레이어 점프 버튼 클릭 시 호출됩니다.
    /// 플레이어가 점프하도록 처리합니다.
    /// </summary>
    public void PlayerJumpButton()
    {
        playerController.isFlap = true; 
        playerController.HandleJump();
    }

    /// <summary>
    /// 플레이어 슬라이드 버튼 클릭 시 호출됩니다.
    /// 플레이어가 슬라이드하도록 처리합니다.
    /// </summary>
    public void PlayerSlideButton()
    {
        playerController.isSlide = true;
    }

    /// <summary>
    /// 플레이어 슬라이드 버튼을 놓을 때 호출됩니다.
    /// 플레이어의 슬라이드를 해제합니다.
    /// </summary>
    public void PlayerReleaseSlideButton()
    {
        playerController.isSlide = false; 
    }

    /// <summary>
    /// 메인 씬에서 게임 종료 버튼 클릭 시 호출됩니다.
    /// 애플리케이션을 종료합니다.
    /// </summary>
    public void OnApplicationQuit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    /// <summary>
    /// 메인 씬에서 게임 설명 버튼 클릭 시 호출됩니다.
    /// 설명 UI를 활성화합니다.
    /// </summary>
    public void ActiveDescCanvas()
    {
        ReDesc = GetComponentInChildren<DescriptionUI>(true).gameObject;
        if (ReDesc == null) return;
        ReDesc.SetActive(true);
    }
}
