using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour {

    [SerializeField]
    private float multiplier = 0.8f;

    private Vector3 pos;

    void Start() {
        pos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 p = pos;
        p.x += multiplier * Camera.main.transform.position.x;
        transform.position = p;
	}
}
