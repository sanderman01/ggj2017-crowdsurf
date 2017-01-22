using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHUD : MonoBehaviour {

    private Text distanceTxt;

    void Awake() {
        distanceTxt = GetComponentInChildren<Text>();
    }
	
	void Update () {
        int distance = (int)Stats.currentGame.game_distance;
        distanceTxt.text = string.Format("Distance: {0}", distance);
	}
}
