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
        int newCharacterindex = Audience.lastAssignedIndex + 1;
        if(Audience.characters.Count > newCharacterindex)
        {
            Character newCharacter = Audience.characters[newCharacterindex];
            p.currentCharacter = newCharacter;
            Audience.lastAssignedIndex = newCharacterindex;
        }
        
    }
}
