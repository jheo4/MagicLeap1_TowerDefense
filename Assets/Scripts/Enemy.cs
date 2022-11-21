using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameManager gameManager;
    public Rigidbody enemyRigidbody;
    public float speed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
        enemyRigidbody.velocity = transform.forward * speed;
        gameManager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die(bool giveScore)
    {
        gameManager.waveManager.reduceCurrentEnemies();
        if(giveScore)
        {
            gameManager.player.addScore(100);
        }
        gameObject.SetActive(false);
        Destroy(gameObject, 0);
    }
}
