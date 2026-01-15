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
    public int maxHealth = 4;
    public int currentHealth;
    float wait = 0;
    SpriteRenderer PG;
    


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
        if (currentHealth == 4)
        {
            print("test");


            transform.position = position;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                print("skjut");
                laser = Instantiate(laserPrefab, transform.position + new Vector3(0,1,0), Quaternion.identity);
                wait = Time.time;


            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
               
            }




            if (Input.GetKeyDown(KeyCode.Y))
            {
                currentHealth = maxHealth;
                transform.position = new Vector3(0, -13.77f, 0);

            }
        }
    }
}

