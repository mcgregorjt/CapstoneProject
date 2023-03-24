using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawning : MonoBehaviour
{
    /***Variables***/
    public GameObject spawnedItemPrefab;             // Variable that controls the Item prefab that spawns items upon death
    private GameObject currItemObject;               // Current instantiated item object 
    public List<Item> itemList = new List<Item>();   // List that holds all existing items

    /***Methods***/

    /*Selects a random item to spawn upon an enemy's death if the item's drop rate percentage
     * is in range*/
    private Item getItem()
    {
        int randNum = Random.Range(1, 101);           //Random number generator
        List<Item> potentialDrops = new List<Item>(); // List that will contain all potential items
        
        /*Iterates through each item object in itemLits and compares its drop rate to the 
         * randomly generated number from randNum. If random number is less than or equal
         * to the current item's drop rote, the item is added to the list of potential 
         * item spanws*/
        foreach(Item currItem in itemList)
        {
            if(randNum <= currItem.dropRate)
            {
                potentialDrops.Add(currItem);

            }
        }

        /* Randomly selects an item from the potential drops list if there are objects stored
         * inside it. If not, no item is returned*/
        if (potentialDrops.Count > 0)
        {
            Item spawnedItem = potentialDrops[Random.Range(0, potentialDrops.Count)];
            return spawnedItem;
        }
        return null;
    }

    /*Spawns item and simulates explosion mobility once enemy is destroyed*/
    public void ItemInstance(Vector3 spawnPosition)
    {
        Item spawnedItem = getItem();  //Call to getItem method

        /*If the spawned item is not null, the item prefab is instantiated and 
         * displayed on screen. Force is then applied to the prefab so that it 
         * drifts along the X and Y axis*/
        if(spawnedItem != null)
        {
            //***SUBJECT TO CHANGE***//
            currItemObject = Instantiate(spawnedItemPrefab, spawnPosition, Quaternion.identity);
            currItemObject.GetComponent<SpriteRenderer>().sprite = spawnedItem.itemSprite;
            currItemObject.name = spawnedItem.itemName;
            currItemObject.gameObject.tag = "Item";
            currItemObject.gameObject.layer = 6;
            float force = 75f;
            Vector2 direction = new Vector2(Random.Range(-1f, 1f), Random.Range(0f, -1f));
            currItemObject.GetComponent<Rigidbody2D>().AddForce(direction * force, ForceMode2D.Impulse);
        }
    }

}
