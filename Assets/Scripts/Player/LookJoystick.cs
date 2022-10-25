using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LookJoystick : MonoBehaviour
{
    public GameEvent OnTryFirePrimaryWeaponEvent;

    public GameObject joystick;
    public GameObject joystickBG;
    public Image JoystickImage;
    public Image JoystickBgImage;
    public Vector2 joystickVec;
    private Vector2 joystickTouchPos;
    private Vector2 joystickOriginalPos;
    private float joystickRadius;
    public bool IsDragging = false;

    public Vector2 lastDragPosition;

    private void Start()
    {
        joystickOriginalPos = joystickBG.transform.position;
        joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 2.5f;
    }

    private void Update()
    {
        if (IsDragging)
        {
            joystickVec = (lastDragPosition - joystickTouchPos).normalized;

            float joystickDist = Vector2.Distance(lastDragPosition, joystickTouchPos);

            if (joystickDist < joystickRadius)
            {
                joystick.transform.position = joystickTouchPos + joystickVec * joystickDist;
            }
            else
            {
                joystick.transform.position = joystickTouchPos + joystickVec * joystickRadius;
            }

            if (joystickDist >= joystickRadius)
                OnTryFirePrimaryWeaponEvent.Raise();
        }
    }

    public void PointerDown(Vector2 pos)
    {
        IsDragging = true;

        JoystickImage.enabled = true;
        JoystickBgImage.enabled = true;

        joystick.transform.position = pos;
        joystickBG.transform.position = pos;
        joystickTouchPos = pos;
    }

    public void Drag(Vector2 pointerEventData)
    {
        lastDragPosition = pointerEventData;
        joystickVec = (lastDragPosition - joystickTouchPos).normalized;

        float joystickDist = Vector2.Distance(lastDragPosition, joystickTouchPos);

        if (joystickDist < joystickRadius)
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickDist;
        }
        else
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickRadius;
        }

        if (joystickDist >= joystickRadius)
            OnTryFirePrimaryWeaponEvent.Raise();
    }

    public void PointerUp()
    {
        IsDragging = false;

        joystickVec = Vector2.zero;
        joystick.transform.position = joystickOriginalPos;
        joystickBG.transform.position = joystickOriginalPos;

        JoystickImage.enabled = false;
        JoystickBgImage.enabled = false;
    }
}