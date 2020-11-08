using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bullet;

    float fireTimer;
    float fireSpeed;

    void Start()
    {
        fireTimer = 0.0f;
        fireSpeed = 0.2f; //every 1 second
    }

    // Update is called once per frame
    void Update()
    {
        if(fireTimer >= fireSpeed)
        {
            Shoot();
            fireTimer = 0.0f;
        }
        fireTimer += Time.deltaTime;
    }

    void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}
