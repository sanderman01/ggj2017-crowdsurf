using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioClip intro;
    public AudioClip music;
    public float introClipOffset = -0.08f;

    void Start()
    {
        StartCoroutine(PlayMusic());
    }

    public IEnumerator PlayMusic()
    {
        AudioSource audiosource = GetComponent<AudioSource>();
        audiosource.clip = intro;
        audiosource.loop = false;
        audiosource.Play();
        yield return new WaitForSecondsRealtime(intro.length + introClipOffset); 
        audiosource.Stop();
        audiosource.clip = music;
        audiosource.loop = true;
        audiosource.Play();
    }
}
