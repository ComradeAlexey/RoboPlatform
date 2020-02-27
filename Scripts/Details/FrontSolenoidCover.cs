using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FrontSolenoidCover : Detail
{
    void Start()
    {
        Name = "Передняя крышка соленоида";
        Description = "";

        pathToFollow = pathToFollow?.GetComponent<PathEditor>();
        if (pathToFollow)
        {
            pathToFollow.transform.position = transform.position;
            countOfDotsInPath = pathToFollow.pathPoints.Count;
        }
    }
}
