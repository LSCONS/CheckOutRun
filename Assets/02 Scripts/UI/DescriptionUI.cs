using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionUI : MonoBehaviour
{
    public GameObject[] descPanels;
    private int currentStep = 0;

    private void Start()
    {
        Time.timeScale = 0f;
        ShowStep(currentStep);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            ShowNextStep();
        }
    }

    public void ShowNextStep()
    {
        if(currentStep < descPanels.Length -1)
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
}
