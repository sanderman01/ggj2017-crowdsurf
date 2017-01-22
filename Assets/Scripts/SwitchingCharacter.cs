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
    //public void SwitchOld(Player p)
    //{
    //    if (Audience.characters.Count > Audience.currentIndex)
    //    {
    //        Character oldCharacter = p.currentCharacter;
    //        if(oldCharacter != null)
    //        {
    //            oldCharacter.ResetColor();
    //            oldCharacter.hasPlayer = false;
    //        }

    //        Character newCharacter = Audience.characters[Audience.currentIndex];
    //        p.currentCharacter = newCharacter;
    //        p.currentCharacter.CharacterColor = p.color;
    //        Audience.currentIndex++;
    //        newCharacter.hasPlayer = true;
    //    }

    //}

    public void SwitchForward(Player player)
    {
        int index;
        Character currentChar = player.currentCharacter;

        if(currentChar != null)
        {
            index = currentChar.index;
        }
        else
        {
            index = 0;
        }

        int newIndex = FindForward(index);
        if(newIndex != -1)
        {
            Character newCharacter = Audience.characters[newIndex];
            player.Attach(newCharacter);
        }
        
    }

    public void SwitchBackward(Player player)
    {
        int index;
        Character currentChar = player.currentCharacter;

        if (currentChar != null)
        {
            index = currentChar.index;
        }
        else
        {
            index = 0;
        }

        int newIndex = FindBackward(index);
        if (newIndex != -1)
        {
            Character newCharacter = Audience.characters[newIndex];
            player.Attach(newCharacter);
        }
    }

    public int FindForward(int currentIndex)
    {
        // Do a search and return the first available character index
        // If none found, then -1
        for(int i = currentIndex; i < Audience.characters.Count; ++i)
        {
            if (!Audience.characters[i].hasPlayer)
                return i;
        }
        return -1;
    }
    public int FindBackward(int currentIndex)
    {
        // Do a search and return the first available character index
        // If none found, then -1
        for (int i = currentIndex; i >= 0; --i)
        {
            if (!Audience.characters[i].hasPlayer)
                return i;
        }
        return -1;
    }
}
