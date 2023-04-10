using System.Collections;
using UnityEngine;

public class EnemySpawning : MonoBehaviour {

    //detail what enum does
    public enum SpawnState { spawning, waiting, counting };

    //Allows changes/edits to be made inside the inspector in Unity
    [System.Serializable]

    public class EnemyWave {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;

    }

    public Transform[] spawnPoints;

    public EnemyWave[] enemyWave;

    //stores index of the next enemy
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;

    private float waveCountdown;

    private float searchCountdown = 1f;

    public SpawnState state = SpawnState.counting;

    void Start() {
        waveCountdown = timeBetweenWaves;
    }

    void Update() {
        //used to see if enemies are still alive in game
        if (state == SpawnState.waiting) {
            //see if enemies are still alive
            if (!enemyIsAlive()) {
                waveCompleted();
            }

            else {
                return;
            }
        }


        if (waveCountdown <= 0) {
            //checks to see whether or not to intialize the spawning of enemies
            if (state != SpawnState.spawning) {
                StartCoroutine(spawnWave(enemyWave[nextWave]));
            }
        }

        else {
            //time.deltaTime used to subract appropriate amount of time per frame for specific computer. This differs for different computers
            //because, different computers have different frame rate processing speeds.
            waveCountdown -= Time.deltaTime;
        }
        
    }


    void waveCompleted() {

        Debug.Log("Wave Completed!");
        state = SpawnState.counting;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > enemyWave.Length - 1) {
            nextWave = 0;
            Debug.Log("All enemy waves complete. Looping");
        }

        else {
            nextWave++;
        }

    }


    bool enemyIsAlive() {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f) {

            searchCountdown = 1f;
            //very taxing piece of code on compute will check all game objects, thus the more game objects in the game the longer it will take
            if (GameObject.FindGameObjectWithTag("Enemy") == null) {
                return false;
            }
        }

        return true;
    }

    //IEnumerator is used to wait a certain amount of seconds inside a method before continuing
    IEnumerator spawnWave(EnemyWave wave) {
        Debug.Log("Spawning Wave" + wave.name);
        state = SpawnState.spawning;

        for (int i = 0; i < wave.count; i++) {
            spawnEnemy(wave.enemy);

            yield return new WaitForSeconds(1f / wave.rate);
        }

        state = SpawnState.waiting;

        yield break; // return nothing
    }

    IEnumerator spawnEnemy(Transform enemy) {
        Debug.Log("Spawning Enemy " + enemy.name);

        /* if(GameObject.Find("enemy4Prefab")) 
         {
             for(int i = 3; i < 16; i++) {
                 Instantiate(enemy, spawnPoints[i].position, transform.rotation);
             }

           // return;

         }*/

        int randSpawnPoint = Random.Range(0, spawnPoints.Length);
        //spawn points for enemy (may have to make random points on game plane
        Instantiate(enemy, spawnPoints[randSpawnPoint].position, transform.rotation);

        state = SpawnState.waiting;

        yield break; // return nothing
    }




    //void spawnEnemy(Transform enemy) 
    //{
    //    Debug.Log("Spawning Enemy " + enemy.name);

    //    int randSpawnPoint = Random.Range(0, spawnPoints.Length);
        //spawn points for enemy (may have to make random points on game plane
    //    Instantiate(enemy, spawnPoints[randSpawnPoint].position, transform.rotation);

    //}
}
