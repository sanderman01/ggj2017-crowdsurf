using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This screen will show the game title and also the player engagement prompt.
/// This is where players will be able to hit their button and determine which color they own and how the basic controls work.
/// </summary>
public class TitleScreen : MonoBehaviour {

    const string gameScene = "PrototypeSceneMerge";

    public int MinActivePlayers = 2;

    private Character[] characters;

	// Use this for initialization
	void Start () {
        characters = FindObjectsOfType<Character>();
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
        foreach(Player p in PlayerManager.Players) {
            if(p.Active) {
                nActivePlayers += 1;
                allReady = allReady && p.Ready;
            }
        }

        return nActivePlayers >= MinActivePlayers && allReady;
    }



    /// <summary>
    /// Detect human players to activate and assign them a color and temporary character.
    /// </summary>
    void CheckPlayerActivity() {
        foreach (Player p in PlayerManager.Players) {
            if (!p.Active && !p.Idle) {
                // This player was not yet activated, but is now showing activity.
                // Activate and assign it to a character, so the player can identify his own color and the basic game mechanics.

                // Find the first available character and attach it.
                Character character = System.Array.Find(characters, c => { return !c.hasPlayer; });
                p.Attach(character);
                p.Active = true;
            }
            if(p.Active && p.currentCharacter == null) {
                Character character = System.Array.Find(characters, c => { return !c.hasPlayer; });
                p.Attach(character);
            }
        }
    }

    private void GoToGameScene() {
        foreach(Player p in PlayerManager.Players) {
            p.Detach();
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameScene);
    }
}
