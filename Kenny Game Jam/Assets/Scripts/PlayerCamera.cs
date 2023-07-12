using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public float sensX, sensY;

    public Transform orientation;

    float xRotation, yRotation;
    
    void Start()
    {
        Locked();
    }

    
    void Update()
    {
        MouseInput();
    }

    void Locked()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void MouseInput()
    {
       
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensX;
        yRotation += mouseX;                                                               
        xRotation -= mouseY;
        Clamped();                               
    }

    void Clamped()
    {
        xRotation = Mathf.Clamp(xRotation, -90f, 90);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
