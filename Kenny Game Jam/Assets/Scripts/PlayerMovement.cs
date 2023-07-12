using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

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
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else if(grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiply, ForceMode.Force);
        }
    }

    void Grounded()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        
        //Manages Dragging Function 
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

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
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    void ResetJump()
    {
        jumpReadiness = true;
    }

}
