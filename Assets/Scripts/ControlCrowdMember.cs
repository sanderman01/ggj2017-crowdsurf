﻿using System.Collections;
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
    private Vector2 jumpVelocity;
    [SerializeField]
    private float jumpDuration;

    private bool grounded = true;

    const float axisMargin = 0.5f;

    public void moveRightArm(Vector2 rightArmInput)
    {
        if(rightArmInput.magnitude > axisMargin)
        {
            rightArmInput = rightArmInput.normalized;
            Quaternion targetRotation = Quaternion.FromToRotation(Vector2.right, rightArmInput);
            rightArmPivot.transform.rotation = targetRotation;
        }
    }

    public void moveLeftArm(Vector2 leftArmInput)
    {
        if (leftArmInput.magnitude > axisMargin)
        {
            leftArmInput = leftArmInput.normalized;
            Quaternion targetRotation = Quaternion.FromToRotation(Vector2.right, leftArmInput);
            leftArmPivot.transform.rotation = targetRotation;
        }
    }

    public void jump()
    {
        if (grounded)
        {
            grounded = false;
            StartCoroutine(jumpRoutine());
        }
    }

    private IEnumerator jumpRoutine()
    {

        GetComponent<Rigidbody2D>().velocity = jumpVelocity;
        yield return new WaitForSeconds(jumpDuration);

        GetComponent<Rigidbody2D>().velocity = -jumpVelocity;
    }

    //temporary: actual input should be done by player
    void Update()
    {
        moveRightArm(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxis("Vertical")));
        moveLeftArm(new Vector2(-Input.GetAxisRaw("Joystick1AnalogRightX"), Input.GetAxis("Joystick1AnalogRightY")));
        
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("jump");
            jump();
        }
    }

    void FixedUpdate()
    {
        if (transform.position.y < 0)
        {
            Debug.Log("landed");
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);

            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            grounded = true;
        }
    }
}
