using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SideCover : Detail
{
    void Start()
    {
        Name = "Боковая крышка платформы";
        Description = "";

        pathToFollow = pathToFollow?.GetComponent<PathEditor>();
        if (pathToFollow)
        {
            pathToFollow.transform.position = transform.position;
            countOfDotsInPath = pathToFollow.pathPoints.Count;
        }
    }
}
