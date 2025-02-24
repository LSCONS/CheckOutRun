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

    }
}
