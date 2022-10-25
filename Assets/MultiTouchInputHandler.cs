using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiTouchInputHandler : MonoBehaviour
{
    private const int SCREEN_SPLIT_CORD = 900;
    private int _screenSplitCord;

    [Header("References")]
    public MoveJoystick MoveJoystickReference;
    public LookJoystick RotationJoystickReference;

    [Header("Preview")]
    public bool IsRotationJoyInstalled = false;
    public int RotationJoyID = -1;
    public bool IsMovementJoyInstalled = false;
    public int MoveJoyID = -1;
    public List<TouchLocation> Touches = new List<TouchLocation>();

    private void Awake()
    {
        _screenSplitCord = Screen.height / 2;
    }

    private void Update()
    {
        TryHandleTouchInput();
    }

    private void TryHandleTouchInput()
    {
        int i = 0;
        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);

            if (t.phase == TouchPhase.Began)
                HandleBeganPhase(t,i);
            else if (t.phase == TouchPhase.Ended)
                HandleEndedPhase(i);
            else if (t.phase == TouchPhase.Moved)
                HandleMovedPhase(t,i);
            i++;
        }
    }

    private void HandleBeganPhase(Touch t,int i)
    {
        // ============= LEFT JOY - MOVEMENT
        if (t.position.x <= SCREEN_SPLIT_CORD)
        {
            if (!IsMovementJoyInstalled)
            {
                IsMovementJoyInstalled = true;
                MoveJoyID = i;
                MoveJoystickReference.PointerDown(t.position);
            }
            else
                return; // ignore
        }
        // ============ RIGHT JOY - ROTATION
        else
        {
            if (!IsRotationJoyInstalled)
            {
                IsRotationJoyInstalled = true;
                RotationJoyID = i;
                RotationJoystickReference.PointerDown(t.position);
            }
            else
                return; // ignore
        }
    }

    private void HandleEndedPhase(int i)
    {
        if (IsMovementJoyInstalled && MoveJoyID == i)
        {
            MoveJoystickReference.PointerUp();
            IsMovementJoyInstalled = false;
        }
        else if (IsRotationJoyInstalled && RotationJoyID == i)
        {
            RotationJoystickReference.PointerUp();
            IsRotationJoyInstalled = false;
        }
    }

    private void HandleMovedPhase(Touch t, int i)
    {
        if (IsMovementJoyInstalled && MoveJoyID == i)
        {
            MoveJoystickReference.Drag(t.position);
        }
        else if (IsRotationJoyInstalled && RotationJoyID == i)
        {
            RotationJoystickReference.Drag(t.position);
        }
    }
}