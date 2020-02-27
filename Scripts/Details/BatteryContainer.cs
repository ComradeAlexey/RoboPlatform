using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BatteryContainer : Detail
{
    void Start()
    {
        Name = "Контейнер для аккумуляторов";
        Description = "";

        pathToFollow = pathToFollow?.GetComponent<PathEditor>();
        if (pathToFollow)
        {
            pathToFollow.transform.position = transform.position;
            countOfDotsInPath = pathToFollow.pathPoints.Count;
        }
    }
}
