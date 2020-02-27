using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AdditionalFastener : Detail
{
    void Start()
    {
        Name = "Крепёж";
        Description = "Дополнительные крепежи для УЗ-датчиков и крышки платформы";

        pathToFollow = pathToFollow?.GetComponent<PathEditor>();
        if (pathToFollow)
        {
            pathToFollow.transform.position = transform.position;
            countOfDotsInPath = pathToFollow.pathPoints.Count;
        }
    }
}
