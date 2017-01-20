using UnityEngine;
using System.Collections.Generic;

public class SwitchingCharacter : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Switch(Player p)
    {
        int newCharacterindex = p.currentCharacter.index + GameSettings.playercount;
        Character newCharacter = Audience.characters[newCharacterindex];
        p.currentCharacter = newCharacter;    
    }
}
