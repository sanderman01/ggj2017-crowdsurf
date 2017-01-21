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
        if (Audience.characters.Count > Audience.currentIndex)
        {
            Character oldCharacter = p.currentCharacter;
            if(oldCharacter != null)
            {
                oldCharacter.ResetColor();
            }

            Character newCharacter = Audience.characters[Audience.currentIndex];
            p.currentCharacter = newCharacter;
            p.currentCharacter.CharacterColor = p.color;
            Audience.currentIndex++;
        }
        
    }
}
