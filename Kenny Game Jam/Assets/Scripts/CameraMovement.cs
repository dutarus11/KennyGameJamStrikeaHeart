using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
   This script manages the camera's movement & position
*/
public class CameraMovement : MonoBehaviour
{
    
    public Transform cameraPos;

    
    void Update()
    {
        transform.position = cameraPos.position; 
    }
}
