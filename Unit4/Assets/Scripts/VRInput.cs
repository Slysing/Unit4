using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRInput : MonoBehaviour
{


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            VRRaycast raycast = GetComponent<VRRaycast>();
            if (raycast.GetIsHit())
            {
                GameObject hitObj = raycast.GetHitObject();
                Destroy(raycast.GetHitObject());
            }
        }
    }
}
