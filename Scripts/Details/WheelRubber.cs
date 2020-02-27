using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WheelRubber : Detail
{
    void Start()
    {
        Name = "Резина колеса";
        Description = "";

        pathToFollow = pathToFollow?.GetComponent<PathEditor>();
        if (pathToFollow)
        {
            pathToFollow.transform.position = transform.position;
            countOfDotsInPath = pathToFollow.pathPoints.Count;
        }
    }
}
