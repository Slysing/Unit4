using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Score")]
    public int asteroidsDestroyed;
    public Text text_score;

    [Header("Asteroids")]
    public Collider spawnerBoundingBox;
    public GameObject[] asteroidPrefab;
    public float asteroid_rateOfSpawn_startRate = 2f;
    public float asteroid_rateOfSpawn_speedUpQuotient = 30f;
    public float asteroid_rateOfSpawn_fastestRate = 0.3f;
    private float asteroid_rateOfSpawn;
    private float nextSpawn = 1f;
    public GameObject[] asteroid_targets;

    [Header("Lives")]
    public AudioClip audio_GameOver;
    public bool playerIsAlive = true;
    public int lives = 5;
    public GameObject Life1;
    public GameObject Life2;
    public GameObject Life3;
    public GameObject Life4;
    public GameObject Life5;
    public GameObject damageFX1;
    public GameObject damageFX2;
    public GameObject damageFX3;


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


    public void UpdateScore()
    {
        asteroidsDestroyed++;
        text_score.text = asteroidsDestroyed.ToString();
    }


    public void ShipTakesDamage()
    {
        // reduce life points
        lives -= 1;

        if (true)
        {
            if (lives == 4)
            {
                damageFX1.SetActive(true);
                Life5.SetActive(false);
            }
            if (lives == 3)
            {
                Life4.SetActive(false);
            }
            if (lives == 2)
            {
                damageFX2.SetActive(true);
                Life3.SetActive(false);
            }
            if (lives == 1)
            {
                Life2.SetActive(false);
            }
            if (lives == 0)
            {
                Life1.SetActive(false);
                damageFX3.SetActive(true);
                playerIsAlive = false;
                GetComponent<AudioSource>().PlayOneShot(audio_GameOver);
                Invoke("RestartGame", 10f);
            }
        }
    }


    void RestartGame()
    {
        SceneManager.LoadScene(0);
    }


    void SpawnAsteroids()
    {
        // spawn asteroid every time the timer clocks over (only if player is alive)
        if (Time.time > nextSpawn && playerIsAlive)
        {
            // spawn a meteor
            Vector3 spawnPoint = RandomPointInBounds(spawnerBoundingBox.bounds);
            GameObject asteroid = Instantiate(asteroidPrefab[Random.Range(0, asteroidPrefab.Length)], spawnPoint, Quaternion.identity) as GameObject;
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