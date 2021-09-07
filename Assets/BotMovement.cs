using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotMovement : MonoBehaviour
{
    public float courseUpdateTime = .1f;

    NavMeshAgent NavMeshAgent;

    void Start()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();

        StartCoroutine(KeepWalking());
    }

    IEnumerator KeepWalking()
    {
        while (true)
        {
            yield return new WaitUntil(() => PlayerSinglton.IsGood);
            while (PlayerSinglton.IsGood)
            {
                NavMeshAgent.SetDestination(PlayerSinglton.PlayerPosition);
                yield return new WaitForSeconds(courseUpdateTime);
            }
        }
    }
}
