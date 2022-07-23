using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject[] bulletPrefabs;
    public bool canShoot = true;
    public float baseResetShootTime = 0.5f;
    private float resetShootTime = 0.9f;
    private int bulletType = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bulletType = 0;
            resetShootTime = baseResetShootTime + 0.5f;
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            bulletType = 1;
            resetShootTime = baseResetShootTime + 0.25f;
            Shoot();
            Invoke("Shoot", resetShootTime + 0.10f);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            bulletType = 2;
            resetShootTime = baseResetShootTime;
            Shoot();
            Invoke("Shoot", resetShootTime + 0.10f);
            Invoke("Shoot", resetShootTime + resetShootTime + 0.15f);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            bulletType = 3;
            resetShootTime = baseResetShootTime + 0.5f;
            Shoot();
        }

    }

    private void Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            Instantiate(bulletPrefabs[bulletType], transform);
            Invoke("ResetShoot", resetShootTime);
        }
    }

    private void ResetShoot()
    {
        canShoot = true;
    }
}
