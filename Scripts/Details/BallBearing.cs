using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BallBearing : Detail
{
    void Start()
    {
        Name = "Опорный ролик";
        Description = "";

        pathToFollow = pathToFollow?.GetComponent<PathEditor>();
        if (pathToFollow)
        {
            pathToFollow.transform.position = transform.position;
            countOfDotsInPath = pathToFollow.pathPoints.Count;
        }
    }
}
