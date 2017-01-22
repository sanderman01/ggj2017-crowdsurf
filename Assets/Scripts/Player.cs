using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public bool Active {
        get { return active; }
        set { active = value; }
    }
    private bool active = true;
    public bool Idle { get { return idle; } }
    private bool idle; // TODO Detect Activity or Idling by checking current controller axis and button states
    public int playerNumber;
    public Color color;
    public Character currentCharacter;

    string leftAxisX;
    string leftAxisY;
    string rightAxisX;
    string rightAxisY;
    //string jumpButton = string.Format("Jump{0}", playerNumber);
    string jumpButton;
    string switchButton;
    Controls controls = new Controls();

    void Start()
    {
        SetPlayerNumber(playerNumber);
    }

    public void SetPlayerNumber(int playerNumber)
    {
        this.playerNumber = playerNumber;
        controls.SetJoystickID(playerNumber);

        leftAxisX = string.Format("Joystick{0}LeftX", playerNumber);
        leftAxisY = string.Format("Joystick{0}LeftY", playerNumber);
        rightAxisX = string.Format("Joystick{0}RightX", playerNumber);
        rightAxisY = string.Format("Joystick{0}RightY", playerNumber);
        //string jumpButton = string.Format("Jump{0}", playerNumber);
        jumpButton = "Jump";
        //string switchButton = string.Format("Switch{0}", playerNumber);
        switchButton = "Fire1";
    }
	
	// Update is called once per frame
	void Update () {
        if(currentCharacter != null) {
            Vector2 leftStick = new Vector2(Input.GetAxis(leftAxisX), Input.GetAxis(leftAxisY));
            Vector2 rightStick = new Vector2(Input.GetAxis(rightAxisX), Input.GetAxis(rightAxisY));

            currentCharacter.moveLeftArm(leftStick);
            currentCharacter.moveRightArm(rightStick);

            if (controls.ADown() || Mathf.Abs(controls.GetTrigger()) > 0.5f) {
                currentCharacter.jump();
            }

            if (controls.RBDown()) {
                SwitchingCharacter switching = FindObjectOfType<SwitchingCharacter>();
                switching.Switch(this);
            }
            if (controls.LBDown()) {
                SwitchingCharacter switching = FindObjectOfType<SwitchingCharacter>();
                switching.SwitchBack(this);
            }
        }
    }

    /// <summary>
    /// Attach this player to a character.
    /// </summary>
    public void Attach(Character c) {
        if (currentCharacter != null) {
            Detach();
        }
        c.hasPlayer = true;
        c.CharacterColor = color;
        currentCharacter = c;
        c.colorRenderer.enabled = true;
    }

    /// <summary>
    /// Detach this player from a character.
    /// </summary>
    public void Detach() {
        if(currentCharacter != null) {
            currentCharacter.hasPlayer = false;
            currentCharacter.ResetColor();
            currentCharacter.colorRenderer.enabled = false;
        }
        currentCharacter = null;
    }
}
