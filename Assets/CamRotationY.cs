using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotationY : MonoBehaviour
{
    public static float RotationY { get; private set; } = 0;

    public float rotationSpeed = 2;

    void FixedUpdate()
    {
        float addAngleY = Input.GetAxis("Mouse X") * rotationSpeed * Time.fixedTime;
        float newAngleY = transform.rotation.eulerAngles.y + addAngleY;
        RotationY = newAngleY;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, newAngleY, transform.rotation.eulerAngles.z);
    }
}
