using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    Player player;
    public RectTransform front;
    public TextMeshProUGUI scoreTxt;
    [SerializeField] private TextMeshProUGUI Time;

    public void Start()
    {
        player = FindObjectOfType<Player>();
        if (Time == null)
        {
            Debug.LogError("Time is not assigned!");
            return;
        }
    }

    private void Update()
    {
        UpdateTimeUI();
    }
    public void UpdateHealthBar() // hp가 변경될 때마다 호출해서 UI를 업데이트해줘야함
    {
        float hp = player.playerHealth / 100f;
        front.localScale = new Vector3(hp , 1f, 1f);
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
        Time.text = string.Format("{0:D2}:{1:D2}", hours, minutes);
    }
}
