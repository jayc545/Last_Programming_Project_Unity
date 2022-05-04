using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Refferences")]
    public Transform[] spawnSpots;
    public GameObject Enemy;
    private int randomSpawnSpot;
    private Transform PagePos;


    [Header("Zombie Spawning calcs")]
    public int SpawnTimeInSecs = 5;
    public int maxX = 10; //Max Enemy in game.
    float timer = 0;
    int x = 0;

    void Start()
    {
        //The Timer always starts with 0.
        timer = 0;

        randomSpawnSpot = Random.Range(0, spawnSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        SpawningEnemy();
    }

    void SpawningEnemy()
    {
        randomSpawnSpot = Random.Range(0, spawnSpots.Length);
        if (timer >= SpawnTimeInSecs)
        {
            x = Random.Range(0, maxX);
            Instantiate(Enemy, spawnSpots[randomSpawnSpot].transform);
            randomSpawnSpot++;
            timer = 0;
        }
    }
}
