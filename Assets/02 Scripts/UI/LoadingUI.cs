using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countDownText;
    private float delayBeforeStart = 1f;

    void Start()
    {
        StartCoroutine(CountdownCoroutine());
    }

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

        SceneManager.LoadScene("GameScene");
    }
}
