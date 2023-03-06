using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    //private bool shieldActive = false;
    public GameObject shieldPrefab;
    //private bool activeShield = false;
    /*public int maxDurability = 3;
    private int currDurability;*/
    
    // Start is called before the first frame update
    void Start()
    {
        /*shield = GameObject.Find("Deflector Shield").gameObject;*/
        //shieldPrefab.SetActive(true);
    }

    // Update is called once per frame

    public void ActivateShield()
    {
        
    }

    public void DeactivateShield()
    {
        
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Enemy")
        {
            Destroy(collider.gameObject);
        }

        if(collider.gameObject.tag == "EnemyBullet")
        {
            Destroy(collider.gameObject);
        }
    }
}
