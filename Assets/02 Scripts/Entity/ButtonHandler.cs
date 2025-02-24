using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private Player player;

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

    public void PlayerJumpButton(float flapForce) //���� ���� ����
    {
        player.velocity.y += flapForce;
        player.isFlap = false;
    }

    public void PlayerSlideButton(float forwardSpeed) //���� ���� ����
    {
        player.velocity.x += forwardSpeed;
        player.isSlide = false;
    }
}
