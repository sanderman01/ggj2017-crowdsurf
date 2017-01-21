﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    private GUIStyle normalButton;
    private GUIStyle selectedButton;
    private GUIStyle[] buttonGUI;
    public GUISkin _GUISkins;
    private int selectedButtonInt;

    void Start()
    {
        normalButton = _GUISkins.FindStyle("Normal");
        selectedButton = _GUISkins.FindStyle("Selected");
        buttonGUI = new GUIStyle[3];
        SetGUISKins(0);
        this.gameObject.SetActive(false);
    }

    public void NextOption()
    {
        SetGUISKins(selectedButtonInt + 1);
    }

    public void OnEnable()
    {
        SetGUISKins(0);
    }

    public void PreviousOption()
    {
        if (selectedButtonInt == 0)
        {
            SetGUISKins(buttonGUI.Length - 1);
        }
        else
        {
            SetGUISKins(selectedButtonInt - 1);
        }
    }

    public void SetGUISKins(int selected)
    {
        selected = selected % buttonGUI.Length;
        for (int i = 0; i < buttonGUI.Length; i++)
        {
            if (i == selected)
            {
                buttonGUI[i] = _GUISkins.FindStyle("Selected");
            }
            else
            {
                buttonGUI[i] = _GUISkins.FindStyle("Normal");
            }
        }
        selectedButtonInt = selected;
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 8 * 3, Screen.height / 5 * 2 - Screen.height / 6, Screen.width / 8 * 6, Screen.height / 6), "Resume", buttonGUI[0]))
        {
            
        }
        if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 8 * 3, Screen.height / 5 * 3 - Screen.height / 6, Screen.width / 8 * 6, Screen.height / 6), "Restart", buttonGUI[1]))
        {
            
        }
        if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 8 * 3, Screen.height / 5 * 4 - Screen.height / 6, Screen.width / 8 * 6, Screen.height / 6), "Quit", buttonGUI[2]))
        {
            
        }
    }

    public void Select()
    {
        switch (selectedButtonInt)
        {
            case 0:
                GameObject.Find("Game").GetComponent<PauseManager>().Pause();
                this.gameObject.SetActive(false);
                break;
            case 1:
                Restart();
                break;
            case 2:
                Application.Quit();
                break;
        }
    }

    void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
