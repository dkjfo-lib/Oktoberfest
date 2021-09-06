using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSinglton : MonoBehaviour
{
    public static PlayerSinglton thePlayer;

    public bool NotActive = false;

    void Awake()
    {
        thePlayer = this;
    }
}
