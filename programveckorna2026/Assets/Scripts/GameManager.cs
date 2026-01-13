using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int lives = 3;
    public LifeUI lifeUI;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        lifeUI.UpdateHearts(lives);
    }

    public void LoseLife()
    {
        lives--;

        if (lives < 0)
            lives = 0;

        lifeUI.UpdateHearts(lives);

        if (lives == 0)
        {
            Debug.Log("GAME OVER");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoseLife();
        }
    }
}

