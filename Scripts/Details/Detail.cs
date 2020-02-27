using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public abstract class Detail : MonoBehaviour
{
    public PathEditor pathToFollow;
    public float speed;
    [HideInInspector]
    public bool destinationReached; 

    public string Name { get; protected set; }
    public string Description { get; protected set; }

    protected int currentDotPathId;
    protected float reachDistance;
    protected Vector3 lastPosition;
    protected Vector3 currentPosition;
    protected int countOfDotsInPath;

    // Start is called before the first frame update

    public void Start()
    {
        destinationReached = false;
        currentDotPathId = 0;
        reachDistance = 0.01f;
        lastPosition = gameObject.transform.position;
    }

    public IEnumerator MoveFromBeginToEnd()
    {
        while (currentDotPathId < countOfDotsInPath)
        {
            Vector3 nextDot = pathToFollow.pathPoints[currentDotPathId].position;
            float distance = Vector3.Distance(nextDot, gameObject.transform.position);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, nextDot, Time.deltaTime * speed);

            if (distance <= reachDistance)
            {
                currentDotPathId++;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    public IEnumerator MoveFromEndToBegin()
    {
        while (currentDotPathId > 0)
        {
            Vector3 nextDot = pathToFollow.pathPoints[currentDotPathId - 1].position;
            float distance = Vector3.Distance(nextDot, gameObject.transform.position);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, nextDot, Time.deltaTime * speed);

            if (distance <= reachDistance)
            {
                currentDotPathId--;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
