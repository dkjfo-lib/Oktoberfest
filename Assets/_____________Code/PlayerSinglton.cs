using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSinglton : MonoBehaviour
{
    public static bool IsGood => thePlayer != null;
    public static Vector3 PlayerPosition => thePlayer.transform.position;
    public static Vector3 PlayerDirection => thePlayer.transform.forward;
    static PlayerSinglton thePlayer;

    void Awake()
    {
        thePlayer = this;
    }
}
