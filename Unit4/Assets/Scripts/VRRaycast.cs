using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRRaycast : MonoBehaviour
{

    public bool validHit;
    public RaycastHit lastHitObject;


    void Update()
    {
        //if (Physics.Raycast(transform.position, transform.forward, out lastHitObject))
        //{
        //    validHit = true;
        //}
        //else
        //{
        //    validHit = false;
        //}

        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        if (Physics.Raycast(transform.position, transform.forward, out lastHitObject))
        {
            Vector3 offset = (transform.right * 0.5f) - (transform.up * 0.3f);
            lineRenderer.SetPosition(0, transform.position + offset);
            lineRenderer.SetPosition(1, lastHitObject.point);
            lineRenderer.enabled = true;
            validHit = true;
        }
        else
        {
            validHit = false;
            lineRenderer.enabled = false;
        }
    }

    public bool GetIsHit()
    {
        return validHit;
    }

    public Vector3 GetHitPosition()
    {
        if (validHit)
            return lastHitObject.point;
        return Vector3.zero;
    }
    public GameObject GetHitObject()
    {
        if (validHit)
            return lastHitObject.collider.gameObject;
        return null;
    }

}
