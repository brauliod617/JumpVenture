using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreManager : MonoBehaviour {

    public static scoreManager instance;
    public TextMeshProUGUI text;
    int score;

	// Use this for initialization
	void Start () {
		if(instance == null)
        {
            instance = this;
        }
	}

    public void changeScore(int gemValue)
    {
        score += gemValue;
        text.text = "x" + score.ToString();
    }
    }
