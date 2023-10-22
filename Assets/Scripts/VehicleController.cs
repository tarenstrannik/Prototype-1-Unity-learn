using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class VehicleController : MonoBehaviour
{

    private float speed = 25.0f;

    private void Update()
    {
        //Move vehicle forward
        
        transform.Translate(Vector3.forward*Time.deltaTime*speed);
        
       
    }
}
