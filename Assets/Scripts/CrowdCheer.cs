using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdCheer : MonoBehaviour {

    public Surfer surfer;
    public float cheerHeight = 2.5f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (surfer.MaxHeight > cheerHeight && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}
