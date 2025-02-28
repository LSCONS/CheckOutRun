using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    Player player;
    public RectTransform front;

    public TextMeshProUGUI scoreTxt;
    [SerializeField] private TextMeshProUGUI timeTxt;
    public Slider timeSlider;
    public GameObject descriptionUI_Canvas;

    public float lerpSpeed = 5f;

    public void Start()
    {
        player = FindObjectOfType<Player>();
        if (timeTxt == null)
        {
            Debug.LogError("Time is not assigned!");
            return;
        }

        if(PlayerPrefs.GetInt(DescriptionUI.AlreadyDescKey, 0) == 0)
        {
            descriptionUI_Canvas.SetActive(true);
        }
    }

    private void Update()
    {
        UpdateTimeUI();
        UpdateHealthBar();
        UpdateTimeSlider();
    }

    /// <summary>
    /// 체력 바를 업데이트합니다.
    /// </summary>
    public void UpdateHealthBar() // hp가 변경될 때마다 호출해서 UI를 업데이트해줘야함
    {
        float currentHp = player.playerHealth;
        float maxHp = player.playerMaxHealth;

        float height = front.sizeDelta.y;

        float fullWidth = 400f;
        float minWidth = 50f;

        // 목표값
        float targetWidth = minWidth + ((currentHp / maxHp) * (fullWidth - minWidth));
        // 현재 값
        float currentWidth = front.sizeDelta.x;

        // 게이지 부드럽게 이동
        float newWidth = Mathf.Lerp(currentWidth, targetWidth, Time.deltaTime * lerpSpeed);

        front.sizeDelta = new Vector2(newWidth, height);
    }

    /// <summary>
    /// 점수 UI를 업데이트합니다.
    /// </summary>
    public void UpdateScoreUI()
    {
        int score = DataManager.Instance.Score;
        scoreTxt.text = score.ToString();
    }

    /// <summary>
    /// 시간 UI를 업데이트합니다.
    /// </summary>
    public void UpdateTimeUI()
    {
        float gameTime = TimeManager.Instance.gameTime;

        int totalhours = Mathf.FloorToInt(gameTime / 60);
        int minutes = Mathf.FloorToInt(gameTime % 60);

        string AMPM = (gameTime / 60) <= 12 ? "AM" : "PM";
        int hours = totalhours % 12;
        if(hours == 0) hours = 12;

        timeTxt.text = string.Format("{0:D2} : {1:D2} {2}", hours, minutes, AMPM);
    }

    public void UpdateTimeSlider()
    {
        float gameTime = TimeManager.Instance.gameTime;

        timeSlider.value = (gameTime - 540f) / 720f;
    }
}
