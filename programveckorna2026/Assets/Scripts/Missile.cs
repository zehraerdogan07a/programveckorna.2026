using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Missile : MonoBehaviour
{
    public float speed = 10f; // Sätt speed public, kan ändras av bossen
    private Vector3 direction;

    private void Awake()
    {
        direction = Vector3.down; // Skjuter neråt mot player
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        // Ta bort missilen om den går utanför skärmen
        if (transform.position.y < -20)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);

            var healthComponent = collision.GetComponent<Player>();
            if (healthComponent != null)
                healthComponent.TakeDamage(1);
        }
    }
}


