using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class JoyStick : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler
{
    private Image joyBG,joy;
    private Vector2 input;
    [SerializeField]
    private HoV horizontalOrVertical;
    public GameManager gameManager;
    Vector2 pos;
    enum HoV
    {
        vertical,
        horizontal
    }
    void Start()
    {
        joyBG = GetComponent<Image>();
        joy = transform.GetChild(0).GetComponent<Image>();
    }
    public virtual void OnDrag(PointerEventData ped)
    {
        print("OnDrag");
        
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(joyBG.rectTransform,ped.position,ped.pressEventCamera,out pos))
        {
            Vector2 v2 = joyBG.rectTransform.rect.size;
            pos = new Vector2(Mathf.Clamp(pos.x, -255, 255), Mathf.Clamp(pos.y, -255, 255));
            if (horizontalOrVertical == HoV.horizontal)
            {
                gameManager.force.x = pos.x;
                pos.y = 0;
            }
            else
            {
                gameManager.force.y = pos.y;
                pos.x = 0;
            }
            joy.rectTransform.anchoredPosition = pos;

            gameManager.CalcJoystic();

        }
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
        print("OnPointerDown");
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        print("OnPointerUp");
        if (horizontalOrVertical == HoV.horizontal)
        {
            gameManager.force.x = 0;
        }
        else
        {
            gameManager.force.y = 0;
        }
        input = Vector2.zero;
        joy.rectTransform.anchoredPosition = Vector2.zero;
        gameManager.CalcJoystic();
    }
}
