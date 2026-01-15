using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 Instance;

    public int shipsAlive;
    public GameObject bossPrefab;
    public Transform bossSpawnPoint;

    private bool bossSpawned = false;

    void Awake()
    {
        Instance = this;
    }

    public void ShipDestroyed()
    {

        print("Destroyong enemy:" + shipsAlive);
        shipsAlive--;

        if (shipsAlive <= 0 && !bossSpawned)
        {
            SpawnBoss();
        }
    }

    void SpawnBoss()
    {
        print("Spawning boss");
        bossSpawned = true;
        Instantiate(bossPrefab, bossSpawnPoint.position, Quaternion.identity);

    }
}

