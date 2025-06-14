using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// ResultUI는 게임 결과 화면에서 표시되는 UI 요소를 관리하는 클래스입니다.
/// 결과 제목, 시간, 점수를 표시하고, 다시 시도 및 메인 화면으로 돌아가는 버튼을 제공합니다.
/// </summary>
public class ResultUI : MonoBehaviour
{
    public Button returnBtn;
    public Button retryBtn;

    public TextMeshProUGUI resultTitle;
    public TextMeshProUGUI timeTxt;
    public TextMeshProUGUI scoreTxt;

    private void Start()
    {
        IsGameClear nowGameClear = TimeManager.Instance.GetNowState();

        switch (nowGameClear)
        {
            case IsGameClear.Clear:
                resultTitle.text = "출석 완료!";
                break;
            case IsGameClear.Absence:
                resultTitle.text = "결석 처리...";
                break;
            case IsGameClear.Perception:
                resultTitle.text = "지각 처리...";
                break;
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
        SceneManager.LoadScene(ReadonlyData.MainSceneName);
    }

    void OnClickRetryBtn()
    {
        SceneManager.LoadScene(ReadonlyData.LoadingSceneName);
    }
}
