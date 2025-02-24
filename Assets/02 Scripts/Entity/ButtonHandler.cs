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
            Debug.LogError("Player�� �Ҵ���� �ʾҽ��ϴ�.");
            return;
        }
    }

    public void LoadGamePage() //������ �����߽��ϴ�. + ResultScene���� �ٽ��ϱ� Ŭ���� �� �Լ� ���
    {
        SceneManager.LoadScene("GameScene");
    }

    //public void LoadTutorialPage() Ʃ�丮�� ���� ��ȹ �� ���� ����
    //{
    //    SceneManager.LoadScene("TutorialScene")
    //}

    public void LoadResultPage() //GameScene���� ���ӿ����ɶ� ��� �Լ�
    {
        SceneManager.LoadScene("ResultScene");
    }

    public void LoadMainPage() //ResultScene���� �ٽ��ϱ�/����ȭ�� �� ����ȭ�� Ŭ���� ��� �Լ�
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
