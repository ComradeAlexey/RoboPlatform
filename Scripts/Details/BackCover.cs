using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BackCover : Detail
{
    void Start()
    {
        Name = "Передний борт платформы";
        Description = "Имеет отверстия под УЗ-датчик и соленоид";

        pathToFollow = pathToFollow?.GetComponent<PathEditor>();
        if (pathToFollow)
        {
            pathToFollow.transform.position = transform.position;
            countOfDotsInPath = pathToFollow.pathPoints.Count;
        }
    }
}
