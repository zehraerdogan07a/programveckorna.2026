using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private Missile missilePrefab;
    [SerializeField] private ParticleSystem damageParticals; // valfritt

    public int maxHealthBoss = 6;
    private int currentHealthBoss;

    private float speed = 10f;
    private int direction = -1;

    private void Start()
    {
        currentHealthBoss = maxHealthBoss;
        InvokeRepeating(nameof(FireMissile), 1f, 2.5f);
    }

    private void Update()
    {
        MoveBoss();
    }

    private void MoveBoss()
    {
        transform.position += (direction == 1 ? Vector3.right : Vector3.left) * speed * Time.deltaTime;

        if (transform.position.x <= -15 || transform.position.x >= 15)
            direction *= -1;
    }

    public void TakeDamageBoss(int amount)
    {
        currentHealthBoss -= amount;
        if (currentHealthBoss <= 0) Die();
    }

    private void Die()
    {
        if (damageParticals != null)
            Instantiate(damageParticals, transform.position + Vector3.up * 2, Quaternion.identity);

        Destroy(gameObject);
        Debug.Log("Du vann! Bossen är dödad.");
    }

    private void FireMissile()
    {
        int missFire = Random.Range(0, 30);
        for (int i = 0; i < 30; i++)
        {
            if (i < missFire - 4 || i > missFire + 4)
            {
                Vector3 spawnPos = new Vector3(-15 + i, transform.position.y, 0);
                Missile missile = Instantiate(missilePrefab, spawnPos, Quaternion.identity);
                missile.speed = 10f;
            }
        }
    }
}
