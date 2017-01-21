using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {

    Controls[] controls = new Controls[4];

    public GameObject pauseUI;
    private bool[] cooldown = new bool[4];
    bool isPaused = false;

    void Start()
    {
        for (int i = 0; i < controls.Length; i++)
        {
            controls[i] = new Controls();
            controls[i].SetJoystickID(i+1);
            cooldown[i] = false;
        }
    }

    void Update()
    {
        for (int i = 0; i < controls.Length; i++)
        {
            if (Mathf.Abs(controls[i].GetLeftAxisY()) > 0.6) {
                if (!cooldown[i])
                {
                    {
                        cooldown[i] = true;
                        if (controls[i].GetLeftAxisY() < 0)
                        {
                            pauseUI.gameObject.GetComponent<PauseMenu>().NextOption();
                        }
                        else
                        {
                            pauseUI.gameObject.GetComponent<PauseMenu>().PreviousOption();
                        }
                    }
                }
            }
            else
            {
                cooldown[i] = false;
            }
            if (controls[i].ADown())
            {
                pauseUI.gameObject.GetComponent<PauseMenu>().Select();
            }
            if (controls[i].StartDown())
            {
                if (pauseUI.activeSelf)
                {
                    pauseUI.SetActive(false);
                }
                else
                {
                    pauseUI.SetActive(true);
                }
            }
        }
    }

	// Use this for initialization
	public void Pause() {
        if (isPaused)
        {
            Time.timeScale = 1.0f;
            pauseUI.SetActive(false);
        }
        else
        {
            Time.timeScale = 0.0f;
            pauseUI.SetActive(true);
        }
        isPaused = !isPaused;
    }
}
