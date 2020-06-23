using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Asteroids")]
    public Collider spawnerBoundingBox;
    public GameObject asteroidPrefab;
    public float asteroid_rateOfSpawn_startRate = 2f;
    public float asteroid_rateOfSpawn_speedUpQuotient = 30f;
    public float asteroid_rateOfSpawn_fastestRate = 0.3f;
    private float asteroid_rateOfSpawn;
    private float nextSpawn = 1f;
    public GameObject[] asteroid_targets;

    [Header("Lives")]
    public bool playerIsAlive = true;
    public int lives = 5;
    public GameObject Life1;
    public GameObject Life2;
    public GameObject Life3;
    public GameObject Life4;
    public GameObject Life5;
    

    void Start()
    {
        // allow a bit of time before asteroids start spawning at all
        nextSpawn = 1.2f;

        // set initial spawn rate of meteors
        asteroid_rateOfSpawn = asteroid_rateOfSpawn_startRate;
    }

    
    void Update()
    {
        SpawnAsteroids();
    }

    
    public void ShipTakesDamage()
    {
        // reduce life points
        lives -= 1;

        if (true)
        {
            if (lives == 4)
            {
                Life5.SetActive(false);
            }
            if (lives == 3)
            {
                Life4.SetActive(false);
            }
            if (lives == 2)
            {
                Life3.SetActive(false);
            }
            if (lives == 1)
            {
                Life2.SetActive(false);
            }
            if (lives == 0)
            {
                Life1.SetActive(false);
                
                // game over!
                playerIsAlive = false;
            }
        }
    }
    

    void SpawnAsteroids()
    {
        // spawn asteroid every time the timer clocks over
        if (Time.time > nextSpawn)
        {
            // spawn a meteor
            Vector3 spawnPoint = RandomPointInBounds(spawnerBoundingBox.bounds);
            GameObject asteroid = Instantiate(asteroidPrefab, spawnPoint, Quaternion.identity) as GameObject;
            asteroid.layer = LayerMask.NameToLayer("Meteors");

            // set next spawn time 
            nextSpawn = Time.time + asteroid_rateOfSpawn;

            // reduce spawn time (so the rate of meteors increases as you play)
            asteroid_rateOfSpawn -= asteroid_rateOfSpawn / asteroid_rateOfSpawn_speedUpQuotient;

            // set cap for fastest spawn time (so it doesn't spawn them too fast)
            if (asteroid_rateOfSpawn < asteroid_rateOfSpawn_fastestRate)
            {
                asteroid_rateOfSpawn = asteroid_rateOfSpawn_fastestRate;
            }
        }
    }

    
    public Vector3 RandomPointInBounds(Bounds bounds)
    {
        // gives a random point within the spawner bounding box
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
            );
    }

}