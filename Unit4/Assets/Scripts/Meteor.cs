using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{

    public GameController gc;
    public GameObject myTarget;
    public float speed = 0.1f;


    private void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        // set a random target from gc.asteroid_targets
        myTarget = gc.asteroid_targets[Random.Range(0, gc.asteroid_targets.Length)];
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
            // destroy self
            Destroy(this.gameObject);

        }
    }


}
