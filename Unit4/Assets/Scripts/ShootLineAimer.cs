using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLineAimer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float visibileDuration = 0.1f;
    public float startWidth = 0.3f;
    public float endWidth = 0.7f;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    

    public void UpdateLinePoints(Vector3 start, Vector3 end)
    {
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = true;
        lineRenderer.startWidth = startWidth;
        lineRenderer.endWidth = endWidth;

        //set up start and end point
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);

        // enable line
        lineRenderer.enabled = true;
    }
    

}
