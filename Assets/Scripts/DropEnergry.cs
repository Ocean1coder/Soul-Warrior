using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropEnergry : MonoBehaviour
{

    public GameObject dropItemPrefab;
    public List<LootItem> lootList = new List<LootItem>();

    LootItem GetDroppedItem()
    {
        int randomNumber = Random.Range(1, 101);
        List<LootItem> possibleItems = new List<LootItem>();
        foreach( LootItem item in lootList)
        {
            if(randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }
        if(possibleItems.Count > 0)
        {
            LootItem droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }
        
        Debug.Log("No loot dropped");
        return null;

    }

    public void InstantiateLoot(Vector3 spawnPosition)
    {
        LootItem droppedItem = GetDroppedItem();
        if(droppedItem != null)
        {
            GameObject lootGameObject = Instantiate(dropItemPrefab, spawnPosition, Quaternion.identity);
            lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite;

            float dropForce = 1f;
            Vector2 dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            lootGameObject.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce, ForceMode2D.Impulse); 

        }
    }

}
