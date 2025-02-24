using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    Player player;
    public RectTransform front;
    public TextMeshProUGUI scoreTxt;

    public void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void UpdateHealthBar() // hp�� ����� ������ ȣ���ؼ� UI�� ������Ʈ�������
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

    }
}
