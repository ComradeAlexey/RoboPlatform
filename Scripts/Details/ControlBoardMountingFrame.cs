using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ControlBoardMountingFrame : Detail
{
    void Start()
    {
        Name = "Держатель микроконтроллера";
        Description = "";

        pathToFollow = pathToFollow?.GetComponent<PathEditor>();
        if (pathToFollow)
        {
            pathToFollow.transform.position = transform.position;
            countOfDotsInPath = pathToFollow.pathPoints.Count;
        }
    }
}
