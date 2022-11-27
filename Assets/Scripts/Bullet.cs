using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 0.18f;
    private Rigidbody bulletRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;
        Destroy(gameObject, 5f);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if(enemy != null)
            {
                enemy.Die(true);
                Destroy(gameObject, 0f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
