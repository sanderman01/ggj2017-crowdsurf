using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {

    public GameObject pauseUI;
    bool isPaused = false;

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
