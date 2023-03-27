using System.Collections;
using UnityEngine;

public class EnemySpawning : MonoBehaviour {
    
    //detail what enum does
    public enum SpawnState { spawning, waiting, counting };

    //Allows changes/edits to be made inside the inspector in Unity
    [System.Serializable]

    public class EnemyWave 
    {
        public string name;
        public Transform enemy;
        //public Transform enemy2;
        public int count;
        public float rate;

    }

   // public Rigidbody rb;
    public Transform[] spawnPoints;

    public EnemyWave[] enemyWave;
    public EnemyWave[] enemyWave2;

    //stores index of the next enemy
    private int nextWave = 0;
    private int nextWave2 = 0;

    public float timeBetweenWaves = 5f;

    private float waveCountdown;

    private float searchCountdown = 1f;

    public SpawnState state = SpawnState.counting;

    void Start() 
    {
        waveCountdown = timeBetweenWaves;

    }

    void Update() 
    {
        //used to see if enemies are still alive in game
        if(state == SpawnState.waiting) {
            //see if enemies are still alive
            if(!enemyIsAlive()) {
                waveCompleted();
            }

            else {
                return;
            }
        }


        if(waveCountdown <= 0) {
            //checks to see whether or not to intialize the spawning of enemies
            if(state != SpawnState.spawning) {
                StartCoroutine(spawnWave(enemyWave[nextWave], enemyWave2[nextWave2]));
            }
        }

        else {
            //time.deltaTime used to subract appropriate amount of time per frame for specific computer. This differs for different computers
            //because, different computers have different frame rate processing speeds.
            waveCountdown -= Time.deltaTime;
        }
    }


    void waveCompleted() 
    {

        Debug.Log("Wave Completed!");
        state = SpawnState.counting;
        waveCountdown = timeBetweenWaves;

        if(nextWave + 1 > enemyWave.Length - 1) {
            nextWave = 0;
            nextWave2 = 0;
            Debug.Log("All enemy waves complete. Looping");
        }

        else {
            nextWave++;
            nextWave2++;
        }
        
    }


    bool enemyIsAlive() 
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0f) {

            searchCountdown = 1f;
            //very taxing piece of code on compute will check all game objects, thus the more game objects in the game the longer it will take
            if(GameObject.FindGameObjectWithTag("Enemy") == null) {
                return false;
            }
        }

        return true;
    }

    //IEnumerator is used to wait a certain amount of seconds inside a method before continuing
    IEnumerator spawnWave(EnemyWave wave, EnemyWave wave2) 
    {
        int spawnPointNum = 0;
        Debug.Log("Spawning Wave" + wave.name + "\n" + wave2.name);
        state = SpawnState.spawning;

        for(int i = 0; i < wave.count; i++) {
            /*if(i == 5) {
                wave.enemy.
            }*/
            spawnEnemy(wave.enemy, wave2.enemy,spawnPointNum);

            if(nextWave != 1) {
                //line of code used to make enemies appear one by one.
                yield return new WaitForSeconds(1f / wave.rate);
                yield return new WaitForSeconds(1f / wave2.rate);
            }




            spawnPointNum++;
        }

        state = SpawnState.waiting;

        yield break; // return nothing
    }

    void spawnEnemy(Transform enemy, Transform enemy2, int spawnPointNum) 
    {
        Debug.Log("Spawning Enemy " + enemy.name);

        int randSpawnPoint = Random.Range(0, spawnPoints.Length);
        int randSpawnPoint2 = Random.Range(0, spawnPoints.Length);

        if (nextWave == 2) {
            //spawn points for enemy (may have to make random points on game plane
            Instantiate(enemy, spawnPoints[randSpawnPoint].position, transform.rotation);
            Instantiate(enemy2, spawnPoints[randSpawnPoint2].position, transform.rotation);
            return;
        }

        if (nextWave == 3 || nextWave == 4) {
            Instantiate(enemy, spawnPoints[spawnPointNum].position, transform.rotation);
            Instantiate(enemy2, spawnPoints[12 - spawnPointNum].position, transform.rotation);
            return;
        }


        Instantiate(enemy, spawnPoints[spawnPointNum].position, transform.rotation);
        Instantiate(enemy2, spawnPoints[spawnPointNum].position, transform.rotation);
        return;

        /*Instantiate(enemy, spawnPoints[spawnPointNum].position, transform.rotation);
        Instantiate(enemy2, spawnPoints[spawnPointNum].position, transform.rotation);
        return;*/


        //spawn points for enemy (may have to make random points on game plane
        //Instantiate(enemy, spawnPoints[randSpawnPoint].position, transform.rotation);
        //Instantiate(enemy2, spawnPoints[randSpawnPoint].position, transform.rotation);

        //return;

    }
}
