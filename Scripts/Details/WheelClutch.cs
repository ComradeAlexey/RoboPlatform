using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WheelClutch : Detail
{
    void Start()
    {
        Name = "Муфта колеса";
        Description = "";

        pathToFollow = pathToFollow?.GetComponent<PathEditor>();
        if (pathToFollow)
        {
            pathToFollow.transform.position = transform.position;
            countOfDotsInPath = pathToFollow.pathPoints.Count;
        }
    }
}
