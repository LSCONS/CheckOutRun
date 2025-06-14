using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 게임 시작 전 로딩 화면을 관리하는 클래스입니다.
/// 카운트다운을 표시하고, 카운트다운이 끝나면 게임 씬으로 전환합니다.
/// </summary>
public class LoadingUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countDownText;
    private float delayBeforeStart = 1f;

    /// <summary>
    /// 로딩 화면이 시작될 때 호출됩니다.
    /// 카운트다운 코루틴을 시작합니다.
    /// </summary>
    void Start()
    {
        StartCoroutine(CountdownCoroutine());
    }

    /// <summary>
    /// 카운트다운을 수행하는 코루틴입니다.
    /// 카운트다운이 끝나면 게임 씬으로 전환합니다.
    /// </summary>
    private IEnumerator CountdownCoroutine()
    {
        countDownText.text = "Loading...";
        yield return new WaitForSeconds(delayBeforeStart);
        for (int i = 3; i > 0; i--)
        {
            countDownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        countDownText.text = "Start!";
        yield return new WaitForSeconds(delayBeforeStart);

        SceneManager.LoadScene(ReadonlyData.GameSceneName);
    }
}
