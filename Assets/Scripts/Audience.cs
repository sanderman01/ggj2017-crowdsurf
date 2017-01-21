using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audience : MonoBehaviour {
    public static List<Character> characters;
    public static int currentIndex;

    void Awake()
    {
        characters = new List<Character>();
    }
    // Use this for initialization
    void Start () {
        currentIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
