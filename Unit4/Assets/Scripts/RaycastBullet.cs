using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastBullet : MonoBehaviour
{

    public GameObject explosion_Meteor;

    public AudioClip sound_shoot;
    public AudioClip sound_explodeMeteor;


    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            // play shoot sound
            GetComponent<AudioSource>().PlayOneShot(sound_shoot, 0.7f);
            //Debug.Log("Player fired.");

            // debug ray
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            int layerMask = 1 << 9;
            layerMask = ~layerMask;

            RaycastHit hit;
            
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                
                if (hit.collider.gameObject.tag == "Meteor")
                {
                    Debug.Log("Player shot a meteor!");
                    // spawn explosion particle system
                    Instantiate(explosion_Meteor, hit.transform.position, Quaternion.identity);
                    // destroy meteor
                    Destroy(hit.collider.gameObject);

                    // play metero explode sound
                    GetComponent<AudioSource>().PlayOneShot(sound_explodeMeteor, 0.9f);
                }
            }
        }

        
    }
}
