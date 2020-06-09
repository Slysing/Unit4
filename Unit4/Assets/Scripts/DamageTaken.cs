using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaken : MonoBehaviour
{

    public GameObject meteor;


    void Update()
    {
        


    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Meteor")
        {
            Destroy(col.gameObject);
            Debug.Log("destroy");
            //score count code getcomponent<>
        }

    }

}
