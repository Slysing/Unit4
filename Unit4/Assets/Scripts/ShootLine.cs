using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLine : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float visibileDuration = 0.1f;
    public float startWidth = 0.3f;
    public float endWidth = 0.7f;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        Invoke("DestroySelf", visibileDuration);
    }


    public void SetupLinePoints(Vector3 start, Vector3 end)
    {
        //Debug.Log("Shoot line just set itself up.");
        lineRenderer.startWidth = startWidth;
        lineRenderer.endWidth = endWidth;
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = true;

        //set up start and end point
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }


    void DestroySelf()
    {
        Destroy(this.gameObject);
    }


}
