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

    private void Update()
    {
        UpdateTimeUI();
        UpdateHealthBar();
    }
    public void UpdateHealthBar() // hp�� ����� ������ ȣ���ؼ� UI�� ������Ʈ�������
    {
        float currentHp = player.playerHealth;
        float maxHp = player.playerMaxHealth;

        float height = front.sizeDelta.y;

        float fullWidth = 400f;
        float minWidth = 50f;

        // ��ǥ��
        float targetWidth = minWidth + ((currentHp / maxHp) * (fullWidth - minWidth));
        // ���� ��
        float currentWidth = front.sizeDelta.x;

        // ������ �ε巴�� �̵�
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
