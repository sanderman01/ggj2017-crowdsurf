using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	void Start () {
        StartGameRound();
    }

    private void StartGameRound()
    {
        // TODO
        // Make sure players exist and are active
        // Generate audience
        // Assign players to audience
        // Setup the ragdoll
        // Start the game!
        Debug.Log("startGameRound");
        SwitchingCharacter switching = GameObject.FindObjectOfType<SwitchingCharacter>();
        Player[] players = GameObject.FindObjectsOfType<Player>();
        foreach (Player p in players)
        {
            if (p.Active)
            {
                switching.Switch(p);
            }
        }
    }
}
