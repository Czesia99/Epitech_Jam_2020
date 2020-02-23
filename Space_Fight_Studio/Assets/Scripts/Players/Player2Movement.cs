using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public PlayerController controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    bool jump = false;
    bool dash = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("P2.Horizontal") * runSpeed;
        verticalMove = Input.GetAxisRaw("P2.Vertical") * runSpeed;

        if (Input.GetButtonDown("P2.Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("P2.Dash"))
        {
            dash = true;
        }
    }

    void FixedUpdate() 
    {
        // controller.Move(horizontalMove * Time.fixedDeltaTime, jump, false);
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump, dash, verticalMove);
        jump = false;
        dash = false;
    }
}
