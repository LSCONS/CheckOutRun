using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public Button startBtn;
    public Button settingBtn;
    public Button exitBtn;

    public TextMeshProUGUI highScore;
    public TextMeshProUGUI highTime;

    public Transform dimPanel;
    public Transform pausePopup;

    public Transform descBtn;

    void Start()
    {
        dimPanel.gameObject.SetActive(false);
        pausePopup.gameObject.SetActive(false);
        descBtn.gameObject.SetActive(false);

        highScore.text = PlayerPrefs.GetInt("bestScore").ToString();
        GetHighTime();

        settingBtn.onClick.AddListener(OnClickSetting);
        exitBtn.onClick.AddListener(OnClickExitBtn);
    }

    private void OnEnable()
    {
        if(PlayerPrefs.GetInt("AlreadyDesc", 0) == 1)
        {
            descBtn.gameObject.SetActive(true);
        }
    }
    void OnClickSetting()
    {
        dimPanel.gameObject.SetActive(true);
        pausePopup.gameObject.SetActive(true);
    }

    void OnClickExitBtn()
    {
        dimPanel.gameObject.SetActive(false);
        pausePopup.gameObject.SetActive(false);
    }

    void GetHighTime()
    {
        float gameTime = PlayerPrefs.GetFloat("bestTime");

        int hours = Mathf.FloorToInt(gameTime / 60);
        int minutes = Mathf.FloorToInt(gameTime % 60);
        highTime.text = string.Format("{0:D2}:{1:D2}", hours, minutes);
    }
}