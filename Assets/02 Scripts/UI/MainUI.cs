using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// MainUI는 메인 메뉴에서 표시되는 UI 요소를 관리하는 클래스입니다.
/// 시작, 설정, 종료 버튼과 최고 점수, 최고 시간을 표시합니다.
/// </summary>
public class MainUI : MonoBehaviour
{
    public Button startBtn;
    public Button settingBtn;
    public Button exitBtn;
    public Button desBtn;

    public TextMeshProUGUI highScore;
    public TextMeshProUGUI highTime;

    public Transform dimPanel;
    public Transform pausePopup;

    //public Transform descBtn;

    void Start()
    {
        dimPanel.gameObject.SetActive(false);
        pausePopup.gameObject.SetActive(false);

        highScore.text = PlayerPrefs.GetInt(ReadonlyData.BestScorePlayerPrefabs).ToString();
        GetHighTime();

        settingBtn.onClick.AddListener(OnClickSetting);
        exitBtn.onClick.AddListener(OnClickExitBtn);

        if(PlayerPrefs.GetInt(DescriptionUI.AlreadyDescKey, 0) == 1)
        {
            desBtn.gameObject.SetActive(true);
        }
    }

    //private void OnEnable()
    //{
    //    if(PlayerPrefs.GetInt("AlreadyDesc", 0) == 1)
    //    {
    //        descBtn.gameObject.SetActive(true);
    //    }
    //}
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
        float gameTime = PlayerPrefs.GetFloat(ReadonlyData.BestScorePlayerPrefabs);

        int hours = Mathf.FloorToInt(gameTime / 60);
        int minutes = Mathf.FloorToInt(gameTime % 60);
        highTime.text = string.Format("{0:D2}:{1:D2}", hours, minutes);
    }
}