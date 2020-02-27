using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AdditionalEngineMount : Detail
{
    void Start()
    {
        Name = "Дополнительный крепеж двигателя.";
        Description = "Также является крепежом рамки крепления печатной платы";

        pathToFollow = pathToFollow?.GetComponent<PathEditor>();
        if (pathToFollow)
        {
            pathToFollow.transform.position = transform.position;
            countOfDotsInPath = pathToFollow.pathPoints.Count;
        }
    }
}
