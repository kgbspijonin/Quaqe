using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour
{
    Camera camera;
    float strafeSpeed = 0.0707f;
    float forwardSpeed = 0.1f;

    void Start()
    {
        transform.position = new Vector3(0, 2, 0);
        camera = Camera.main;
        camera.transform.position = transform.position + new Vector3(0, 0.75f, 0);
        camera.transform.parent = transform;
    }

    void FixedUpdate()
    {
        var horizontalInput = Input.GetAxis("Horizontal") * strafeSpeed;
        var verticalInput = Input.GetAxis("Vertical") * forwardSpeed;
        Vector3 input = new Vector3(horizontalInput, 0, verticalInput);
        transform.position += input;
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");
        //TODO
    }
}
