using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaken : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Meteor"))
        {
            Destroy(other.gameObject);
            //Debug.Log("boom");
            //score count code getcomponent<>
        }
    }

}
