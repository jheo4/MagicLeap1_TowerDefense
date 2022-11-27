using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject endPoint;
    public GameObject enemyPrefab;
    private Transform endPointLocation;
    private float spawnRate;
    private float timeAfterSpawn;
    private float timeBetweenWaves;
    bool onWave;
    bool needToSpawn;
    GameManager gameManager;

    // Start is called before the first frame update
    void OnEnable()
    {
        gameManager = GameManager.instance;

        timeAfterSpawn = 0;
        timeBetweenWaves = 0;
        onWave = false;
        needToSpawn = false;
        endPointLocation = endPoint.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(onWave == false)
        {
            timeBetweenWaves += Time.deltaTime;
            if(timeBetweenWaves > gameManager.waveManager.timeBetweenWaves)
            {
                timeBetweenWaves = 0;
                onWave = true;
                needToSpawn = true;
                gameManager.waveManager.nextWave();
                spawnRate = gameManager.waveManager.getSpawnRate();
            }
        }
        else // onWave
        {
            if(needToSpawn)
            {
                timeAfterSpawn += Time.deltaTime;
                if(timeAfterSpawn >= spawnRate)
                {
                    timeAfterSpawn = 0f;
                    spawnRate = gameManager.waveManager.getSpawnRate();
                    bool spawned = gameManager.waveManager.spawnEnemy();
                    if(spawned == true)
                    {
                        // enemy spawn...
                        GameObject newEnemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
                        Enemy enemyComponent = newEnemy.GetComponent<Enemy>();
                        if(enemyComponent != null)
                        {
                            enemyComponent.MoveTo(endPoint.transform.position);
                        }
                    }
                    else
                    {
                        needToSpawn = false;
                    }
                }
            }
            else
            {
                if(gameManager.waveManager.currentEnemies == 0)
                {
                    onWave = false;
                }
            }   
        }
    }

}
