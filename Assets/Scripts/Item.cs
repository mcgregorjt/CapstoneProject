/*Referenced from "Flexible LOOT SYSTEM in Unity with Random Drop Rates" by BMo*/

/* Description: The Item class creates scriptable item objects that that the player can interact 
 * with once an enemy is defeated. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class Item : ScriptableObject
{
    /***Variables***/
    public Sprite itemSprite;    //The sprite of a given item (TODO: store sprite animations)
    public string itemName;      //The name of an item
    public double dropRate;      //The percentage of drop scarcity
    public int duration;         //The duration of an item's ability



    /***Item Constructor***/
    public Item (string itemName, double dropRate)
    {
        this.itemName = itemName;
        this.dropRate = dropRate;
    }
}
