using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    public Laser laserPrefab;
    private Laser laser;
    private float speed = 20f;

    public int maxHealth = 4;
    public int currentHealth;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Debug.Log("Du förlorade! Tryck Y för att spela igen.");
        }
    }

    void Update()
    {
        Vector3 position = transform.position;

        if (Input.GetKey(KeyCode.LeftArrow))
            position.x -= speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow))
            position.x += speed * Time.deltaTime;

        transform.position = position;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            laser = Instantiate(laserPrefab, transform.position + Vector3.up, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            currentHealth = maxHealth;
            transform.position = new Vector3(0, -13.77f, 0);
        }
    }
}