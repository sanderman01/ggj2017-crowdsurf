using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This camera needs to satisfy the following constraints with smooth movement:
/// Keep all player controlled characters in view.
/// Keep the surfer near the center of the screen.
/// This was designed for an orthographic camera.
/// </summary>
public class SurfCamera : MonoBehaviour {

    [SerializeField]
    private float period = 0.4f;

    [SerializeField]
    private float minCameraSize = 1.5f;

    [SerializeField]
    private float floorY = -0.1f;

    private Camera cam;
    private Surfer surfer;
    new private Rigidbody2D rigidbody;

    void Awake() {
        cam = GetComponent<Camera>();
        rigidbody = GetComponent<Rigidbody2D>();
        surfer = GameObject.FindObjectOfType<Surfer>();
    }

    void Start() {
    }

    void Update() {
        // Steer towards surfer.
        Vector3 targetPosition = surfer.AveragePosition;
        targetPosition.y *= 0.75f;
        Vector3 targetDirection = targetPosition - transform.position;
        float distance = targetDirection.magnitude;
        float speed = distance / period;
        rigidbody.velocity = targetDirection.normalized * speed;

        // Expand size when neccesary
        cam.orthographicSize = Mathf.Max(minCameraSize, transform.position.y - floorY);
    }
}
