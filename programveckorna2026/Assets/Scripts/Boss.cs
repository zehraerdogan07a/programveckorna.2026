using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Prefabs & FX")]
    [SerializeField] private Missile missilePrefab;        // Missilen bossen skjuter
    [SerializeField] private ParticleSystem damageParticals; // Partiklar vid död

    [Header("Boss stats")]
    public int maxHealthBoss = 6;
    private int currentHealthBoss;

    [Header("Movement")]
    private float speed = 10f;
    private int direction = -1; // 1 = höger, -1 = vänster

    private void Start()
    {
        currentHealthBoss = maxHealthBoss;
        // Starta att skjuta missiler
        InvokeRepeating(nameof(FireMissile), 1f, 2.5f);
    }

    private void Update()
    {
        MoveBoss();
    }

    // Rörelse horisontellt
    private void MoveBoss()
    {
        transform.position += (direction == 1 ? Vector3.right : Vector3.left) * speed * Time.deltaTime;

        // Vänd vid skärmens kanter
        if (transform.position.x <= -15 || transform.position.x >= 15)
        {
            direction *= -1;
        }
    }

    // Kallas av player när bossen träffas
    public void TakeDamageBoss(int amount)
    {
        currentHealthBoss -= amount;

        if (currentHealthBoss <= 0)
        {
            Die();
        }
    }

    // Dödar bossen
    private void Die()
    {
        // Spawna partiklar ovanför bossen
        Instantiate(damageParticals, transform.position + Vector3.up * 2, Quaternion.identity);

        Destroy(gameObject); // Förstör bossen
        Debug.Log("Du vann! Bossen är dödad.");
    }

    // Skjuter missiler mot spelaren
    private void FireMissile()
    {
        // Slumpa ett “gap” för missiler
        int missFire = Random.Range(0, 30);

        for (int i = 0; i < 30; i++)
        {
            if (i < missFire - 4 || i > missFire + 4)
            {
                Vector3 spawnPos = new Vector3(-15 + i, transform.position.y, 0);
                Missile missile = Instantiate(missilePrefab, spawnPos, Quaternion.identity);

                // Sätt hastighet på missilen
                missile.speed = 10f;
            }
        }
    }
}


