using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Laser : MonoBehaviour
{
    public float speed = 10f;
    public Vector3 direction = Vector3.up;

    [SerializeField] private ParticleSystem damageParticles;
    public AudioClip impactSound;
    [SerializeField] private float impactVolume = 1f;

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kolla om vi träffar en Enemy
        if (collision.CompareTag("Enemy"))
        {
            // Partiklar
            if (damageParticles != null)
            {
                Instantiate(damageParticles, transform.position, Quaternion.identity);
            }

            // Ljud
            if (impactSound != null)
            {
                AudioSource.PlayClipAtPoint(impactSound, transform.position, impactVolume);
            }

            // Döda enemy
            Destroy(collision.gameObject);

            // Förstör lasern
            Destroy(gameObject);
        }
    }
}
