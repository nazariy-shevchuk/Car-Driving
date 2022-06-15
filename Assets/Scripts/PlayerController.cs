using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20f;
    private float turnSpeed = 65f;
    private float horizontalInput;
    private float forwardInput;

    // Update is called once per frame
    void Update()
    {
        // Get player input
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // Make the vehicle move forward and backward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        // Make the vehicle turn left and right
        if (forwardInput != 0)
        {
            if (forwardInput > 0)
                transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
            else
                transform.Rotate(Vector3.up, -turnSpeed * horizontalInput * Time.deltaTime);
        } 
    }
}
