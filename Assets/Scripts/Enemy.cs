using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* Calculates damage received and subtracts it from enemy health.
     * TODO: Currently only destroys enemy object when in contact with
     *      enemy*/
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Death();
        }
    }

    /* Destroys enemy object and potentially spawns an item */
    void Death()
    {
        GetComponent<ItemSpawning>().ItemInstance(transform.position);
        Destroy(this.gameObject);
    }
}

