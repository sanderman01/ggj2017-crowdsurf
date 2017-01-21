using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public bool active;
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

    void Start()
    {
        SetPlayerNumber(1);
    }

    public void SetPlayerNumber(int playerNumber)
    {
        this.playerNumber = playerNumber;

        leftAxisX = string.Format("Joystick{0}AnalogLeftX", playerNumber);
        leftAxisY = string.Format("Joystick{0}AnalogLeftY", playerNumber);
        rightAxisX = string.Format("Joystick{0}AnalogRightX", playerNumber);
        rightAxisY = string.Format("Joystick{0}AnalogRightY", playerNumber);
        //string jumpButton = string.Format("Jump{0}", playerNumber);
        jumpButton = "Jump";
        //string switchButton = string.Format("Switch{0}", playerNumber);
        switchButton = "Fire1";
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 leftStick = new Vector2(Input.GetAxis(leftAxisX), Input.GetAxis(leftAxisY));
        Vector2 rightStick = new Vector2(Input.GetAxis(rightAxisX), Input.GetAxis(rightAxisY));
        
        currentCharacter.moveLeftArm(leftStick);
        currentCharacter.moveRightArm(rightStick);

        if (Input.GetButtonDown(jumpButton))
        {
            currentCharacter.jump();
        }

        if (Input.GetButton(switchButton))
        {
            SwitchingCharacter switching = GameObject.FindObjectOfType<SwitchingCharacter>();
            switching.Switch(this);
        }
    }
}
