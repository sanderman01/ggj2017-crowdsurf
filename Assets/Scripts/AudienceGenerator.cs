using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceGenerator : MonoBehaviour {
    public float distanceBetweenCharacters;
    public Character characterPrefab;
    public string characterName;
    public int AmountOfCharactersToCreateAtStart = 4;
    public List<CharacterSkin> skins;
    public int count;

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
        count++;
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
        if(count % 2 == 0)
        {
            AddSkin(newCharacter);
        }
        
        newCharacter.gameObject.name = string.Concat(characterName, Audience.characters.Count);
        newCharacter.index = Audience.characters.Count-1;
    }
    public void AddSkin(Character c)
    {
        var shoulderRight = c.transform.Find("Shoulder_right/Arm/sprite");
        var shoulderLeft = c.transform.Find("Shoulder_left/Arm/sprite");
        var legs = c.transform.Find("Body/legs/sprite");
        var torso = c.transform.Find("Body/torso/sprite");
        var head = c.transform.Find("Body/Head/sprite");
        var sp1 = head.GetComponent<SpriteRenderer>();
        var sp2 = torso.GetComponent<SpriteRenderer>();
        var sp3 = legs.GetComponent<SpriteRenderer>();
        var sp4 = shoulderRight.GetComponent<SpriteRenderer>();
        var sp5 = shoulderLeft.GetComponent<SpriteRenderer>();
        sp1.sprite = skins[0].head;
        sp2.sprite = skins[0].Body;
        sp3.sprite = skins[0].Legs;
        sp4.sprite = skins[0].Arm;
        sp5.sprite = skins[0].Arm;
    }
}
