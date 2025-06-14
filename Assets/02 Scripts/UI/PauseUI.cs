using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    public Button pauseBtn;
    public Button continueBtn;
    public Button exitBtn;

    public Transform pausePopup;
    public Transform dimPanel;

    void Start()
    {
        dimPanel.gameObject.SetActive(false);
        pausePopup.gameObject.SetActive(false);

        pauseBtn.onClick.AddListener(OpenPausePopup);
        continueBtn.onClick.AddListener(OnClickContinue);
        exitBtn.onClick.AddListener(OnClickExit);
    }

    public void OpenPausePopup()
    {
        Time.timeScale = 0f;
        dimPanel.gameObject.SetActive(true);
        pausePopup.gameObject.SetActive(true);
    }

    public void OnClickContinue()
    {
        dimPanel.gameObject.SetActive(false);
        pausePopup.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnClickExit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(ReadonlyData.MainSceneName);
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.bgmManager.StopBGM();
        }
    }
}
