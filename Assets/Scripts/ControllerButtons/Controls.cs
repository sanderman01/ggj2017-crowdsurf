using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Controls {

    [Range(1, 4)]
    int joystickID;

    public void SetJoystickID(int id)
    {
        joystickID = id;
    }

    public float GetLeftAxisX()
    {
        return Input.GetAxis("Joystick" + (joystickID) + "LeftX");
    }

    public float GetLeftAxisY()
    {
        return Input.GetAxis("Joystick" + (joystickID) + "LeftY");
    }

    public float GetRightAxisX()
    {
        return Input.GetAxis("Joystick" + (joystickID) + "RightX");
    }

    public float GetRightAxisY()
    {
        return Input.GetAxis("Joystick" + (joystickID) + "RightY");
    }

    public float GetTrigger()
    {
        return Input.GetAxis("Joystick" + (joystickID) + "Trigger");
    }

    public bool ADown()
    {
        switch (joystickID)
        {
            case 1:
                return Input.GetKeyDown(KeyCode.Joystick1Button0);
                 
            case 2:
                return Input.GetKeyDown(KeyCode.Joystick2Button0);
                 
            case 3:
                return Input.GetKeyDown(KeyCode.Joystick3Button0);
                 
            case 4:
                return Input.GetKeyDown(KeyCode.Joystick4Button0);
                 
        }
        return false;
    }

    public bool AHold()
    {
        switch (joystickID)
        {
            case 1:
                return Input.GetKey(KeyCode.Joystick1Button0);
                 
            case 2:
                return Input.GetKey(KeyCode.Joystick2Button0);
                 
            case 3:
                return Input.GetKey(KeyCode.Joystick3Button0);
                 
            case 4:
                return Input.GetKey(KeyCode.Joystick4Button0);
                 
        }
        return false;
    }

    public bool AUp()
    {
        switch (joystickID)
        {
            case 1:
                return Input.GetKeyUp(KeyCode.Joystick1Button1);
                 
            case 2:
                return Input.GetKeyUp(KeyCode.Joystick2Button1);
                 
            case 3:
                return Input.GetKeyUp(KeyCode.Joystick3Button1);
                 
            case 4:
                return Input.GetKeyUp(KeyCode.Joystick4Button1);
                 
        }
        return false;
    }

    public bool BDown()
    {
        switch (joystickID)
        {
            case 1:
                return Input.GetKeyDown(KeyCode.Joystick1Button1);
                 
            case 2:
                return Input.GetKeyDown(KeyCode.Joystick2Button1);
                 
            case 3:
                return Input.GetKeyDown(KeyCode.Joystick3Button1);
                 
            case 4:
                return Input.GetKeyDown(KeyCode.Joystick4Button1);
                 
        }
        return false;
    }

    public bool BHold()
    {
        switch (joystickID)
        {
            case 1:
                return Input.GetKey(KeyCode.Joystick1Button1);
                 
            case 2:
                return Input.GetKey(KeyCode.Joystick2Button1);
                 
            case 3:
                return Input.GetKey(KeyCode.Joystick3Button1);
                 
            case 4:
                return Input.GetKey(KeyCode.Joystick4Button1);
                 
        }
        return false;
    }

    public bool BUp()
    {
        switch (joystickID)
        {
            case 1:
                return Input.GetKeyUp(KeyCode.Joystick1Button1);
                 
            case 2:
                return Input.GetKeyUp(KeyCode.Joystick2Button1);
                 
            case 3:
                return Input.GetKeyUp(KeyCode.Joystick3Button1);
                 
            case 4:
                return Input.GetKeyUp(KeyCode.Joystick4Button1);
                 
        }
        return false;
    }

    public bool XDown()
    {
        switch (joystickID)
        {
            case 1:
                return Input.GetKeyDown(KeyCode.Joystick1Button2);
                 
            case 2:
                return Input.GetKeyDown(KeyCode.Joystick2Button2);
                 
            case 3:
                return Input.GetKeyDown(KeyCode.Joystick3Button2);
                 
            case 4:
                return Input.GetKeyDown(KeyCode.Joystick4Button2);
                 
        }
        return false;
    }

    public bool XHold()
    {
        switch (joystickID)
        {
            case 1:
                return Input.GetKey(KeyCode.Joystick1Button2);
                 
            case 2:
                return Input.GetKey(KeyCode.Joystick2Button2);
                 
            case 3:
                return Input.GetKey(KeyCode.Joystick3Button2);
                 
            case 4:
                return Input.GetKey(KeyCode.Joystick4Button2);
                 
        }
        return false;
    }

    public bool XUp()
    {
        switch (joystickID)
        {
            case 1:
                return Input.GetKeyUp(KeyCode.Joystick1Button2);
                 
            case 2:
                return Input.GetKeyUp(KeyCode.Joystick2Button2);
                 
            case 3:
                return Input.GetKeyUp(KeyCode.Joystick3Button2);
                 
            case 4:
                return Input.GetKeyUp(KeyCode.Joystick4Button2);
                 
        }
        return false;
    }

    public bool YDown()
    {
        switch (joystickID)
        {
            case 1:
                return Input.GetKeyDown(KeyCode.Joystick1Button3);
                 
            case 2:
                return Input.GetKeyDown(KeyCode.Joystick2Button3);
                 
            case 3:
                return Input.GetKeyDown(KeyCode.Joystick3Button3);
                 
            case 4:
                return Input.GetKeyDown(KeyCode.Joystick4Button3);
                 
        }
        return false;
    }

    public bool YHold()
    {
        switch (joystickID)
        {
            case 1:
                return Input.GetKey(KeyCode.Joystick1Button3);
                 
            case 2:
                return Input.GetKey(KeyCode.Joystick2Button3);
                 
            case 3:
                return Input.GetKey(KeyCode.Joystick3Button3);
                 
            case 4:
                return Input.GetKey(KeyCode.Joystick4Button3);
                 
        }
        return false;
    }

    public bool YUp()
    {
        switch (joystickID)
        {
            case 1:
                return Input.GetKeyUp(KeyCode.Joystick1Button3);
                 
            case 2:
                return Input.GetKeyUp(KeyCode.Joystick2Button3);
                 
            case 3:
                return Input.GetKeyUp(KeyCode.Joystick3Button3);
                 
            case 4:
                return Input.GetKeyUp(KeyCode.Joystick4Button3);
                 
        }
        return false;
    }

    public bool LBDown()
    {
        switch (joystickID)
        {
            case 1:
                return Input.GetKeyDown(KeyCode.Joystick1Button4);
                 
            case 2:
                return Input.GetKeyDown(KeyCode.Joystick2Button4);
                 
            case 3:
                return Input.GetKeyDown(KeyCode.Joystick3Button4);
                 
            case 4:
                return Input.GetKeyDown(KeyCode.Joystick4Button4);
                 
        }
        return false;
    }

    public bool LBHold()
    {
        switch (joystickID)
        {
            case 1:
                return Input.GetKey(KeyCode.Joystick1Button4);
                 
            case 2:
                return Input.GetKey(KeyCode.Joystick2Button4);
                 
            case 3:
                return Input.GetKey(KeyCode.Joystick3Button4);
                 
            case 4:
                return Input.GetKey(KeyCode.Joystick4Button4);
                 
        }
        return false;
    }

    public bool LBUp()
    {
        switch (joystickID)
        {
            case 1:
                return Input.GetKeyUp(KeyCode.Joystick1Button4);
                 
            case 2:
                return Input.GetKeyUp(KeyCode.Joystick2Button4);
                 
            case 3:
                return Input.GetKeyUp(KeyCode.Joystick3Button4);
                 
            case 4:
                return Input.GetKeyUp(KeyCode.Joystick4Button4);
                 
        }
        return false;
    }

    public bool RBDown()
    {
        switch (joystickID)
        {
            case 1:
                return Input.GetKeyDown(KeyCode.Joystick1Button5);
                 
            case 2:
                return Input.GetKeyDown(KeyCode.Joystick2Button5);
                 
            case 3:
                return Input.GetKeyDown(KeyCode.Joystick3Button5);
                 
            case 4:
                return Input.GetKeyDown(KeyCode.Joystick4Button5);
                 
        }
        return false;
    }

    public bool RBHold()
    {
        switch (joystickID)
        {
            case 1:
                return Input.GetKey(KeyCode.Joystick1Button5);
                 
            case 2:
                return Input.GetKey(KeyCode.Joystick2Button5);
                 
            case 3:
                return Input.GetKey(KeyCode.Joystick3Button5);
                 
            case 4:
                return Input.GetKey(KeyCode.Joystick4Button5);
                 
        }
        return false;
    }

    public bool RBUp()
    {
        switch (joystickID)
        {
            case 1:
                return Input.GetKeyUp(KeyCode.Joystick1Button5);
                 
            case 2:
                return Input.GetKeyUp(KeyCode.Joystick2Button5);
                 
            case 3:
                return Input.GetKeyUp(KeyCode.Joystick3Button5);
                 
            case 4:
                return Input.GetKeyUp(KeyCode.Joystick4Button5);
                 
        }
        return false;
    }

    public bool SelectDown()
    {
        switch (joystickID)
        {
            case 1:
                return Input.GetKeyDown(KeyCode.Joystick1Button6);
                 
            case 2:
                return Input.GetKeyDown(KeyCode.Joystick2Button6);
                 
            case 3:
                return Input.GetKeyDown(KeyCode.Joystick3Button6);
                 
            case 4:
                return Input.GetKeyDown(KeyCode.Joystick4Button6);
                 
        }
        return false;
    }

    public bool SelectHold()
    {
        switch (joystickID)
        {
            case 1:
                return Input.GetKey(KeyCode.Joystick1Button6);
                 
            case 2:
                return Input.GetKey(KeyCode.Joystick2Button6);
                 
            case 3:
                return Input.GetKey(KeyCode.Joystick3Button6);
                 
            case 4:
                return Input.GetKey(KeyCode.Joystick4Button6);
                 
        }
        return false;
    }

    public bool SelectUp()
    {
        switch (joystickID)
        {
            case 1:
                return Input.GetKeyUp(KeyCode.Joystick1Button6);
                 
            case 2:
                return Input.GetKeyUp(KeyCode.Joystick2Button6);
                 
            case 3:
                return Input.GetKeyUp(KeyCode.Joystick3Button6);
                 
            case 4:
                return Input.GetKeyUp(KeyCode.Joystick4Button6);
                 
        }
        return false;
    }

    public bool StartDown()
    {
        switch (joystickID)
        {
            case 1:
                return Input.GetKeyDown(KeyCode.Joystick1Button7);
                 
            case 2:
                return Input.GetKeyDown(KeyCode.Joystick2Button7);
                 
            case 3:
                return Input.GetKeyDown(KeyCode.Joystick3Button7);
                 
            case 4:
                return Input.GetKeyDown(KeyCode.Joystick4Button7);
                 
        }
        return false;
    }

    public bool StartHold()
    {
        switch (joystickID)
        {
            case 1:
                return Input.GetKey(KeyCode.Joystick1Button7);
                 
            case 2:
                return Input.GetKey(KeyCode.Joystick2Button7);
                 
            case 3:
                return Input.GetKey(KeyCode.Joystick3Button7);
                 
            case 4:
                return Input.GetKey(KeyCode.Joystick4Button7);
                 
        }
        return false;
    }

    public bool StartUp()
    {
        switch (joystickID)
        {
            case 1:
                return Input.GetKeyUp(KeyCode.Joystick1Button7);
                 
            case 2:
                return Input.GetKeyUp(KeyCode.Joystick2Button7);
                 
            case 3:
                return Input.GetKeyUp(KeyCode.Joystick3Button7);
                 
            case 4:
                return Input.GetKeyUp(KeyCode.Joystick4Button7);
                 
        }
        return false;
    }

    public bool LeftAnalogDown()
    {
        switch (joystickID)
        {
            case 1:
                return Input.GetKeyDown(KeyCode.Joystick1Button8);
                 
            case 2:
                return Input.GetKeyDown(KeyCode.Joystick2Button8);
                 
            case 3:
                return Input.GetKeyDown(KeyCode.Joystick3Button8);
                 
            case 4:
                return Input.GetKeyDown(KeyCode.Joystick4Button8);
                 
        }
        return false;
    }

    public bool LeftAnalogHold()
    {
        switch (joystickID)
        {
            case 1:
                return Input.GetKey(KeyCode.Joystick1Button8);
                 
            case 2:
                return Input.GetKey(KeyCode.Joystick2Button8);
                 
            case 3:
                return Input.GetKey(KeyCode.Joystick3Button8);
                 
            case 4:
                return Input.GetKey(KeyCode.Joystick4Button8);
                 
        }
        return false;
    }

    public bool LeftAnalogUp()
    {
        switch (joystickID)
        {
            case 1:
                return Input.GetKeyUp(KeyCode.Joystick1Button8);
                 
            case 2:
                return Input.GetKeyUp(KeyCode.Joystick2Button8);
                 
            case 3:
                return Input.GetKeyUp(KeyCode.Joystick3Button8);
                 
            case 4:
                return Input.GetKeyUp(KeyCode.Joystick4Button8);
                 
        }
        return false;
    }

    public bool RightAnalogDown()
    {
        switch (joystickID)
        {
            case 1:
                return Input.GetKeyDown(KeyCode.Joystick1Button9);
                 
            case 2:
                return Input.GetKeyDown(KeyCode.Joystick2Button9);
                 
            case 3:
                return Input.GetKeyDown(KeyCode.Joystick3Button9);
                 
            case 4:
                return Input.GetKeyDown(KeyCode.Joystick4Button9);
                 
        }
        return false;
    }

    public bool RightAnalogHold()
    {
        switch (joystickID)
        {
            case 1:
                return Input.GetKey(KeyCode.Joystick1Button9);
                 
            case 2:
                return Input.GetKey(KeyCode.Joystick2Button9);
                 
            case 3:
                return Input.GetKey(KeyCode.Joystick3Button9);
                 
            case 4:
                return Input.GetKey(KeyCode.Joystick4Button9);
                 
        }
        return false;
    }

    public bool RightAnalogUp()
    {
        switch (joystickID)
        {
            case 1:
                return Input.GetKeyUp(KeyCode.Joystick1Button9);
                 
            case 2:
                return Input.GetKeyUp(KeyCode.Joystick2Button9);
                 
            case 3:
                return Input.GetKeyUp(KeyCode.Joystick3Button9);
                 
            case 4:
                return Input.GetKeyUp(KeyCode.Joystick4Button9);
                
        }
        return false;
    }
}
