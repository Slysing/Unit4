﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    //public GameObject[] asteroids;  //pool of asteroids
    public Collider spawnerBoundingBox;
    public GameObject asteroidPrefab;
    public float asteroid_rateOfSpawn = 2f;
    private float nextSpawn = 1f;
    //public GameObject player;
    public float asteroidMoveForce = 300000f;

    void Start()
    {
        //player = GameObject.Find("Player");
        nextSpawn = 1f;
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
            nextSpawn = Time.time + asteroid_rateOfSpawn;
            Vector3 spawnPoint = RandomPointInBounds(spawnerBoundingBox.bounds);
            GameObject asteroid = Instantiate(asteroidPrefab, spawnPoint, Quaternion.identity) as GameObject;
            // get reference to Astroid, and set it up to head roughly towards the ship
            //asteroid.transform.LookAt(player.transform);
            //asteroid.GetComponent<Rigidbody>().AddForce(0f, 0f, -asteroidMoveForce);

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