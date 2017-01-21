using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attach this to each child rigidbody to make sure we get collision events from children to the parent.
/// </summary>
public class SurferChildCollider : MonoBehaviour {

    private Surfer parent;

    void Awake() {
        parent = GetComponentInParent<Surfer>();
    }

    void OnCollisionEnter2D(Collision2D coll) {
        parent.OnCollisionEnter2D(coll);
    }

    //void OnCollisionStay2D(Collision2D coll) {
    //}

    void OnCollisionExit2D(Collision2D coll) {
        parent.OnCollisionExit2D(coll);
    }
}
