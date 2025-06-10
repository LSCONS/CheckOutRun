using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 Instance => _instance;
    private static GameManager2 _instance;
    public GameObject endPanel;
    public Text timeTxt;
    public Text bestScoreTxt;
    public Text tryCountTxt;
    public float timeLimit;

    private float remainTime;
    private bool isCounting; // 시간 업데이트 제어를 위한 플래그
    public float cardFlipDelayTime;
    public float cardCloseDelayTime;
    public float MoveToClearSceneDelayTime;

    public GameObject cardObjects;

    public Card firstCard;
    public Card secondCard;
    public int cardCount;
    public int selectCount;
    int tryCount;

    private void Awake()
    {
        Time.timeScale = 1.0f;
        Application.targetFrameRate = 60;
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != null)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        remainTime = timeLimit;
        isCounting = true; // 카운트 시작
        timeTxt.text = timeLimit.ToString("N2");
    }

    public void isMatched()
    {
        if (firstCard.index == secondCard.index)
        {
            checkMatched();
            cardCount -= 2;

            if (cardCount == 0)
            {
                tryCount = selectCount / 2;
                SaveCurrentCount();
                isCounting = false; // 시간 카운트 멈춤
                StartCoroutine(WaitAndClearGame()); // 1초 후 씬 전환
            }
        }
        else
        {
            checkMatched();
        }
    }

    public void checkMatched()
    {
        SetActiveFalseButtonObjects(); // 모든 버튼 오브젝트 비활성화
        if (firstCard.index == secondCard.index)
        {
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            AudioManager.instance.SoundPlayMatchSuccess(0.5f);
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
            AudioManager.instance.SoundPlayMatchFailed(0.5f);
        }
        firstCard = null;
        secondCard = null;
        Invoke(nameof(SetActiveTrueButtonObjects), cardFlipDelayTime);
    }

    void Update()
    {
        if (isCounting && remainTime > 0) // isCounting이 true일 때만 시간 감소
        {
            remainTime -= Time.deltaTime;
            timeTxt.text = remainTime.ToString("N2");
        }
        else if (remainTime <= 0)
        {
            endPanel.SetActive(true);
            Time.timeScale = 0.0f;
            timeTxt.text = "0.00";
            if (PlayerPrefs.GetInt("BestScore") == 0)
            {
                bestScoreTxt.text = "기록이 없습니다.";
            }
            else
            {
                bestScoreTxt.text = PlayerPrefs.GetInt("BestScore").ToString("N2");
            }
        }

        tryCount = selectCount / 2;
        tryCountTxt.text = tryCount.ToString();
    }

    private IEnumerator WaitAndClearGame()
    {
        yield return new WaitForSeconds(1.0f); // 1초 대기 (Time.timeScale의 영향을 받지 않음)
        ClearGameMoveScene();
    }

    private void SaveCurrentCount()
    {
        if (PlayerPrefs.GetInt("BestScore") == 0)
        {
            PlayerPrefs.SetInt("BestScore", tryCount);
            bestScoreTxt.text = PlayerPrefs.GetInt("BestScore").ToString("N2");
        }
        else
        {
            if (tryCount < PlayerPrefs.GetInt("BestScore"))
            {
                PlayerPrefs.SetInt("BestScore", tryCount);
            }
        }
        PlayerPrefs.SetInt("CurrentScore", tryCount);
    }

    public void SetActiveTrueButtonObjects()
    {
        List<GameObject> buttonObject = GetButtonGameObjects(cardObjects, "Button");

        if (buttonObject.Count > 0)
        {
            for (int i = 0; i < buttonObject.Count; i++)
            {
                buttonObject[i].SetActive(true);
            }
        }
    }

    public void SetActiveFalseButtonObjects()
    {
        List<GameObject> buttonObject = GetButtonGameObjects(cardObjects, "Button");

        if (buttonObject.Count > 0)
        {
            for (int i = 0; i < buttonObject.Count; i++)
            {
                buttonObject[i].SetActive(false);
            }
        }
    }

    private List<GameObject> GetButtonGameObjects(GameObject parentObject, string tag)
    {
        List<GameObject> result = new List<GameObject>();

        foreach (Transform child in parentObject.transform)
        {
            if (child.gameObject.CompareTag(tag))
            {
                result.Add(child.gameObject);
            }

            result.AddRange(GetButtonGameObjects(child.gameObject, tag));
        }

        return result;
    }

    private void ClearGameMoveScene()
    {
        SceneManager.LoadScene("ClearScene");
    }
}
