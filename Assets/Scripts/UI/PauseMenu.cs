using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    private GUIStyle normalButton;
    private GUIStyle selectedButton;
    private GUIStyle[] buttonGUI;
    public GUISkin _GUISkin;
    private int selectedButtonInt;
    public Texture[] imagesNormal;
    public Texture[] imagesSelected;
    public Texture[] currentTexture;

    void Start()
    {
        normalButton = _GUISkin.FindStyle("Normal");
        buttonGUI = new GUIStyle[3];
        SetGUISKins(0);
        this.gameObject.SetActive(false);
        currentTexture = new Texture[imagesNormal.Length];
        currentTexture = imagesNormal;
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
        if (buttonGUI != null)
        {
            selected = selected % buttonGUI.Length;
            for (int i = 0; i < buttonGUI.Length; i++)
            {
                if (i == selected)
                {
                    currentTexture[i] = imagesSelected[i];
                }
                else
                {
                    currentTexture[i] = imagesNormal[i];
                }
            }
            selectedButtonInt = selected;
        }
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 8 * 3, Screen.height / 5 * 2 - Screen.height / 6, Screen.width / 8 * 6, Screen.height / 6), currentTexture[0], normalButton))
        {

        }

        if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 8 * 3, Screen.height / 5 * 3 - Screen.height / 6, Screen.width / 8 * 6, Screen.height / 6), currentTexture[1], normalButton))
        {

        }
        if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 8 * 3, Screen.height / 5 * 4 - Screen.height / 6, Screen.width / 8 * 6, Screen.height / 6), currentTexture[2], normalButton))
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
