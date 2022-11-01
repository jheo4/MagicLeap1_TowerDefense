using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTile : MonoBehaviour
{
    public GameObject installedTower;

    // Start is called before the first frame update
    void Start()
    {
        installedTower = null;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Tower")
        {
            Debug.Log("OnTriggerEnter!");
            if(installedTower == null)
            {
                installedTower = other.gameObject;
                installedTower.transform.position = gameObject.transform.position;
                installedTower.transform.rotation = gameObject.transform.rotation;
                installedTower.GetComponent<Tower>().installed = true;
                Debug.Log("Installed!");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(installedTower != null)
        {
            installedTower.transform.position = gameObject.transform.position;
            installedTower.transform.rotation = gameObject.transform.rotation;
        }   
    }
}
