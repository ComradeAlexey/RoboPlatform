using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FrontCover : Detail
{
    void Start()
    {
        Name = "Задний борт платформы";
        Description = "";

        pathToFollow = pathToFollow?.GetComponent<PathEditor>();
        if (pathToFollow)
        {
            pathToFollow.transform.position = transform.position;
            countOfDotsInPath = pathToFollow.pathPoints.Count;
        }
    }
}
