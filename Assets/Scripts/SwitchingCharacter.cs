using UnityEngine;
using System.Collections.Generic;

public class SwitchingCharacter : MonoBehaviour {
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    //you move further right than all other players
    public void SwitchOld(Player p)
    {
        if (Audience.characters.Count > Audience.currentIndex)
        {
            Character oldCharacter = p.currentCharacter;
            if(oldCharacter != null)
            {
                oldCharacter.ResetColor();
                oldCharacter.hasPlayer = false;
            }

            Character newCharacter = Audience.characters[Audience.currentIndex];
            p.currentCharacter = newCharacter;
            p.currentCharacter.CharacterColor = p.color;
            Audience.currentIndex++;
            newCharacter.hasPlayer = true;
        }
        
    }

    public void Switch(Player p)
    {
        if (Audience.characters.Count > Audience.currentIndex)
        {
            Character oldCharacter = p.currentCharacter;
            int newIndex = 0;
            if(p.currentCharacter == null)
            {
                newIndex = Audience.currentIndex;
            }
            if(p.currentCharacter != null)
            {
                newIndex = p.currentCharacter.index+1;
            }    
            Character newCharacter = null;
            bool hasNewCharacter = false;
            while(hasNewCharacter == false && newIndex < Audience.characters.Count)
            {
                newCharacter = Audience.characters[newIndex];
                if(newCharacter.hasPlayer == false)
                {
                    hasNewCharacter = true;
                }
                if (hasNewCharacter == false)
                {
                    newIndex++;
                }
            }
            if(hasNewCharacter)
            {
                p.currentCharacter = newCharacter;
                p.currentCharacter.CharacterColor = p.color;
                Audience.currentIndex = newIndex;
                newCharacter.hasPlayer = true;
                if (oldCharacter != null)
                {
                    oldCharacter.ResetColor();
                    oldCharacter.hasPlayer = false;
                }
            }   
        }

    }

    public void SwitchBack(Player p)
    {
        if (Audience.characters.Count > Audience.currentIndex)
        {
            Character oldCharacter = p.currentCharacter;
            int newIndex = 0;
            if (p.currentCharacter != null)
            {
                newIndex = p.currentCharacter.index-1;
            }
            Character newCharacter = null;
            bool hasNewCharacter = false;
            while (hasNewCharacter == false && newIndex >= 0)
            {
                newCharacter = Audience.characters[newIndex];
                if (newCharacter.hasPlayer == false)
                {
                    hasNewCharacter = true;
                }
                else
                {
                    newIndex = newIndex-1;
                }
            }
            if (hasNewCharacter)
            {
                p.currentCharacter = newCharacter;
                p.currentCharacter.CharacterColor = p.color;
                p.currentCharacter.index = newIndex;
                newCharacter.hasPlayer = true;
                if (oldCharacter != null)
                {
                    oldCharacter.ResetColor();
                    oldCharacter.hasPlayer = false;
                }
            }
        }

    }
}
