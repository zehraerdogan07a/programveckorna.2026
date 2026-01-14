using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class Missile : Projectile
{

    private void Awake()
    {
        direction = Vector3.down;
    }

    void Update()
    {
        transform.position += speed * Time.deltaTime * direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    

        if (collision.tag == "Player")
        {
            Destroy(gameObject);

            var healthComponnent = collision.GetComponent<Player>();
            if (healthComponnent != null)
            {
                healthComponnent.TakeDamage(1);
            }
        }

    }


}
