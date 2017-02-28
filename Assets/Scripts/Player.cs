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

    private bool idle = true;
    public bool Idle { get { return idle; } }

    private float idleTime = 0;
    public float IdleTime { get { return idleTime; } }

    public bool Ready { get { return controls.AHold(); } }

    [SerializeField]
    private int playerNumber;

    [SerializeField]
    private Color color;
    public Color Color {
        get { return color; }
        private set { color = value; }
    }

    public Sprite PlayerSymbol { get; private set; }

    public Character currentCharacter;

    Controls controls = new Controls();
    AudioSource audioSource;

    void Start()
    {
        SetPlayerNumber(playerNumber);
    }

    public void Init(int playerNumber, Color color, Sprite playerSymbol) {
        this.Color = color;
        this.SetPlayerNumber(playerNumber);
        this.PlayerSymbol = playerSymbol;
    }

    public void SetPlayerNumber(int playerNumber)
    {
        this.playerNumber = playerNumber;
        controls.SetJoystickID(playerNumber);
    }
	
	// Update is called once per frame
	void Update () {
        CheckIdle();

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

    private void CheckIdle()
    {
        const float axisMargin = 0.5f;
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
            controls.RightAnalogDown() ||
            (Mathf.Abs(controls.GetLeftAxisX()) > axisMargin) ||
            (Mathf.Abs(controls.GetRightAxisY()) > axisMargin) ||
            (Mathf.Abs(controls.GetLeftAxisX()) > axisMargin) ||
            (Mathf.Abs(controls.GetRightAxisY()) > axisMargin) ||
            (Mathf.Abs(controls.GetTrigger()) > axisMargin) );

        if (idle) {
            idleTime += Time.unscaledDeltaTime;
        } else {
            idleTime = 0;
        }
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
        currentCharacter.PlayerSymbol = PlayerSymbol;
    }

    /// <summary>
    /// Detach this player from a character.
    /// </summary>
    public void Detach() {
        if(currentCharacter != null) {
            currentCharacter.hasPlayer = false;
            currentCharacter.ResetColor();
            currentCharacter.colorRenderer.enabled = false;
            currentCharacter.PlayerSymbol = null;
        }
        currentCharacter = null;
    }
}
