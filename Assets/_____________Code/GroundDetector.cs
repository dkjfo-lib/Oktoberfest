using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool onGround = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onGround = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        onGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onGround = false;
    }
}
