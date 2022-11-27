using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    GameManager gameManager;
    public float speed = 0.3f;
    public int hp;
    public int score;
    public NavMeshAgent navMeshAgent;

    void OnEnable()
    {
        gameManager = GameManager.instance;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void MoveTo(Vector3 destination)
    {
        StopCoroutine("OnMove");
        navMeshAgent.speed = speed;
        navMeshAgent.SetDestination(destination);
        StartCoroutine("OnMove");
    }

    IEnumerator OnMove()
    {
        while(true)
        {
            if(Vector3.Distance(navMeshAgent.destination, transform.position) < 0.05f)
            {
                transform.position = navMeshAgent.destination;
                navMeshAgent.ResetPath();
                break;
            }

            yield return null;
        }
    }

    public void getDamage(int damage)
    {
        hp = hp - damage;
        if(hp <= 0) Die(true);
    }

    public void Die(bool giveScore)
    {
        gameManager.waveManager.reduceCurrentEnemies();
        if(giveScore)
        {
            gameManager.player.addScore(score);
        }
        gameObject.SetActive(false);
        Destroy(gameObject, 0);
    }
}
