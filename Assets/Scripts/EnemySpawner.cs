using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject endPoint;
    public GameObject enemyPrefab;
    public float spwanRateMin = 0.5f;
    public float spawnRateMax = 3f;
    private Transform endPointLocation;
    private float spawnRate;
    private float timeAfterSpawn;
    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0;
        spawnRate = Random.Range(spwanRateMin, spawnRateMax);
        endPointLocation = endPoint.transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        if(timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
            newEnemy.transform.LookAt(endPointLocation);
            spawnRate = Random.Range(spwanRateMin, spawnRateMax);
        }
    }
}
