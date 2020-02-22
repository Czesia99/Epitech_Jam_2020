using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
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
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Dash"))
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
