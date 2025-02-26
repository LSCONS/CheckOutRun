using System.Collections;
using System.Collections.Generic;
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

    void Start()
    {
        dimPanel.gameObject.SetActive(false);
        pausePopup.gameObject.SetActive(false);

        highScore.text = DataManager.Instance.Score.ToString();
        highTime.text = DataManager.Instance.Score.ToString(); // Score부분 시간관련으로 바꿔야함

        settingBtn.onClick.AddListener(OnClickSetting);
        exitBtn.onClick.AddListener(OnClickExitBtn);
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
}