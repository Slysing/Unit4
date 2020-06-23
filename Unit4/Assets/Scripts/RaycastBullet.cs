using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastBullet : MonoBehaviour
{
    public GameController gc;
    public GameObject gun;
    public Vector3 targetHitPosition;
    public GameObject explosion_Meteor;
    public GameObject shootLine;
    public AudioClip sound_shoot;
    public AudioClip sound_explodeMeteor;
    public LayerMask meteorsLayer;



    void Update()
    {
        CheckForPlayerFiring();
    }


    void CheckForPlayerFiring()
    {
        if (Input.GetButtonDown("Fire1") && gc.playerIsAlive)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, meteorsLayer))
            {
                //Debug.Log(hit.collider.gameObject.tag);

                // if hit meteor
                if (hit.collider.gameObject.tag == "Meteor")
                {
                    //Debug.Log("Player shot a meteor!");
                    // play shoot sound
                    GetComponent<AudioSource>().PlayOneShot(sound_shoot, 0.7f);
                    // store hit position (for lazer drawing)
                    targetHitPosition = hit.point;
                    // spawn explosion particle system
                    GameObject explosion = Instantiate(explosion_Meteor, hit.transform.position, Quaternion.identity) as GameObject;
                    // set explosionType (1 = normal)
                    explosion.GetComponent<Explosion>().explosionType = 1;
                    // increment score in GameController
                    gc.UpdateScore();
                    // destroy meteor (must happen last)
                    Destroy(hit.collider.gameObject);
                }

                else if (hit.collider.gameObject.tag == "Space")
                {
                    // play shoot sound
                    GetComponent<AudioSource>().PlayOneShot(sound_shoot, 0.7f);
                    // store hit position (for lazer drawing)
                    targetHitPosition = hit.point;
                    //Debug.Log("Player shot into empty space!");
                }


            }

            // spawn ShootLine for bullet effect  (and pass in values for start and end point for this bullet line)
            GameObject shootLineObject = Instantiate(shootLine, gun.transform.position, Quaternion.identity) as GameObject;
            shootLineObject.GetComponent<ShootLine>().SetupLinePoints(gun.transform.position, hit.point);


        }
    }




}
