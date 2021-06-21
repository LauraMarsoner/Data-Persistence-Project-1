using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI currentName;

    private void Start()
    {
        MenuHandler.Instance.LoadBestScoreAndName();
        bestScoreText.text = "Best Score: " + MenuHandler.Instance.bestName + " :" + MenuHandler.Instance.bestScore;
    }

    public void StartGame()
    {
        MenuHandler.Instance.currentName = currentName.text;
        SceneManager.LoadScene("main");

    }

    public void Quit()
    {
        MenuHandler.Instance.SaveBestScoreAndName();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }


}
