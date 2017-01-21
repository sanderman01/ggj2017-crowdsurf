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
    public static event System.Action<Surfer, Vector3> OnHitFloor;

    /// <summary>
    /// Event fired when the surfer hits an obstacle. First parameter is this surfer object. Second parameter is the collision contact point.
    /// </summary>
    public static event System.Action<Surfer, Vector3> OnHitObstacle;

    public Vector3 AveragePosition { get { return averagePosition; } }
    private Vector3 averagePosition;

    void Update() {
        averagePosition = CalcAverage();
    }

    // Calculate the average position of all children.
    private Vector3 CalcAverage() {
        int n = transform.childCount;
        float m = 1f / n;
        Vector3 pos = Vector3.zero;
        foreach (Transform child in transform) {
            pos += child.position * m;
        }
        return pos;
    }

    public void OnCollisionEnter2D(Collision2D coll) {
        Debug.Log(string.Format("Collided with: {0}", coll.gameObject.name), this);

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
}
