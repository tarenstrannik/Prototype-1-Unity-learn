using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePropeller : MonoBehaviour
{
    private float rotationSpeed = 30f;

    private void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
