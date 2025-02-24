using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    public TextMeshProUGUI highScore;

    void Start()
    {
        highScore.text = DataManager.Instance.Score.ToString();

    }
}
