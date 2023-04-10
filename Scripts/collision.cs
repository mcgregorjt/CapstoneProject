using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Item")
        {
            Debug.Log("We move");
            Destroy(collider.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "EnemyBullet") 
        {
            Destroy(collision.gameObject);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
