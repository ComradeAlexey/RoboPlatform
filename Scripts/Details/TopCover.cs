using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TopCover : Detail
{
    void Start()
    {
        Name = "Верхняя крышка платформы";
        Description = "Крышка платформы для доступа к электронике и акб";

        pathToFollow = pathToFollow?.GetComponent<PathEditor>();
        if (pathToFollow)
        {
            pathToFollow.transform.position = transform.position;
            countOfDotsInPath = pathToFollow.pathPoints.Count;
        }
    }
}
