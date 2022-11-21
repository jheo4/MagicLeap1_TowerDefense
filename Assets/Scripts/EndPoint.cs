using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    GameManager gameManager;

    void OnEnable()
    {
        gameManager = GameManager.instance;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.Die(false);
                gameManager.player.reduceLife();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
