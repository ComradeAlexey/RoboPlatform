using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UltrasonicSensor : Detail
{
    void Start()
    {
        Name = "Ультразвуковой датчик";
        Description = "Ультразвуковой датчик расстояния HC SR04 является прибором бесконтактного типа, и обеспечивает высокоточное измерение и стабильность. Диапазон дальности его измерения составляет от 2 до 400 см.";

        pathToFollow = pathToFollow?.GetComponent<PathEditor>();
        if (pathToFollow)
        {
            pathToFollow.transform.position = transform.position;
            countOfDotsInPath = pathToFollow.pathPoints.Count;
        }
    }
}
