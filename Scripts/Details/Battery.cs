using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Battery : Detail
{
    void Start()
    {
        Name = "Аккумулятор";
        Description = "Li-on 18650 емкостью 2.2 Ач, напряжение 3.7 В.";

        pathToFollow = pathToFollow?.GetComponent<PathEditor>();
        if (pathToFollow)
        {
            pathToFollow.transform.position = transform.position;
            countOfDotsInPath = pathToFollow.pathPoints.Count;
        }
    }
}
