using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 20f;

    [Header("Health")]
    public int maxHealth = 4;
    public int currentHealth;

    [Header("Sprites")]
    public Sprite Player1;
    public Sprite Player2;
    public Sprite Player3;
    public Sprite Player4;

    [Header("Laser")]
    public Laser laserPrefab;           // Dra in din Laser-prefab här
    public float fireRate = 1.5f;       // Sekunder mellan skott

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip shoot;
    public AudioClip die;

    private SpriteRenderer spriteRenderer;
    private float nextFireTime = 0f;

    private void Awake()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Se till att AudioSource finns
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        // Startposition inom kamerans vy
        transform.position = new Vector3(0, -13.77f, 0);
    }

    private void Update()
    {
        HandleMovement();
        HandleShooting();
        UpdateSprite();
        HandleRestart();
    }

    private void HandleMovement()
    {
        float h = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(h, 0, 0) * speed * Time.deltaTime;
        transform.position += movement;
    }

    private void HandleShooting()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            // Skapa laser
            Instantiate(laserPrefab, transform.position, Quaternion.identity);

            // Spela ljud
            if (shoot != null)
            {
                audioSource.PlayOneShot(shoot, 0.5f);
            }

            nextFireTime = Time.time + fireRate;
        }
    }

    private void UpdateSprite()
    {
        switch (currentHealth)
        {
            case 4:
                spriteRenderer.sprite = Player1;
                break;
            case 3:
                spriteRenderer.sprite = Player2;
                break;
            case 2:
                spriteRenderer.sprite = Player3;
                break;
            case 1:
                spriteRenderer.sprite = Player4;
                break;
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;

            // Spela dödljud
            if (die != null)
            {
                audioSource.PlayOneShot(die, 0.5f);
            }

            // Flytta ut spelaren från scenen
            transform.position = new Vector3(100, -40, 0);

            Debug.Log("Du förlorade. Tryck Y för att spela igen eller N för att avsluta.");
        }
    }

    private void HandleRestart()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            currentHealth = maxHealth;
            transform.position = new Vector3(0, -13.77f, 0);
            audioSource.Stop();
        }
    }
}

