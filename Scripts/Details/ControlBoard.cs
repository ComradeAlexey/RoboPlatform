using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ControlBoard : Detail
{
    void Start()
    {
        Name = "Микроконтроллер";
        Description = "";

        pathToFollow = pathToFollow?.GetComponent<PathEditor>();
        if (pathToFollow)
        {
            pathToFollow.transform.position = transform.position;
            countOfDotsInPath = pathToFollow.pathPoints.Count;
        }
    }
}
