using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CoverFrame : Detail
{
    void Start()
    {
        Name = "Рамка крышки платформы";
        Description = "";

        pathToFollow = pathToFollow?.GetComponent<PathEditor>();
        if (pathToFollow)
        {
            pathToFollow.transform.position = transform.position;
            countOfDotsInPath = pathToFollow.pathPoints.Count;
        }
    }
}
