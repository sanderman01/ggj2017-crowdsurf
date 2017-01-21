using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int index;
    public bool hasPlayer;

    [SerializeField]
    private Transform rightArmPivot;
    [SerializeField]
    private Transform leftArmPivot;
    [SerializeField]
    private Vector2 jumpVelocity = new Vector2(0, 1.2f);
    [SerializeField]
    private float jumpDuration = 0.3f;

    private bool grounded = true;

    const float axisMargin = 0.5f;

    private Color characterColor;
    public Color CharacterColor
    {
        // TODO Change the color of the character to the player color by modifying the material color.
        get { return characterColor; }
        set {
            characterColor = value;
            Renderer render = GetComponentsInChildren<Renderer>()[0];
            render.material.color = value;
        }
    }

    public void ResetColor()
    {
        // TODO set some default color
        CharacterColor = Color.white;
    }

    void Update()
    {
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

    public void moveRightArm(Vector2 rightArmInput)
    {
        if (rightArmInput.magnitude > axisMargin)
        {
            rightArmInput = rightArmInput.normalized;
            Quaternion currentRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.FromToRotation(Vector2.right, rightArmInput);
            float rotationMovementAngle = targetRotation.eulerAngles.z - currentRotation.eulerAngles.z;
            rightArmPivot.GetComponent<Rigidbody2D>().MoveRotation(rotationMovementAngle);

            //rightArmPivot.transform.rotation = targetRotation;
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
}