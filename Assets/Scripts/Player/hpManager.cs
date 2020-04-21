using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class hpManager : MonoBehaviour
{

    public static hpManager instance;
    float maxHp = 100;
    float hp = 88;
    public Slider slider;


    // Use this for initialization
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void setHealth()
    {
        Debug.Log(hp / maxHp);
        slider.value = hp/maxHp;
    }

    public void hpIncrease(int healValue)
    {
        if (healValue + hp > maxHp)
        {
            hp = maxHp;
            Debug.Log("max hp");
        }
        else
        {
            hp += healValue;
            Debug.Log("hp:" + hp);
        }
        setHealth();
    }



}