using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main script for the surfer ragdoll.
/// Calculates average position of ragdoll.
/// Listens for collision events with the floor or obstacles, to send appropriate events.
/// </summary>
public class Surfer : MonoBehaviour {

    /// <summary>
    /// Event fired when the surfer hits the floor. First parameter is this surfer object. Second parameter is the collision contact point.
    /// </summary>
    public event System.Action<Surfer, Vector3> OnHitFloor;

    /// <summary>
    /// Event fired when the surfer hits an obstacle. First parameter is this surfer object. Second parameter is the collision contact point.
    /// </summary>
    public event System.Action<Surfer, Vector3> OnHitObstacle;

    public Vector3 AveragePosition { get { return averagePosition; } }
    private Vector3 averagePosition;

    public float MinHeight { get { return minHeight; } }
    private float minHeight;

    public float MaxHeight { get { return maxHeight; } }
    private float maxHeight;

    private int currentCollisionCount = 0;

    /// <summary>
    /// Determines wether the rigidbodies are active or disabled.
    /// </summary>
    public bool RigidbodyActive {
        get { return rigidbodyActive; }
        set {
            rigidbodyActive = value;
            foreach (Transform child in transform) {
                Rigidbody2D body = child.GetComponent<Rigidbody2D>();
                if (rigidbodyActive) {
                    body.bodyType = RigidbodyType2D.Dynamic;
                } else {
                    body.bodyType = RigidbodyType2D.Kinematic;
                    body.velocity = Vector2.zero;
                    body.angularVelocity = 0;
                }

            }
        }
    }
    private bool rigidbodyActive;

    void Start() {
        //RigidbodyActive = false;
    }

    void Update() {
        CalcMinMaxAverage();
        Stats.currentGame.game_distance = Mathf.Max(Stats.currentGame.game_distance, AveragePosition.x);
        Stats.currentGame.jumps_highest = Mathf.Max(Stats.currentGame.jumps_highest, MaxHeight);

    }

    // Calculate the minimum height, maximum height, and average position of all children.
    private void CalcMinMaxAverage() {
        float minHeight = float.MaxValue;
        float maxHeight = float.MinValue;

        int n = transform.childCount;
        float m = 1f / n;
        Vector3 pos = Vector3.zero;
        foreach (Transform child in transform) {
            pos += child.position * m;
            minHeight = Mathf.Min(minHeight, pos.y);
            maxHeight = Mathf.Max(maxHeight, pos.y);
        }

        this.averagePosition = pos;
        this.minHeight = minHeight;
        this.maxHeight = maxHeight;
    }

    public void OnCollisionEnter2D(Collision2D coll) {
        currentCollisionCount += 1;

        // Respond to important collisions by sending events to other systems that may be interested.
        string tag = coll.gameObject.tag;
        switch (tag) {
            case Tags.Floor:
                if (OnHitFloor != null)
                    OnHitFloor(this, coll.contacts[0].point);
                break;
            case Tags.Obstacle:
                if (OnHitObstacle != null)
                    OnHitObstacle(this, coll.contacts[0].point);
                break;
        }
    }

    public void OnCollisionExit2D(Collision2D coll) {
        currentCollisionCount -= 1;

        if(currentCollisionCount == 0) {
            // We are no longer colliding with anything. this means we just started a jump.
            Stats.currentGame.jumps_total += 1;
        }
    }
}
