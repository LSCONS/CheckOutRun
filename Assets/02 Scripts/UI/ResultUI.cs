using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class ResultUI : MonoBehaviour
{
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
            else
            {
                resultTitle.text = "퇴실 실패...";
            }
        }
        SetTimeTxt();
        SetScoreTxt();
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
}
