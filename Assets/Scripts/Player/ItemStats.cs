using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStats : MonoBehaviour
{
    
    public int extraHp;
    public int extraDamage;
    public int jumpFactor;
    public bool extraJump;


    void OnTriggerEnter2D(Collider2D otherObj)
    {
        //Debug.Log("We here");
        if (otherObj.gameObject.CompareTag("Player"))
        {
            //this.gameObject.GetComponent<PlayerStats>().AddItem();
            otherObj.gameObject.GetComponent<PlayerStats>().UpdateStats(extraHp, extraDamage, jumpFactor, extraJump);
        }
    }
}
