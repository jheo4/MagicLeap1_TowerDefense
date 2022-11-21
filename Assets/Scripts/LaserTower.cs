using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTower : Tower
{
    private LineRenderer laserRenderer;

    // Start is called before the first frame update
    void Start()
    {
        attackSpeed = 3.0f;
        attackRange = 0.7f;

        laserRenderer = GetComponent<LineRenderer>();
        laserRenderer.positionCount = 2;
        laserRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterAttack += Time.deltaTime;

        findEnemyToAttack();
        if(target != null)
        {
            if(timeAfterAttack >= attackSpeed)
            {
                timeAfterAttack = 0f;
                // Vector3 enemyDirection = (transform.position - target.transform.position).normalized;

                RaycastHit hit;
                Vector3 hitPosition;

                // StartCoroutine(LaserEffect(transform.position + transform.forward * attackRange));

                if(Physics.Raycast(transform.position, (target.transform.position - transform.position), out hit, attackRange))
                // if(Physics.Raycast(transform.position, transform.forward, out hit, attackRange))
                {
                    // Vector3.Distance(transform.position, target.transform.position);
                    StartCoroutine(LaserEffect(hit.point));
                    target.Die(true);
                }
            }
        }

        target = null;
    }

    private IEnumerator LaserEffect(Vector3 hitPosition)
    {
        Vector3 startingPoint = transform.position;
        startingPoint.y += 0.15f;
        laserRenderer.SetPosition(0, startingPoint);
        laserRenderer.SetPosition(1, hitPosition);
        laserRenderer.enabled = true;
        yield return new WaitForSeconds(0.05f);
        laserRenderer.enabled = false;
    }
}
