using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour
{
    public int healValue = 10;
    void OnTriggerEnter2D(Collider2D otherObj)
    {
        //Debug.Log("We here");
        if (otherObj.gameObject.CompareTag("Player"))
        {
            otherObj.gameObject.GetComponent<PlayerStats>().Heal(healValue);
        }
    }
}
