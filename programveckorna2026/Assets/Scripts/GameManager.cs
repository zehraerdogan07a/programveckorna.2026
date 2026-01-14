using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int lives = 5;
    public LifeUI lifeUI;

    private bool gameOver;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        lives = 5;
        gameOver = false;
        lifeUI.UpdateHearts(lives);
    }

    public void LoseLife()
    {
        if (gameOver) return;

        lives--;
        lifeUI.UpdateHearts(lives);

        if (lives <= 0)
        {
            gameOver = true;
            Debug.Log("GAME OVER");
        }
    }

    // temp
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoseLife();
        }
    }
}