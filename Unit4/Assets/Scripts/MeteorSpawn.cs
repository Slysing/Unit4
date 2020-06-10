using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{

    public GameObject Meteor;
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public int spawn;

    // Start is called before the first frame update
    void Start()
    {

        //spawn1 = Random.Range(1, 3);
        //spawn2 = Random.Range(1, 3);
        //spawn3 = Random.Range(1, 3);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("spawn"))
        {
            spawn = Random.Range(1, 4);

            if( spawn == 1)
            {
                //Instantiate(Meteor, spawn1);
            }

            if (spawn == 2)
            {
                Instantiate(Meteor, transform.position, transform.rotation);
            }

            if (spawn == 3)
            {
                Instantiate(Meteor, transform.position, transform.rotation);
            }

        }
    }
}
