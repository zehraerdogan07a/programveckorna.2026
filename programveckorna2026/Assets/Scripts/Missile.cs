using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Missile : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 direction;

    private void Awake()
    {
        direction = Vector3.down;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        if (transform.position.y < -20f)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);

            Player player = collision.GetComponent<Player>();
            if (player != null)
                player.TakeDamage(1);
        }
    }
}
