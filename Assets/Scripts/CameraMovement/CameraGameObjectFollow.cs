using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGameObjectFollow : MonoBehaviour {

    public GameObject target;

    void Update()
    {
        Vector3 targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, this.gameObject.transform.position.z);
        this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, 1.0f);

    }
}
