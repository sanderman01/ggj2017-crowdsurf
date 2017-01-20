using UnityEngine;
using System.Collections.Generic;

public class SwitchingCharacter : MonoBehaviour {
    int playercount;
    List<Character> characters = new List<Character>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Switch(Player p)
    {
        int newCharacterindex = p.currentCharacter.index + playercount;
        Character newCharacter = characters[newCharacterindex];
        p.currentCharacter = newCharacter;    
    }
}
