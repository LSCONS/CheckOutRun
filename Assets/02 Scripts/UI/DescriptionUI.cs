using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionUI : MonoBehaviour
{
    public GameObject[] descPanels;
    public int currentStep = 0;
    public static string AlreadyDescKey = "AlreadyDesc";

    private void OnEnable()
    {
        Time.timeScale = 0f;
        ShowStep(currentStep);
        PlayerPrefs.SetInt(AlreadyDescKey, 1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            ShowNextStep();
        }
    }

    public void ShowNextStep()
    {
        if (currentStep < descPanels.Length - 1)
        {
            descPanels[currentStep].SetActive(false);
            currentStep++;
            descPanels[currentStep].SetActive(true);
        }
        else
        {
            descPanels[currentStep].SetActive(false);
            gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    private void ShowStep(int step)
    {
        for (int i = 0; i < descPanels.Length; i++)
        {
            descPanels[i].SetActive(i == step);
        }
    }

    private void OnDisable()
    {
        currentStep = 0;
    }
}
