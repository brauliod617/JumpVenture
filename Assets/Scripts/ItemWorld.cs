using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour {
    /*
    public static ItemWorld SpawnItemWorld(ItemWorld item)
    {
        
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();

        itemWorld.SetItem(item);

        return itemWorld;
        
    }
    private Item item;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        //spriteRenderer = GetComponent<spriteRenderer>();
    }

    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
    }

    public ItemWorld GetItem()
    {
        return item;
    }
    /*
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
    */
    
}
