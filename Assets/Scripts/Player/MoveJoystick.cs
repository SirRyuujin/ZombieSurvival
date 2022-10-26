using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveJoystick : MonoBehaviour
{
    public GameObject joystickMove;
    public GameObject joystickBGMove;
    public Image JoystickImage;
    public Image JoystickBgImage; 
    public Vector2 joystickVecMove;
    private Vector2 joystickTouchPosMove;
    private Vector2 joystickOriginalPosMove;
    private float joystickRadiusMove;

    // Start is called before the first frame update
    void Start()
    {
        joystickOriginalPosMove = joystickBGMove.transform.position;
        joystickRadiusMove = joystickBGMove.GetComponent<RectTransform>().sizeDelta.y / 4f;
    }

    public void PointerDown(Vector2 pos)
    {
        JoystickImage.enabled = true;
        JoystickBgImage.enabled = true;

        joystickMove.transform.position = pos;
        joystickBGMove.transform.position = pos;
        joystickTouchPosMove = pos;
    }
  
    public void Drag(Vector2 pointerEventData)
    {
        Vector2 dragPos = pointerEventData;
        joystickVecMove = (dragPos - joystickTouchPosMove).normalized;

        float joystickDistMove = Vector2.Distance(dragPos, joystickTouchPosMove);

        if (joystickDistMove < joystickRadiusMove)
            joystickMove.transform.position = joystickTouchPosMove + joystickVecMove * joystickDistMove;
        else
            joystickMove.transform.position = joystickTouchPosMove + joystickVecMove * joystickRadiusMove;
    }

    public void PointerUp()
    {
        joystickVecMove = Vector2.zero;
        joystickMove.transform.position = joystickOriginalPosMove;
        joystickBGMove.transform.position = joystickOriginalPosMove;

        JoystickImage.enabled = false;
        JoystickBgImage.enabled = false;
    }

    #region MOUSE
    public void PointDownWithMouse()
    {
        JoystickImage.enabled = true;
        JoystickBgImage.enabled = true;

        joystickMove.transform.position = Input.mousePosition;
        joystickBGMove.transform.position = Input.mousePosition;
        joystickTouchPosMove = Input.mousePosition;
    }

    public void DragWithMouse(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        joystickVecMove = (dragPos - joystickTouchPosMove).normalized;

        float joystickDistMove = Vector2.Distance(dragPos, joystickTouchPosMove);

        if (joystickDistMove < joystickRadiusMove)
            joystickMove.transform.position = joystickTouchPosMove + joystickVecMove * joystickDistMove;
        else
            joystickMove.transform.position = joystickTouchPosMove + joystickVecMove * joystickRadiusMove;
    }
    #endregion
}