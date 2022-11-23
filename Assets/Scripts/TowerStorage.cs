using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStorage : MonoBehaviour
{
    public float spawnRate = 25f;
    public float timeAfterSpawn;
    public GameObject towerPrefab1;
    public GameObject towerPrefab2;
    private int totalTowers = 2;
    private int towerIndexToSpawn;
    public Tower currentTower;

    // Start is called before the first frame update
    void OnEnable()
    {
        timeAfterSpawn = 25f;
        towerIndexToSpawn = 0;
        currentTower = null;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        if(timeAfterSpawn > spawnRate && currentTower == null)
        {
            towerIndexToSpawn = Random.Range(0, totalTowers);
            timeAfterSpawn = 0;
            Vector3 location = transform.position;
            location.y += 0.1f;
            GameObject towerPrefabToSpawn = null;
            // Create a tower;
            if (towerIndexToSpawn == 0)
                towerPrefabToSpawn = towerPrefab1;
            else if (towerIndexToSpawn == 1)
                towerPrefabToSpawn = towerPrefab2;

            GameObject newTower = Instantiate(towerPrefabToSpawn, location, transform.rotation);
            currentTower = newTower.GetComponent<Tower>();
            Debug.Log("currentTower " + newTower.GetComponent<Tower>().atStorage);
        }

        if(currentTower != null)
        {
            if(currentTower.atStorage == false)
            {
                currentTower = null;
                timeAfterSpawn = 0;
            }
        }
    }
}
