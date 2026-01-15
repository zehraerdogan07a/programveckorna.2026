using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    
    GameManager GM;
    public Laser laserPrefab;
    Laser laser;
    float speed = 20f;
    public int maxHealth = 5;
    public int currentHealth;
    float wait = 0;
    SpriteRenderer PG;
    public AudioSource audioSource;
    public AudioClip shoot;
    public AudioClip die;




    private void Start()
    {
        currentHealth = maxHealth;
        PG = GetComponent<SpriteRenderer>();

    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            transform.position = new Vector3(100, -40, 0);
            audioSource.clip = die;
            audioSource.volume = 0.05f;
            audioSource.Play();
            Debug.Log("Du förlora. Tryck y för att spela igen eller n för att avsluta");

        }

    }




    // Update is called once per frame
    void Update()
    {
        print("test2");
        Vector3 position = transform.position;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            position.x -= speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            position.x += speed * Time.deltaTime;
        }
        
        //bara för o testa health med "H"
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage();
        }


    }
    public void TakeDamage()
    {
        currentHealth--;

        
        GameManager.Instance.LoseLife();

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("PLAYER DEAD");
        gameObject.SetActive(false);
    }

}

