using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SideSolenoidMount : Detail
{
    void Start()
    {
        Name = "Боковое крепление соленоида";
        Description = "";

        pathToFollow = pathToFollow?.GetComponent<PathEditor>();
        if (pathToFollow)
        {
            pathToFollow.transform.position = transform.position;
            countOfDotsInPath = pathToFollow.pathPoints.Count;
        }
    }
}
