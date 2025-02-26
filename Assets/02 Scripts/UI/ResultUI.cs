using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    public Button returnBtn;
    public Button retryBtn;

    public TextMeshProUGUI resultTitle;
    public TextMeshProUGUI timeTxt;
    public TextMeshProUGUI scoreTxt;

    private void Start()
    {
        if (GameManager.Instance != null)
        {
            if (GameManager.Instance.isWin == true)
            {
                resultTitle.text = "퇴실 완료!";
            }
            else if (TimeManager.Instance.gameTime < 900f)
            {
                resultTitle.text = "결석 처리...";
            }
            else if (TimeManager.Instance.gameTime >= 900f && TimeManager.Instance.gameTime < 1260f)
            {
                resultTitle.text = "지각 처리...";
            }
        }
        SetTimeTxt();
        SetScoreTxt();

        returnBtn.onClick.AddListener(ReturnMainScene);
        retryBtn.onClick.AddListener(OnClickRetryBtn);
    }

    public void SetTimeTxt()
    {
        float gameTime = TimeManager.Instance.gameTime;

        int hours = Mathf.FloorToInt(gameTime / 60);
        int minutes = Mathf.FloorToInt(gameTime % 60);
        timeTxt.text = string.Format("{0:D2}:{1:D2}", hours, minutes);
    }

    public void SetScoreTxt()
    {
        scoreTxt.text = DataManager.Instance.Score.ToString();
    }

    void ReturnMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    void OnClickRetryBtn()
    {
        SceneManager.LoadScene("LoadingScene");
    }
}
