using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{

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

    //public void Jump() //���� ���� ����
    //{

    //}

    //public void Slide() //���� ���� ����
    //{

    //}
}
