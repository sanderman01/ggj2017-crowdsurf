using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public int playerNumber;
    public Color color;
    public Character currentCharacter;

    Controls controls = new Controls();
    public Shader shader;

	// Use this for initialization
	void Start () {
        controls.SetJoystickID(playerNumber);
    }
	
	// Update is called once per frame
	void Update () {
        if (controls.ADown())
        {
            this.gameObject.GetComponent<SwitchingCharacter>().Switch(this);
        }
	}
}
