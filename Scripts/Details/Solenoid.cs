using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Solenoid : Detail
{
    void Start()
    {
        Name = "Соленоид";
        Description = "Соленоид – это катушка, которая при возбуждении создает контролируемое магнитное поле, направленное к его центру. Если поместить магнитный стержень внутрь этого поля, этот стержень сможет перемещаться внутри катушки вперед и назад, то есть совершать механическую работу, например открывать замок или менять положение клапана. В нашем случае соленоид осуществляет удар по мячу.Соленоид срабатывает при появлении на его обмотки напряжения 6 вольт, поэтому подключается к управляющей плате через силовой ключ, реле или усилитель напряжения.";

        pathToFollow = pathToFollow?.GetComponent<PathEditor>();
        if (pathToFollow)
        {
            pathToFollow.transform.position = transform.position;
            countOfDotsInPath = pathToFollow.pathPoints.Count;
        }
    }
}
