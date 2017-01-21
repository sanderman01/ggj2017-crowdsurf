using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioClip intro;
    public AudioClip music;

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
        yield return new WaitForSeconds(intro.length - 0.08f); //1.5f is the real length in seconds of the intro
        audiosource.Stop();
        audiosource.clip = music;
        audiosource.loop = true;
        audiosource.Play();
    }
}
