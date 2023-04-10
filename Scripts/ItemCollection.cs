using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemCollection : MonoBehaviour
{
    public GameObject shield;
    public List<Item> itemList = new List<Item>();
    private string itemName;
    private bool itemActive = false;
    private bool itemReceived = false;

    /*Deactivates the shield prefab at startup to prevent its operation when its corresponding
     * item has not been collected*/
    void Start()
    {
        shield.SetActive(false);
    }

    /*Determines if an item has been received on each frame and conducts an enumerator
     for item enablement once an item is detected. If an item is already active, the 
     enumerator will not start.*/
    void FixedUpdate()
    {
        if(itemReceived)
        {
            itemReceived=false;
            if (!itemActive)
            {
                string currItemName = itemName;
                StartCoroutine(EnableItem(currItemName));
            }
            else
            {
                Debug.Log("Item did not activate. Item in use: " + itemName);
            }
        }
        
    }

    /*Method to collect an item's name and activate the item enablement functions*/
    public void CollectItem(string itemName)
    {
        this.itemName = itemName;
        itemReceived = true;
    }

    /*Searches for an item with the given name in the item list. Returns null if no
     * item is found*/
    Item FindItem(string itemName)
    {
        for(int i = 0; i < itemList.Count; i++) 
        {
            Item currItem = itemList[i];
            if(currItem.itemName == itemName)
            {
                return currItem;
            }
        }
        return null;
    }

    /*Enables item perks from collected items and activates it for the length of the item's
     durability*/
    IEnumerator EnableItem(string itemName)
    {
        itemActive = true;
        Item currItem = FindItem(itemName);
        float itemDuration = currItem.duration;
        Debug.Log(itemName + " enabled. Lasts for " + itemDuration + " seconds");

        /*Handles all item cases*/
        switch (itemName)
        {
            /*Scrap Material: adds health to player health bar*/
            case "Scrap Material":
                GetComponent<PlayerHealth>().currentHealth += 1;
                Debug.Log("Player health is now " + GetComponent<PlayerHealth>().currentHealth);
                break;
            
            /*Deflector Shield: surrounds the player and shields them from oncoming attacks*/
            case "Deflector Shield":
                shield.SetActive(true);
                yield return new WaitForSecondsRealtime(itemDuration);
                shield.SetActive(false);
                break;

            /*Engine Boosters: upgrades the movement speed of the player*/
            case "Engine Boosters":
                float defaultSpeed = GetComponent<PlayerController>().moveSpeed;

                GetComponent<PlayerController>().moveSpeed = 15.1f;

                GetComponent<PlayerController>().moveSpeed = 10.1f;

                yield return new WaitForSecondsRealtime(itemDuration);
                GetComponent<PlayerController>().moveSpeed = defaultSpeed;
                break;

            /*Gun Upgrade: uprgades the rate of fire for player bullets*/
            case "Gun Upgrade":
                Weapon currWeapon = GetComponent<PlayerController>().weapon;
                float defaultFireForce = currWeapon.fireForce;

                currWeapon.fireForce = 40f;
                yield return new WaitForSecondsRealtime(itemDuration);
                currWeapon.fireForce = defaultFireForce;
                break;
        }
        itemActive = false;
        Debug.Log("Item to be disabled");
        yield break;
    }
}
