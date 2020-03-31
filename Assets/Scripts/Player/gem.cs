using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gem : MonoBehaviour {

    public int gemValue = 1; 
    void OnTriggerEnter2D(Collider2D otherObj)
    {
        Debug.Log("We here");
        if (otherObj.gameObject.CompareTag("Player"))
        {
            Debug.Log("We IN here");
            scoreManager.instance.changeScore(gemValue); 
        }
    }
}
