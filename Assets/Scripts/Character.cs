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

    [SerializeField]
    private float floorY = 0;

    private bool grounded = true;

    const float axisMargin = 0.5f;

    [SerializeField]
    private bool jumpOnBeat = true;

    [SerializeField]
    public Renderer colorRenderer;

    new private Rigidbody2D rigidbody;
    private Rigidbody2D leftArmRigidbody;
    private Rigidbody2D rightArmRigidbody;

    [SerializeField]
    private GameObject readyObj;

    public void SetReadyState(bool value) {
        readyObj.SetActive(value);
    }

    private Color characterColor;
    public Color CharacterColor
    {
        // TODO Change the color of the character to the player color by modifying the material color.
        get { return characterColor; }
        set {
            characterColor = value;
            const float a = 0.25f;
            Color indicatorColor = characterColor;
            indicatorColor.a = a;
            const string propName = "_TintColor";
            colorRenderer.material.SetColor(propName, indicatorColor);
        }
    }

    public void ResetColor()
    {
        // TODO set some default color
        CharacterColor = Color.white;
    }

    void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        leftArmRigidbody = leftArmPivot.GetComponent<Rigidbody2D>();
        rightArmRigidbody = rightArmPivot.GetComponent<Rigidbody2D>();
    }

    void Start() {
        leftArmPivot.transform.rotation = Quaternion.Euler(0, 0, Random.value * 360);
        rightArmPivot.transform.rotation = Quaternion.Euler(0, 0, Random.value * 360);
        colorRenderer.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-10f, 10f));
        colorRenderer.enabled = hasPlayer;
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

    void Update() {
        // Land on the floor
        if (transform.position.y < floorY) {
            transform.position = new Vector3(transform.position.x, floorY, transform.position.z);
            rigidbody.velocity = Vector2.zero;
            grounded = true;
        }
    }

    void FixedUpdate()
    {
        // Jumping on the beat
        if (jumpOnBeat && hasPlayer==false) {
            Vector3 p = rigidbody.position;
            p.y += Mathf.Sin((Time.fixedTime + p.x * 0.7f) * Mathf.PI * 4) * 0.01f;
            p.y += Mathf.Sin((Time.fixedTime + p.x * 0.15f) * Mathf.PI * 4) * 0.03f;
            rigidbody.MovePosition(p);
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
            rightArmRigidbody.MoveRotation(rotationMovementAngle);
        }
    }

    public void moveLeftArm(Vector2 leftArmInput)
    {
        if (leftArmInput.magnitude > axisMargin)
        {
            leftArmInput = leftArmInput.normalized;
            Quaternion currentRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.FromToRotation(Vector2.right, leftArmInput);
            float rotationMovementAngle = targetRotation.eulerAngles.z - currentRotation.eulerAngles.z;
            leftArmRigidbody.MoveRotation(rotationMovementAngle);
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
        rigidbody.velocity = jumpVelocity;
        yield return new WaitForSeconds(jumpDuration);
        rigidbody.velocity = -jumpVelocity;
    }
}