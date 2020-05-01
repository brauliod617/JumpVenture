using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreManager : MonoBehaviour
{

    public TextMeshProUGUI text;
    static int score;

	// Use this for initialization
	void Start () {

	}
    public void onDeath()
    {
        score = 0;
        text.text = "x" + score.ToString();
    }
    public void changeScore(int gemValue)
    {
        score += gemValue;
        Debug.Log(text);
        text.text = "x" + score.ToString();
    }
}
