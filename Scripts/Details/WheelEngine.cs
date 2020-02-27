using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WheelEngine : Detail
{
    void Start()
    {
        Name = "Двигатель";
        Description = "В мобильной платформе используется мотор с редуктором и энкодером JGA25-370B 12В. Редуктор влияет на изменения соотношений крутящего момента и скорости вращения. Мотор способен вращаться в двух направлениях, по часовой и против часовой стрелке. Смена вращения достигается изменением полярности напряжения на контактах двигателя. Энкодер предоставляет возможность определять направление вращение вала мотора и скорость его вращения. Применение энкодера позволяет определить моменты включения и выключения двигателя, а также рассчитать пройденное расстояние, если изделие установлено в самодвижущиеся платформы.";

        pathToFollow = pathToFollow?.GetComponent<PathEditor>();
        if (pathToFollow)
        {
            pathToFollow.transform.position = transform.position;
            countOfDotsInPath = pathToFollow.pathPoints.Count;
        }
    }
}
