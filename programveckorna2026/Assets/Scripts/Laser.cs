using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Laser : MonoBehaviour
{
    public float speed = 10f; // Hastighet
    public Vector3 direction = Vector3.up; // Riktning

    [SerializeField] private ParticleSystem damageParticles;
    public AudioClip impactSound;
    [SerializeField] private float impactVolume = 1f;

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Spawna partiklar
        if (damageParticles != null)
        {
            Instantiate(damageParticles, transform.position, Quaternion.identity);
        }

        // Spela ljud
        if (impactSound != null)
        {
            AudioSource.PlayClipAtPoint(impactSound, transform.position, impactVolume);
        }

        Destroy(gameObject);
    }
}
