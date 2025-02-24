using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameUI : MonoBehaviour
{
    Player player;
    public RectTransform front;
    public RectTransform back;
    public TextMeshProUGUI scoreTxt;
    [SerializeField] private TextMeshProUGUI timeTxt;

    public float lerpSpeed = 5f;

    public void Start()
    {
        player = FindObjectOfType<Player>();
        if (timeTxt == null)
        {
            Debug.LogError("Time is not assigned!");
            return;
        }
    }

    private void Update() // 나중에 업데이트 말고 다른걸로 수정해야됨...(최적화 문제)
    {
        UpdateTimeUI();
        UpdateHealthBar();
    }
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

    public void UpdateScoreUI()
    {
        int score = DataManager.Instance.Score;
        scoreTxt.text = score.ToString();
    }

    public void UpdateTimeUI()
    {
        float gameTime = TimeManager.Instance.gameTime;

        int hours = Mathf.FloorToInt(gameTime / 60);
        int minutes = Mathf.FloorToInt(gameTime % 60);
        timeTxt.text = string.Format("{0:D2}:{1:D2}", hours, minutes);
    }
}
