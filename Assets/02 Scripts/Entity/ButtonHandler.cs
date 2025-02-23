using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void OnClickStart()
    {
        SceneManager.LoadScene("GameScene");
    }

    float time = 0;
    private void FixedUpdate()
    {
        
    }
}
