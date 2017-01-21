using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCrowdMember : MonoBehaviour {

    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private Transform rightArmPivot;
    [SerializeField]
    private Transform leftArmPivot;
    [SerializeField]
    private Vector2 jumpHeight;

    private bool grounded = true;

    public void moveRightArm(float inputRightArm)
    {
        rightArmPivot.Rotate(0, 0, -inputRightArm * rotateSpeed);
    }

    public void moveLeftArm(float inputLeftArm)
    {
        leftArmPivot.Rotate(0, 0, -inputLeftArm * rotateSpeed);
    }

    public void jump()
    {
        if (!grounded)
        {
            return;
        }
        grounded = false;
        GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
    }

    //temporary: actual input should be done by player
    void Update()
    {
        moveRightArm(Input.GetAxisRaw("Horizontal"));
        moveLeftArm(Input.GetAxisRaw("Vertical"));

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump");
            jump();
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
