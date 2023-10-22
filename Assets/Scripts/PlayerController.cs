using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horsePower;
    //private float speed =25.0f;
    private float curSpeed;
    private float turnSpeed=25.0f;
    private Rigidbody playerRb;
    private float horizontalInput;
    private float forwardInput;
    public Camera thirdPersonCamera;
    public Camera firstPersonCamera;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometer;
    [SerializeField] TextMeshProUGUI rpmText;

    private WheelCollider[] carWheels;

    private float rpm;
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        //playerRb.ResetCenterOfMass();
        //Debug.Log(playerRb.centerOfMass);
        playerRb.centerOfMass = transform.InverseTransformPoint(centerOfMass.transform.position); 
        //Debug.Log(playerRb.centerOfMass);

        carWheels = gameObject.GetComponentsInChildren<WheelCollider>();
    }
    private void Start()
    {
        firstPersonCamera.gameObject.SetActive(false);
        thirdPersonCamera.gameObject.SetActive(true);

    }
    private void FixedUpdate()
    {
        //Move vehicle forward
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        if (IsOnGround())
        {
            //transform.Translate(Vector3.forward*Time.deltaTime*speed* forwardInput);
            playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);
            transform.Rotate(Vector3.up, Time.deltaTime * horizontalInput * turnSpeed);
            curSpeed = playerRb.velocity.magnitude * 3.6f;
            speedometer.text = "Speed: " + (int)curSpeed + "kmh";
            rpm = ((int)curSpeed % 30) * 40;
            rpmText.text = "RPM: " + rpm;
        }
        if (Input.GetButtonDown("ToggleView"))
        {
            firstPersonCamera.gameObject.SetActive(!firstPersonCamera.gameObject.activeSelf);
            thirdPersonCamera.gameObject.SetActive(!thirdPersonCamera.gameObject.activeSelf);

        }

    }

    bool IsOnGround()
    {
        int countWheelsOnGround = 0;
        foreach(WheelCollider wc in carWheels)
        {
            if (wc.isGrounded) countWheelsOnGround++;
        }
        if (countWheelsOnGround == carWheels.Length)
        {
            return true;
        }
        return false;
    }
    
}
