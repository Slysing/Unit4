using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameController gc;
    public GameObject myTarget;
    public float speed_Min = 0.05f;
    public float speed_Max = 0.08f;
    private float speed = 0.1f;
    public GameObject explosion_Meteor;

    private void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        // set a random target from gc.asteroid_targets
        myTarget = gc.asteroid_targets[Random.Range(0, gc.asteroid_targets.Length)];
        // randomise my speed
        speed = Random.Range(speed_Min, speed_Max);

    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, myTarget.transform.position, speed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Window")
        {
            // tell GameController that the ship has taken damage
            gc.ShipTakesDamage();
            // spawn explosion particles
            GameObject explosion = Instantiate(explosion_Meteor, transform.position, Quaternion.identity) as GameObject;
            // set explosionType (2 = hit the ship)
            explosion.GetComponent<Explosion>().explosionType = 2;

            // destroy self
            Destroy(this.gameObject);
        }
        // any asteroids that go past ship, and reach harmless target are cleaned up
        else if (other.gameObject.tag == "HarmlessTarget")
        {
            Destroy(this.gameObject);
        }


        
    }


}
