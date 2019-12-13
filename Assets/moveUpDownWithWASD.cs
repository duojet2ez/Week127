using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveUpDownWithWASD : MonoBehaviour
{
    public float speed;

    Vector2 currentRotation;

    private void Awake()
    {
        cameraRotator.onRotate += handleRotationEvent;
    }

    private void handleRotationEvent(int desiredRotation)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputVect = new Vector3();
        inputVect.x = Input.GetAxis("Horizontal");
        inputVect.y = Input.GetAxis("Vertical");
        transform.position += inputVect * speed * Time.deltaTime;
        
        
    }
}
