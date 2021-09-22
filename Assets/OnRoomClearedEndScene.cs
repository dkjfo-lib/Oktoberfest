using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnRoomClearedEndScene : MonoBehaviour
{
    public string nextSceneName;
    public float delay = 5;
    [Space]
    public Room room;

    void Start()
    {
        StartCoroutine(OnRoomCleared());
    }

    IEnumerator OnRoomCleared()
    {
        yield return new WaitUntil(() => room.done);
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextSceneName);
    }
}
