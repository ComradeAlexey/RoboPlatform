using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BottomCover : Detail
{
    void Start()
    {
        Name = "Нижняя крышка";
        Description = "";

        pathToFollow = pathToFollow?.GetComponent<PathEditor>();
        if (pathToFollow)
        {
            pathToFollow.transform.position = transform.position;
            countOfDotsInPath = pathToFollow.pathPoints.Count;
        }
    }
}
