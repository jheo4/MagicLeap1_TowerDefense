using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTower : Tower
{
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        attackSpeed = 0.4f;
        attackRange = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterAttack += Time.deltaTime;

        if(target != null)
        {
            if(timeAfterAttack >= attackSpeed)
            {
                timeAfterAttack = 0f;
                GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                bullet.transform.LookAt(target.transform);
            }
        }

        target = null;
        findEnemyToAttack();
    }
}
