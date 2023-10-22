using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController2 : MonoBehaviour
{

    private float speed =25.0f;
    private float turnSpeed=25.0f;

    private float horizontalInput;
    private float forwardInput;
    public Camera thirdPersonCamera;
    public Camera firstPersonCamera;

    private void Start()
    {
        firstPersonCamera.gameObject.SetActive(false);
        thirdPersonCamera.gameObject.SetActive(true);
    }
    private void Update()
    {
        //Move vehicle forward
        horizontalInput = Input.GetAxis("Horizontal2");
        forwardInput = Input.GetAxis("Vertical2");

        transform.Translate(Vector3.forward*Time.deltaTime*speed* forwardInput);
        
        transform.Rotate(Vector3.up, Time.deltaTime * horizontalInput * turnSpeed);

        if(Input.GetButtonDown("ToggleView2"))
        {
            firstPersonCamera.gameObject.SetActive(!firstPersonCamera.gameObject.activeSelf);
            thirdPersonCamera.gameObject.SetActive(!thirdPersonCamera.gameObject.activeSelf);

        }
    }
}
