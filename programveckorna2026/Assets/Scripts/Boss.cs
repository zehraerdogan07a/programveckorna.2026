using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Prefabs & FX")]
    [SerializeField] private Missile missilePrefab;        // Missilen bossen skjuter
    [SerializeField] private ParticleSystem damageParticals; // Partiklar vid d�d

    [Header("Boss stats")]
    public int maxHealthBoss = 6;
    private int currentHealthBoss;

    [Header("Movement")]
    private float speed = 10f;
    private int direction = -1; // 1 = h�ger, -1 = v�nster

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

    // R�relse horisontellt
    private void MoveBoss()
    {
        transform.position += (direction == 1 ? Vector3.right : Vector3.left) * speed * Time.deltaTime;

        // V�nd vid sk�rmens kanter
        if (transform.position.x <= -15 || transform.position.x >= 15)
        {
            direction *= -1;
        }
    }

    // Kallas av player n�r bossen tr�ffas
    public void TakeDamageBoss(int amount)
    {
        currentHealthBoss -= amount;

        if (currentHealthBoss <= 0)
        {
            Die();
        }
    }

    // D�dar bossen
    private void Die()
    {
        // Spawna partiklar ovanf�r bossen
        Instantiate(damageParticals, transform.position + Vector3.up * 2, Quaternion.identity);

        Destroy(gameObject); // F�rst�r bossen
        Debug.Log("Du vann! Bossen �r d�dad.");
    }

    // Skjuter missiler mot spelaren
    private void FireMissile()
    {
        // Slumpa ett �gap� f�r missiler
        int missFire = Random.Range(0, 30);

        for (int i = 0; i < 30; i++)
        {
            if (i < missFire - 4 || i > missFire + 4)
            {
                Vector3 spawnPos = new Vector3(-15 + i, transform.position.y, 0);
                Missile missile = Instantiate(missilePrefab, spawnPos, Quaternion.identity);

                // S�tt hastighet p� missilen
                missile.speed = 10f;
            }
        }
    }
}


