using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FemaleScrew : Detail
{
    void Start()
    {   Name = "Гайка";
        Description = "";

        pathToFollow = pathToFollow?.GetComponent<PathEditor>();
        if (pathToFollow)
        {
            pathToFollow.transform.position = transform.position;
            countOfDotsInPath = pathToFollow.pathPoints.Count;
        }
    }
}
