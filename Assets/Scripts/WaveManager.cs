using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public int currentWave = 0;
    public int maxWave = 10;
    public int spawnedEnemies = 0;
    public int maxWaveEnemies = 20; 
    public int currentEnemies = 0;
    public float timeBetweenWaves = 5.0f;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;
    public int enemyScore = 100;
    public Text waveText;
    public Text currentEnemiesText;

    void OnEnable()
    {
        currentWave = 0;
        maxWave = 3;
        spawnedEnemies = 0;
        currentEnemies = 0;
        maxWaveEnemies = 20;
        timeBetweenWaves = 5.0f;
        spawnRateMin = 0.5f;
        spawnRateMax = 3f;
        enemyScore = 100;

        waveText.text = "Wave " + currentWave;
        currentEnemiesText.text = "Current Enemies: " + currentEnemies;
    }

    public bool nextWave()
    {
        if(currentWave <= maxWave)
        {
            currentWave += 1;
            spawnedEnemies = 0;
            currentEnemies = 0;
            maxWaveEnemies = 20 + (currentWave * 15);
            timeBetweenWaves = 5 + (float)(currentWave*0.2);
            spawnRateMax = 3 - (float)(currentWave*0.2);
            enemyScore = 100 + (currentWave*currentWave*10);

            waveText.text = "Wave " + currentWave;
            currentEnemiesText.text = "Current Enemies: " + currentEnemies;
            return true;
        }

        return false;
    }

    public bool spawnEnemy()
    {
        if(spawnedEnemies < maxWaveEnemies)
        {
            spawnedEnemies += 1;
            currentEnemies += 1;
            currentEnemiesText.text = "Current Enemies: " + currentEnemies;
            return true;
        }

        return false;
    }

    public float getSpawnRate()
    {
        return Random.Range(spawnRateMin, spawnRateMax);
    }

    public void reduceCurrentEnemies()
    {
        if(currentEnemies > 0) currentEnemies -= 1;
        currentEnemiesText.text = "Current Enemies: " + currentEnemies;
    }


}
