using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public Collider spawnerBoundingBox;
    public GameObject asteroidPrefab;
    public float asteroid_rateOfSpawn_startRate = 2f;
    public float asteroid_rateOfSpawn_speedUpQuotient = 30f;
    public float asteroid_rateOfSpawn_fastestRate = 0.3f;
    private float asteroid_rateOfSpawn;
    //public bool lives0 = false;
    private float nextSpawn = 1f;

    void Start()
    {
        // allow a bit of time before asteroids start spawning at all
        nextSpawn = 2f;

        // set initial spawn rate of meteors
        asteroid_rateOfSpawn = asteroid_rateOfSpawn_startRate;
    }



    void Update()
    {
        SpawnAsteroids();
    }




    void SpawnAsteroids()
    {
        // spawn asteroid every time the timer clocks over
        if (Time.time > nextSpawn)
        {
            // spawn a meteor
            Vector3 spawnPoint = RandomPointInBounds(spawnerBoundingBox.bounds);
            GameObject asteroid = Instantiate(asteroidPrefab, spawnPoint, Quaternion.identity) as GameObject;

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