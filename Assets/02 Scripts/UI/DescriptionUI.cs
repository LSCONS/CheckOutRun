using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임 설명 UI를 관리하는 클래스입니다.
/// 설명 패널을 순차적으로 표시하고, 설명이 끝나면 게임을 시작합니다.
/// 메인씬에서 동작할 시, 설명이 끝나면 패널이 닫히고 메인씬이 계속됩니다.
/// </summary>
public class DescriptionUI : MonoBehaviour
{
    public GameObject[] descPanels;
    public int currentStep = 0;
    public static string AlreadyDescKey = "AlreadyDesc";

    /// <summary>
    /// 설명 UI가 활성화될 때 호출됩니다.
    /// 첫 번째 설명 패널을 표시하고, 시간을 멈춥니다.
    /// </summary>
    private void OnEnable() //Start에서 시작할 경우 다중 확인이 되지 않음
    {
        Time.timeScale = 0f;
        ShowStep(currentStep);
        PlayerPrefs.SetInt(AlreadyDescKey, 1);
    }

    /// <summary>
    /// 매 프레임마다 호출됩니다.
    /// 스페이스 키 또는 마우스 클릭을 감지하여 다음 설명 패널을 표시합니다.
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            ShowNextStep();
        }
    }

    /// <summary>
    /// 다음 설명 패널을 표시합니다.
    /// 모든 설명이 끝나면 설명 UI를 비활성화하고, 시간을 다시 흐르게 합니다.
    /// </summary>
    public void ShowNextStep() //다음 판넬로 넘어가는 로직
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

    /// <summary>
    /// 지정된 단계의 설명 패널을 표시합니다.
    /// </summary>
    /// <param name="step">표시할 설명 패널의 단계</param>
    private void ShowStep(int step)
    {
        for (int i = 0; i < descPanels.Length; i++)
        {
            descPanels[i].SetActive(i == step);
        }
    }

    /// <summary>
    /// 설명 UI가 비활성화될 때 호출됩니다.
    /// 현재 단계를 초기화합니다.
    /// </summary>
    private void OnDisable()
    {
        currentStep = 0;
    }
}
