using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
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
        horizontalMove = Input.GetAxisRaw("P1.Horizontal") * runSpeed;
        verticalMove = Input.GetAxisRaw("P1.Vertical") * runSpeed;

        if (Input.GetButtonDown("P1.Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("P1.Dash"))
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
