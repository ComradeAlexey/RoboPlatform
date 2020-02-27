using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BackSolenoidCover : Detail
{
    void Start()
    {
        Name = "Задняя крышка соленоида";
        Description = "";

        pathToFollow = pathToFollow?.GetComponent<PathEditor>();
        if (pathToFollow)
        {
            pathToFollow.transform.position = transform.position;
            countOfDotsInPath = pathToFollow.pathPoints.Count;
        }
    }
}
