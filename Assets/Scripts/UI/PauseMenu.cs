using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    private GUIStyle normalButton;
    private GUIStyle selectedButton;
    private GUIStyle[] buttonGUI;
    public GUISkin _GUISkins;
    private int selectedButtonInt;

    void Start()
    {
        normalButton = _GUISkins.FindStyle("Normal");
        selectedButton = _GUISkins.FindStyle("Selected");
//        SetGUISKins(0);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.F5))
        {
            Restart();
        }
    }

 /*   public void NextOption()
    {
        SetGUISKins(selectedButtonInt + 1);
    }

    public void PreviousOption()
    {
        if(selectedButtonInt == 0)
        {
            SetGUISKins(buttonGUI.Length);
        }
        else
        {
            SetGUISKins(selectedButtonInt - 1);
        }
    }*/

/*    public void SetGUISKins(int selected)
    {
        selected = selected % buttonGUI.Length;
        for (int i = 0; i < buttonGUI.Length; i++)
        {
            if(i == selected)
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
        if(GUI.Button(new Rect(Screen.width / 2 - Screen.width / 8 * 3, Screen.height / 5 * 2 - Screen.height /6, Screen.width / 8 * 6, Screen.height / 6), "Resume", normalButton)) {
            GameObject.Find("PauseManager").GetComponent<PauseManager>().Pause();
        }
        if(GUI.Button(new Rect(Screen.width / 2 - Screen.width / 8 * 3, Screen.height / 5 * 3 - Screen.height / 6, Screen.width / 8 * 6, Screen.height / 6), "Restart", selectedButton))
        {
            Restart();
        }
        if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 8 * 3, Screen.height / 5 * 4 - Screen.height / 6, Screen.width / 8 * 6, Screen.height / 6), "Quit", normalButton))
        {
            Application.Quit();
        }
    }
    */
    void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}
