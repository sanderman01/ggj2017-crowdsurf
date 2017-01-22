using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This screen will show the game title and also the player engagement prompt.
/// This is where players will be able to hit their button and determine which color they own and how the basic controls work.
/// </summary>
public class TitleScreen : MonoBehaviour {

    const string gameScene = "PrototypeSceneMerge";

    [SerializeField]
    private Color[] playerColors;

    private Player[] players;
    private Character[] characters;

	// Use this for initialization
	void Start () {
        FindOrCreatePlayers();
    }

    private void FindOrCreatePlayers() {
        // Only create new players if they didn't already exist.
        characters = Object.FindObjectsOfType<Character>();
        players = Object.FindObjectsOfType<Player>();
        if (players.Length == 0) {
            players = new Player[4];
            GameObject obj = new GameObject("Players");
            DontDestroyOnLoad(obj);
            for (int i = 0; i < 4; ++i) {
                Player player = obj.AddComponent<Player>();
                player.SetPlayerNumber(i + 1);
                player.color = playerColors[i];
                player.Active = false;
                players[i] = player;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        CheckPlayerActivity();
        bool playersReady = CheckPlayersReady();
        if (playersReady)
            GoToGameScene();
	}

    private bool CheckPlayersReady() {
        int nActivePlayers = 0;
        bool allReady = true;
        foreach(Player p in players) {
            if(p.Active) {
                nActivePlayers += 1;
                allReady = allReady && p.Ready;
            }
        }

        return nActivePlayers > 1 && allReady;
    }



    /// <summary>
    /// Detect human players to activate and assign them a color and temporary character.
    /// </summary>
    void CheckPlayerActivity() {
        foreach (Player p in players) {
            if (!p.Active && !p.Idle) {
                // This player was not yet activated, but is now showing activity.
                // Activate and assign it to a character, so the player can identify his own color and the basic game mechanics.

                // Find the first available character and attach it.
                Character character = System.Array.Find(characters, c => { return !c.hasPlayer; });
                p.Attach(character);
                p.Active = true;
                Debug.Log("Assigned player " + p.playerNumber);
            }
        }
    }

    private void GoToGameScene() {
        foreach(Player p in players) {
            p.Detach();
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameScene);
    }
}
