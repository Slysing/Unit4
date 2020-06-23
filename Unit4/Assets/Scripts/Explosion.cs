using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float destroySelfAfterXSeconds = 1f;

    public int explosionType;
    public AudioClip explode_Shot;
    public AudioClip explode_HitShip;


    void Start()
    {
        PlayExplosionSound();
        
        // destroy self after set time
        GameObject.Destroy(this.gameObject, destroySelfAfterXSeconds);
    }  


    void PlayExplosionSound()
    {
        // hit the ship
        if (explosionType == 2)
        { GetComponent<AudioSource>().PlayOneShot(explode_HitShip); }
        else
        // normal explosion
        { GetComponent<AudioSource>().PlayOneShot(explode_Shot); }
    }

}
