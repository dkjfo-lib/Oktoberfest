using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotationX : MonoBehaviour
{
    public float rotationSpeed = 2;
    public float limitAngle = 80;

    void FixedUpdate()
    {
        float addAngleX = -Input.GetAxis("Mouse Y") * rotationSpeed * Time.fixedTime;
        
        float newAngleX;
        if (transform.rotation.eulerAngles.x > 180)
            newAngleX = Mathf.Clamp(transform.rotation.eulerAngles.x - 360 + addAngleX, -limitAngle, limitAngle);
        else
            newAngleX = Mathf.Clamp(transform.rotation.eulerAngles.x + addAngleX, -limitAngle, limitAngle);
        transform.rotation = Quaternion.Euler(newAngleX, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}
