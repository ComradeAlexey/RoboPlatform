using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InfraredSensor : Detail
{
    void Start()
    {
        Name = "Инфракрасный датчик";
        Description = "Цифро-аналоговый датчик отражения способен различать черную и белую поверхность, а также находить все оттенки серого. В датчике TCRT5000 использована готовая связка инфракрасного светодиода и фототранзистора. На его выходах можно получать как аналоговый так и цифровой сигналы. Основным назначением является использование его в качестве датчика определения линии. Также, при неизменном цвете отражающей поверхности его возможно использовать как датчик расстояния, датчик препятствий, а также как датчик оборотов или энкодер, если на вращающийся вал нанести контрастную разметку.";

        pathToFollow = pathToFollow?.GetComponent<PathEditor>();
        if (pathToFollow)
        {
            pathToFollow.transform.position = transform.position;
            countOfDotsInPath = pathToFollow.pathPoints.Count;
        }
    }
}
