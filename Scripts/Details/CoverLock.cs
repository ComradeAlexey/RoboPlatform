using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CoverLock : Detail
{
    void Start()
    {
        Name = "Замок для крышки";
        Description = "";

        pathToFollow = pathToFollow?.GetComponent<PathEditor>();
        if (pathToFollow)
        {
            pathToFollow.transform.position = transform.position;
            countOfDotsInPath = pathToFollow.pathPoints.Count;
        }
    }
}
