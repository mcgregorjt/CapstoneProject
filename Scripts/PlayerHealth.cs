using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public int damage = 1;
    public int currentHealth;
    public int maxHealth = 3;
    public float extraLives = 3;
    public float livesCounter;
    public Text LifeText;
    Renderer rend;
    Color c;
    
    public GameObject Player;
    private bool isDead;
    public GameManager gameManager;

   
    void Start()
    {
        livesCounter = extraLives;
        
        rend = GetComponent<Renderer>();
        c = rend.material.color;
        currentHealth = maxHealth;
    }
    void Update() {
        livesCounter = extraLives;
        LifeText.text = "x " + livesCounter;
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

            
            if (extraLives > 0) {

                extraLives -= 1;
                
                Player.transform.position = new Vector3(-500, -500, 0);
                StartCoroutine(Timer());
                StopCoroutine(Timer());
                StartCoroutine(Invulnerable());
                

            }
            else if (!isDead){
                isDead = true;
                Destroy(gameObject);
                gameManager.gameOver();
                //game over screen
            }
        }
    }

    IEnumerator Invulnerable() {
        Debug.Log("Invuln on");
        Physics2D.IgnoreLayerCollision(11, 9, true);
        Physics2D.IgnoreLayerCollision(11, 13, true);
        c.a = 0.5f;
        rend.material.color = c;
        yield return new WaitForSeconds(3f);
        Physics2D.IgnoreLayerCollision(11, 9, false);
        Physics2D.IgnoreLayerCollision(11, 13, false);
        c.a = 1f;
        rend.material.color = c;
    }
    IEnumerator Timer() {
        yield return new WaitForSeconds(3);
        currentHealth = maxHealth;
        Player.transform.position = new Vector3(0, 0, 0);
       

            Destroy(gameObject);
	      }

}