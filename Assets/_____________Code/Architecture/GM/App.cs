using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
    static App app;

    private void Awake()
    {
        if (app != null) Destroy(gameObject);

        app = this;
        DontDestroyOnLoad(gameObject);
    }
}
