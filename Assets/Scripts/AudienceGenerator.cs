using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceGenerator : MonoBehaviour {
    public float distanceBetweenCharacters;
    public Character characterPrefab;
    public string characterName;
    public int AmountOfCharactersToCreateAtStart = 4;

	// Use this for initialization
	void Start () {

        Debug.Log("generate audience");
        for (int i = 0; i < AmountOfCharactersToCreateAtStart; i++)
        {
            Debug.Log("create character" + i);
            GenerateNewCharacter();
        }
    }
	
	// Update is called once per frame
	void Update () {
        int lastCharacter = Audience.characters.Count - 1;
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(Audience.characters[lastCharacter].transform.position);
        bool onScreen = screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y < 1;
        if (onScreen)
        {
            GenerateNewCharacter();
        }
    }

    public void GenerateNewCharacter()
    {
        Vector2 newLocation;
        if(Audience.characters.Count == 0)
        {
            newLocation = GameSettings.FirstCharacterLocation;
        }
        else
        {
            newLocation = Audience.characters[Audience.characters.Count-1].transform.position + new Vector3(distanceBetweenCharacters, 0);
        }
        Character newCharacter = Instantiate(characterPrefab, new Vector3(newLocation.x,newLocation.y),Quaternion.identity);
        Audience.characters.Add(newCharacter);
        newCharacter.gameObject.name = string.Concat(characterName, Audience.characters.Count);
        newCharacter.index = Audience.characters.Count;
    }
}
