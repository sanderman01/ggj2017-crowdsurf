using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Quick and dirty script for dragging rigidbodies in the sandbox, for testing purposes.
/// </summary>
public class SandboxMouseDrag : MonoBehaviour {

    [SerializeField]
    new private Rigidbody2D rigidbody;
    [SerializeField]
    private Joint2D joint;

    void Update() {

        Vector3 screenPoint = Input.mousePosition;
        Vector2 pos = Camera.main.ScreenToWorldPoint(screenPoint);
        rigidbody.MovePosition(pos);

        if (Input.GetMouseButtonDown(0)) {
            // user hit left mouse button. try to find object under cursor and start dragging
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0);

            if (hit && hit.rigidbody != null) {
                joint.connectedBody = hit.rigidbody;
            }

        } else if (Input.GetMouseButtonUp(0)) {
            // user hit left mouse button. release dragged object if neccesary.
            if (joint.connectedBody != null) {
                joint.connectedBody = null;
            }
        }
    }
}
