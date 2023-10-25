using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public Text HighScoreText;

    public void Awake()
    {
        TextChange();
    }

    public void Open()
    {
        if(Data.Instance.playerName != "")
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            HighScoreText.text = "Hey! Choose a name first!";
        }
    }

    public void NameSelect(Text nameText)
    {
        Data.Instance.playerName = nameText.text;
    }

    public void TextChange()
    {
        HighScoreText.text = "High Score: " + Data.Instance.highScore + " from " + Data.Instance.highName;
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
