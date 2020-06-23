using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastBullet : MonoBehaviour
{
    public GameObject explosion_Meteor;
    public AudioClip sound_shoot;
    public AudioClip sound_explodeMeteor;
    public LayerMask meteorsLayer;


    private void Start()
    {
        //meteorsLayer = LayerMask.NameToLayer("Meteors");
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // play shoot sound
            GetComponent<AudioSource>().PlayOneShot(sound_shoot, 0.7f);
            //Debug.Log("Player fired.");

            // debug ray
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, meteorsLayer))
            {
                //Debug.Log(hit.collider.gameObject.tag);
                if (hit.collider.gameObject.tag == "Meteor")
                {
                    //Debug.Log("Player shot a meteor!");
                    // spawn explosion particle system
                    GameObject explosion = Instantiate(explosion_Meteor, hit.transform.position, Quaternion.identity) as GameObject;
                    // set explosionType (1 = normal)
                    explosion.GetComponent<Explosion>().explosionType = 1;
                    // destroy meteor
                    Destroy(hit.collider.gameObject);
                }
            }
        }


    }
}
