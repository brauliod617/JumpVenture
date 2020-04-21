using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour {

	public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform pfItemWorld;


    public Sprite cherry;
    public Sprite claws;
    public Sprite armor;
    public Sprite legs;
    public Sprite hjboots;
    public Sprite djboots;

}
