using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public int currentWave = 0;
    public int maxWave = 3;
    public int spawnedEnemies = 0;
    public int maxWaveEnemies = 20; 
    public int currentEnemies = 0;
    public float timeBetweenWaves = 5.0f;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    public int enemyHP = 10;
    public float enemySpeed = 0.2f;
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
        spawnRateMin = 0.1f;
        spawnRateMax = 2.5f;

        waveText.text = "Wave " + currentWave;
        currentEnemiesText.text = "Current Enemies: " + currentEnemies;
    }

    public bool nextWave()
    {
        if(currentWave <= maxWave)
        {
            spawnedEnemies = 0;
            currentEnemies = 0;
            maxWaveEnemies = 30 + (currentWave * 15);
            timeBetweenWaves = 5 + (float)(currentWave*0.2);

            spawnRateMax = 1.5f - (float)(currentWave*0.5);
            spawnRateMax = (spawnRateMax > spawnRateMin) ? spawnRateMax : spawnRateMin;

            enemyScore = 100 + (currentWave*currentWave*10);
            enemyHP = 10 + (currentWave*10);
            enemySpeed = 0.3f + (currentWave * 0.2f);
    
            currentWave += 1;

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
