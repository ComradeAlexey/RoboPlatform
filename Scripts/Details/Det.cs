using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Det : Detail
{
    public string N;
    public string D;
    void Start()
    {
        Name = N;
        Description = D; 

        pathToFollow = pathToFollow?.GetComponent<PathEditor>();
        if (pathToFollow)
        {
            pathToFollow.transform.position = transform.position;
            countOfDotsInPath = pathToFollow.pathPoints.Count;
        }
    }
}

