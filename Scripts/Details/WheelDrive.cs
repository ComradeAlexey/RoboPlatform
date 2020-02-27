using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WheelDrive : Detail
{
    void Start()
    {
        Name = "Диск колеса";
        Description = "";

        pathToFollow = pathToFollow?.GetComponent<PathEditor>();
        if (pathToFollow)
        {
            pathToFollow.transform.position = transform.position;
            countOfDotsInPath = pathToFollow.pathPoints.Count;
        }
    }
}
