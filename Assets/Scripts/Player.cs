using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private bool active = false;
    public bool Active {
        get { return active; }
        set { active = value; }
    }

    private bool idle;
    public bool Idle { get { return idle; } }

    public bool Ready { get { return controls.AHold(); } }

    [SerializeField]
    private int playerNumber;

    [SerializeField]
    private Color color;
    public Color Color {
        get { return color; }
        private set { color = value; }
    }

    public Character currentCharacter;

    Controls controls = new Controls();
    AudioSource audioSource;

    void Start()
    {
        SetPlayerNumber(playerNumber);
        idle = true;
    }

    public void Init(int playerNumber, Color color) {
        this.Color = color;
        this.SetPlayerNumber(playerNumber);
    }

    public void SetPlayerNumber(int playerNumber)
    {
        this.playerNumber = playerNumber;
        controls.SetJoystickID(playerNumber);
    }
	
	// Update is called once per frame
	void Update () {
        if (idle)
        {
            checkIdle();
        }

        if (currentCharacter != null) {
            Vector2 leftStick = new Vector2(controls.GetLeftAxisX(), controls.GetLeftAxisY());
            Vector2 rightStick = new Vector2(controls.GetRightAxisX(), controls.GetRightAxisY());

            currentCharacter.moveLeftArm(leftStick);
            currentCharacter.moveRightArm(rightStick);

            if (controls.ADown() || Mathf.Abs(controls.GetTrigger()) > 0.5f) {
                currentCharacter.jump();
            }

            if (controls.RBDown()) {
                SwitchingCharacter switching = FindObjectOfType<SwitchingCharacter>();
                if(switching != null)
                    switching.SwitchForward(this);
            }
            if (controls.LBDown()) {
                SwitchingCharacter switching = FindObjectOfType<SwitchingCharacter>();
                if(switching != null)
                    switching.SwitchBackward(this);
            }
        }
    }

    private void checkIdle()
    {
        idle =
         !(controls.ADown() ||
            controls.BDown() ||
            controls.XDown() ||
            controls.YDown() ||
            controls.LBDown() ||
            controls.RBDown() ||
            controls.SelectDown() ||
            controls.StartDown() ||
            controls.LeftAnalogDown() ||
            controls.RightAnalogDown());
    }

    /// <summary>
    /// Attach this player to a character.
    /// </summary>
    public void Attach(Character c) {
        Debug.Log("Assigned player: " + playerNumber);
        if (currentCharacter != null) {
            Detach();
        } else
        {
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
                int clipID = UnityEngine.Random.Range(1, 4);
                audioSource.clip = Resources.Load("menuSelect" + clipID) as AudioClip;
                audioSource.loop = false;
                audioSource.Play();
            }
        }
        currentCharacter = c;
        currentCharacter.hasPlayer = true;
        currentCharacter.CharacterColor = Color;
        currentCharacter.colorRenderer.enabled = true;
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
