using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public MoveJoystick movementJoystick;
    // public LookJoystick lookJoystickScript;
    public float playerSpeed;
    private Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        // if(transform.position.y >= 11)
        // {
        //     transform.position = new Vector3(transform.position.x, 11, 0);
        // }
        // else if(transform.position.y <= -11)
        // {
        //     transform.position = new Vector3(transform.position.x, -11, 0);
        // }
        // else if(transform.position.x >= 12.5f)
        // {
        //     transform.position = new Vector3(12.5f, transform.position.y, 0);
        // }
        // else if(transform.position.x <= -12.5f)
        // {
        //     transform.position = new Vector3(-12.5f, transform.position.y, 0);
        // }
        // if(lookJoystickScript.joystickVec.y != 0)
        // {
        //     //rb.velocity = new Vector2(lookJoystickScript.joystickVec.x * speed, lookJoystickScript.joystickVec.y * speed);

        //     //character looks at the direction he is moving
        //     transform.rotation = Quaternion.LookRotation(Vector3.forward, lookJoystickScript.joystickVec);

        // }
        if (movementJoystick.joystickVecMove.y != 0)
        {
            rb.velocity = new Vector2(movementJoystick.joystickVecMove.x * playerSpeed, movementJoystick.joystickVecMove.y * playerSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    
}