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

    [SerializeField]
    private float armLength = 0.6f;

    private bool grounded = true;

    const float axisMargin = 0.5f;

    private float FloorY {
        get { return 0; }
    }

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

    [ContextMenu("SetArmLength")]
    private void SetArmLength() {
        // Set arm length
        Transform leftArm = leftArmPivot.GetChild(0);
        Transform rightArm = rightArmPivot.GetChild(0);
        Vector3 armScale = leftArm.transform.localScale;
        armScale.x = armLength;
        Vector3 armPosition = leftArm.localPosition;
        armPosition.x = armLength * 0.5f;

        leftArm.localScale = rightArm.localScale = armScale;
        leftArm.localPosition = rightArm.localPosition = armPosition;
    }

    void FixedUpdate()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        // Jumping on the beat
        Vector3 p = rigidbody.position;
        p.y += Mathf.Sin((Time.fixedTime + p.x * 0.7f) * Mathf.PI * 4) * 0.01f;
        p.y += Mathf.Sin((Time.fixedTime + p.x * 0.15f) * Mathf.PI * 4) * 0.03f;
        rigidbody.position = p;

        // Land on the floor
        if (transform.position.y < FloorY)
        {
            Debug.Log("landed");
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            rigidbody.velocity = Vector2.zero;
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