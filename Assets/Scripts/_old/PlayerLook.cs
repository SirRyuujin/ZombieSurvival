using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public LookJoystick lookJoystickScript;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(lookJoystickScript.joystickVec.y != 0)
        {
            //rb.velocity = new Vector2(lookJoystickScript.joystickVec.x * speed, lookJoystickScript.joystickVec.y * speed);

            //character looks at the direction he is moving
            transform.rotation = Quaternion.LookRotation(Vector3.forward, lookJoystickScript.joystickVec);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}