using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SponsorPageNext : MonoBehaviour {

    public Image[] sponsorImage;
    int currentLogo = 0;

	// Use this for initialization
	void Start () {
        StartCoroutine(NextPage(2.0f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator NextPage(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (currentLogo < sponsorImage.Length)
        {
            sponsorImage[currentLogo].CrossFadeAlpha(0, 1f, false);
            currentLogo++;
            StartCoroutine(NextPage(6));
        }
        else
        {
            Debug.Log("GOTO Next Scene");
        }
    }
}
