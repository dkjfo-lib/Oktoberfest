using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string nextSceneName;

    private void Start()
    {
        MouseLocker.Unlock();
    }

    public void Change()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
