using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BottomSolenoidMount : Detail
{
    void Start()
    {
        Name = "Нижний крепёж соленоида";
        Description = "";

        pathToFollow = pathToFollow?.GetComponent<PathEditor>();
        if (pathToFollow)
        {
            pathToFollow.transform.position = transform.position;
            countOfDotsInPath = pathToFollow.pathPoints.Count;
        }
    }
}
