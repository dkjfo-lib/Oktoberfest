using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool onGround = false;

    private void OnTriggerEnter(Collider collision)
    {
        onGround = true;
    }

    private void OnTriggerStay(Collider collision)
    {
        onGround = true;
    }

    private void OnTriggerExit(Collider collision)
    {
        onGround = false;
    }
}
