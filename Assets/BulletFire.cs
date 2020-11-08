using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    float bulletSpeed;
    private float bulletTimer;
    private float bulletLife;
    // Start is called before the first frame update
    void Start()
    {
        bulletTimer = 0.0f;
        bulletLife = 3.0f;
        bulletSpeed = 18.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 bulletDir = new Vector3(0.0f, -bulletSpeed * Time.deltaTime, 0.0f);
        transform.position += bulletDir;

        if(bulletTimer >= bulletLife)
            Destroy(gameObject);

        bulletTimer += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.name == "Player") 
            Destroy(gameObject);
    }
}
