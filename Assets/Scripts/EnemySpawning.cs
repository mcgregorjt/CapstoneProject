using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour {
    //[SerializeField]public Rigidbody2D rb;
    //[SerializeField]public Spriterenderer sr;
    
    public GameObject enemy1Prefab;
    //public GameObject[];
    public Transform EnemySpawn;
    public float xPos;
    public float yPos;
    public int count = 0;
    public float startTimeDelay = 2;
    public float timeInterval = 3;

    //Start is called before the first frame update
    void Start() 
    {
        
    }

    // Update is called once perframe
    void Update()
    {
        {
            InvokeRepeating("EnemySpawner", startTimeDelay, timeInterval);
            EnemySpawner();
        }
    }

    void EnemySpawner() 
    {
       

        if ( GameObject.FindGameObjectsWithTag("Enemy").Length < 3) {

            
            xPos = Random.Range(-1.5f, 2.49f);
            yPos = Random.Range(5.98f, 6.50f);
            Vector2 enemyPos = new Vector2(xPos, yPos);
            Instantiate(enemy1Prefab, enemyPos, EnemySpawn.rotation);

            //count += 1;
        }

    }
}
