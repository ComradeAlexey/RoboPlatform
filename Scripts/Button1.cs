using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button1 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isLeft;
    public bool isJump;
    public GameManager gameManager;

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        gameManager.isButton = true;
        if (isJump) gameManager.Jump();
        else
        {
            if (isLeft)
            {
                gameManager.Left();
            }
            else
            {
                gameManager.Right();
            }
        }
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        if (isJump) gameManager.UnJump();
    }
}
