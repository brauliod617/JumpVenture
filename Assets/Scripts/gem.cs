using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gem : MonoBehaviour {

    public int gemValue = 1; 
    void OnTriggerEnter2D(Collider2D otherObj)
    {
        if (otherObj.gameObject.CompareTag("Player"))
        {
            scoreManager.instance.changeScore(gemValue); 
        }
    }
}
