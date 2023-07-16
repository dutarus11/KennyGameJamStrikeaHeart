using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

/*
   This script manages the player's movement 
*/
public class PlayerMovement : MonoBehaviour
{
    
    [Header("Movement")]

    [SerializeField] Rigidbody rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float groundDrag;
    [SerializeField] private Transform orientation;
    [SerializeField] private float horizontalInput, verticalInput;
    [SerializeField] private Vector3 moveDirection;

    [Header("Keybinds")]
    
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Verification")]
    
    [SerializeField] private float playerHeight;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private bool grounded;

    [Header("Jumping Movement & Parameters")]
    
    [SerializeField]private float jumpForce = 8.0f;
    [SerializeField]private float gravity = 30.0f;
    [SerializeField] private float jumpCoolDown;
    [SerializeField] private float airMultiply;
    [SerializeField] private bool jumpReadiness = false;
    [SerializeField] private bool canJump = true;

    private float num = 0f, num1 = 10f, num2 = 0.5f, num3 = 0.2f;
    
    void Start()
    {
        StartPoint();
    }
    void Update()
    {
        MovementInput();
        Grounded();       
        SpeedControl();
    }

    void FixedUpdate()
    {
        Movement();    
    }

    void StartPoint()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        jumpReadiness = true;
    }
    void MovementInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //jumping
        if (Input.GetKey(jumpKey) && jumpReadiness && grounded)
        {
            jumpReadiness = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCoolDown);
        }
    }

    void Movement() 
    {
        //calculate moving direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        
        if (grounded == true)//on the ground
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * num1, ForceMode.Force);
        }
        else if(grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * num1 * airMultiply, ForceMode.Force);
        }
    }

    void Grounded()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * num2 + num3, whatIsGround);
        
        //Manages Dragging Function 
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = num;
        }
    }

    void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, num, rb.velocity.z);

        //limit the velocity as needed 
        if (flatVelocity.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }

    void Jump()
    {
        //reset vertical velicity 
        rb.velocity = new Vector3(rb.velocity.x, num, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    void ResetJump()
    {
        jumpReadiness = true;
    }

}
