using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float destroySelfAfterXSeconds = 1f;

    void Start()
    {
        // destroy self after set time
        GameObject.Destroy(this.gameObject, destroySelfAfterXSeconds);
    }  
    
}
