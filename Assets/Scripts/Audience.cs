using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audience : MonoBehaviour {
    [SerializeField]
    private List<Character> manualCharacters;

    public static List<Character> characters;

    void Awake()
    {
        characters = new List<Character>();
    }

    void Start() {
        // This is such a stupid hack :(
        if(manualCharacters != null && manualCharacters.Count != 0) {
            characters = manualCharacters;
        }
    }
}
