using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Alien : MonoBehaviour
{
    public GameObject missilePrefab;
    public float shootInterval = 15f;

    private float shootTimer;

    void Update()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer >= shootInterval)
        {
            FireMissile();
            shootTimer = 0f;
        }
    }

    void FireMissile()
    {
        Instantiate(
            missilePrefab,
            transform.position,
            Quaternion.identity
        );
    }
}
