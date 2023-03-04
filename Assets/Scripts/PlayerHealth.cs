using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int damage = 1;
    public int currentHealth;
    public int maxHealth = 3;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;        
   }
void OnCollisionEnter2D(Collision2D collision)
    {
if(collision.gameObject.tag == "Enemy")
        {
		TakeDamage(damage);
	}

        if (collision.gameObject.tag == "EnemyBullet") {
            Destroy(collision.gameObject);
            TakeDamage(damage);
        }
	if(currentHealth <= 0)
	{
          Destroy(gameObject);
	}
        }
}
