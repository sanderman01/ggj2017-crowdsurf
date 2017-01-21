using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour {

    public int joystickID;
    Controls controls = new Controls();

    void Start()
    {
        controls.SetJoystickID(joystickID);
    }
}
