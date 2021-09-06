using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    public PlayerSinglton playerPrefab;
    [Space]
    public bool wasWithBosses = false;
    public string normalLevel;
    public string bossOnlyLevel;

    void Start()
    {
        StartCoroutine(RespawnPlayer());
    }

    IEnumerator RespawnPlayer()
    {
        yield return new WaitUntil(() => PlayerSinglton.thePlayer == null);
        Time.timeScale = .5f;
        yield return new WaitForSeconds(1);
        Time.timeScale = 1;

        if (wasWithBosses)
        {
            SceneManager.LoadScene(bossOnlyLevel);
        }
        else
        {
            SceneManager.LoadScene(normalLevel);
        }
    }
}
