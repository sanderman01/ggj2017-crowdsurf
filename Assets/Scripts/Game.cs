﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    /// <summary>
    /// Number of seconds to show the Stats/Scores screen after ending the game, before switching to the next scene.
    /// </summary>
    private const float GameEndDelayLong = 15f;

    /// <summary>
    /// Number of seconds to show the Stats/Scores screen after stopping the game, before switching to the next scene.
    /// </summary>
    private const float GameEndDelayShort = 2f;

    /// <summary>
    /// Number of seconds to wait for an animation before starting actual play.
    /// </summary>
    private const float DelayGameStart = 3f;

    /// <summary>
    /// Next scene to load after showing the score window.
    /// </summary>
    private const string nextScene = "titleScreen";

	void Start () {
        StartGameRound();
    }

    void Update() {
    }

    private bool paused = false;
    public bool Paused {
        get { return paused; }
        set {
            if (value && !paused) PauseGame();
            else if (!value && paused) UnpauseGame();
        }
    }

    public void PauseGame() {
        paused = true;
        Time.timeScale = 0;
        ShowPauseMenu();
    }

    public void UnpauseGame() {
        paused = false;
        Time.timeScale = 1;
    }

    private void ShowPauseMenu() {
        // TODO Show Pauze Menu
    }

    private void StartGameRound()
    {
        StartCoroutine(StartGameRoutine());
    }

    private IEnumerator StartGameRoutine() {
        Debug.Log("Starting Game Round!");

        // TODO Game Starting Stuff

        // Make sure the ragdoll physics are disabled for now.
        Surfer surfer = GameObject.FindObjectOfType<Surfer>();
        surfer.RigidbodyActive = false;

        // Make sure players exist and are active
        // Generate audience
        // Assign players to audience
        SwitchingCharacter switching = GameObject.FindObjectOfType<SwitchingCharacter>();
        Player[] players = GameObject.FindObjectsOfType<Player>();
        foreach (Player p in players) {
            if (p.Active) {
                switching.Switch(p);
            }
        }

        // Do animation
        
        // TODO Start Animation

        // Wait for the animation to finish
        yield return new WaitForSeconds(DelayGameStart);

        // Stop animations (if they were still running) and enable ragdoll
        // TODO Stop animation.
        surfer.RigidbodyActive = true;

        // Make sure we get an event when the ragdoll hits the floor.
        surfer.OnHitFloor += OnHitFloorHandler;

        // Start the game!

        Stats.StartGame();

        yield return null;
    }

    private void OnHitFloorHandler(Surfer sender, Vector3 pos) {
        LoseGame();
    }

    /// <summary>
    /// Ragdoll hit the floor so the game was lost.
    /// </summary>
    public void ResetGame() {
        EndGameRound(GameEndDelayShort, Stats.GameEndedReason.Reset);
    }

    /// <summary>
    /// Ragdoll hit the floor so the game was lost.
    /// </summary>
    public void LoseGame() {
        EndGameRound(GameEndDelayLong, Stats.GameEndedReason.Failed);
    }

    /// <summary>
    /// Abort the current game and quickly go back to title.
    /// </summary>
    public void EndGameRound(float gameEndDelay, Stats.GameEndedReason reason) {
        // Disable further updates on the surfer ragdoll.
        Surfer surfer = GameObject.FindObjectOfType<Surfer>();
        surfer.enabled = false;

        // Detach players from characters
        Player[] players = GameObject.FindObjectsOfType<Player>();
        foreach(Player p in players) {
            p.Detach();
        }

        // Lock in stats and determine scores.
        Stats.EndGame(Stats.GameEndedReason.Reset);
        // TODO Score calculation?

        StartCoroutine(ShowEndGameScreen(gameEndDelay));
    }

    private IEnumerator ShowEndGameScreen(float gameEndDelay) {
        // Show GameEnd screen containing stats and scores
        // TODO show GameEndScreen ?
        //GameEndScreen gameEnd = GameObject.FindObjectOfType<GameEndScreen>();
        //gameEnd.Show();

        // Wait some period before switching back to titlescreen/player-engagement-screen.
        yield return new WaitForSecondsRealtime(gameEndDelay);

        // Switch to the title screen by loading the next scene.
        SceneManager.LoadScene(nextScene);
    }
}
