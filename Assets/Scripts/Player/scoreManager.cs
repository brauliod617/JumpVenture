using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreManager : MonoBehaviour {

    public TextMeshProUGUI text;
    int score;

	// Use this for initialization
	void Start () {

	}

    public void changeScore(int gemValue)
    {
        score += gemValue;
        text.text = "x" + score.ToString();
    }
}
