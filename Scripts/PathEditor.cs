using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathEditor : MonoBehaviour
{
    public Color rayColor = Color.white;
    public List<Transform> pathPoints = new List<Transform>();

    private Transform[] Points; // get children transform. all dots are children of PathHolder object

    public void OnDrawGizmos()
    {
        Gizmos.color = rayColor;
        Points = GetComponentsInChildren<Transform>();
        pathPoints.Clear();

        foreach(var point in Points)
        {
            if(point != transform)
            {
                pathPoints.Add(point);
            }
        }

        for(int i = 0; i < pathPoints.Count; i++)
        {
            Vector3 currentDot = pathPoints[i].position;
            if(i > 0)
            {
                Vector3 previousDot = pathPoints[i - 1].position;
                Gizmos.DrawLine(currentDot, previousDot);
                Gizmos.DrawSphere(currentDot, 0.1f);
            }
        }
    }
}
