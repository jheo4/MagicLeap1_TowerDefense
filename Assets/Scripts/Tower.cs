using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public bool installed;
    public bool grapped;
    public bool atStorage = true;

    public float attackSpeed;
    public float attackRange;
    public int damage;
    public float timeAfterAttack;

    public Enemy target = null;

    // Start is called before the first frame update
    void Start()
    {
        installed = false;    
        grapped = false;    
        atStorage = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void findEnemyToAttack()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, attackRange);
        foreach (Collider col in colliders)
        {
            if (col.tag == "Enemy")
            {
                target = col.GetComponent<Enemy>();
                break;
            }
        }

    }
}
