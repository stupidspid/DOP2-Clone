using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EarseController : MonoBehaviour, IEarsable
{ 
    [SerializeField] private LineRenderer lineRenderer;
    
    public void Begin(Vector3 position)
    {
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount-1, position);
    }

    public void Stop()
    {
        lineRenderer.positionCount = 0;
    }
}
