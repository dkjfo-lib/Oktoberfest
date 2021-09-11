using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotMovement : MonoBehaviour, IBotMovement
{
    public float courseUpdateTime = .1f;
    [Space]
    public BotSight BotSight;
    [Space]


    public bool inAttack = true;
    public bool InDistanceForAttack => BotSight.CanSee ?
        BotSight.distanceToPlayer <= NavMeshAgent.stoppingDistance :
        false;
    public bool IsMoving => NavMeshAgent.velocity.sqrMagnitude > 4;

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
            yield return new WaitUntil(() => inAttack && BotSight.CanSee);
            while (inAttack && BotSight.CanSee)
            {
                if (BotSight.distanceToPlayer > NavMeshAgent.stoppingDistance)
                {
                    NavMeshAgent.SetDestination(PlayerSinglton.PlayerPosition);
                }
                yield return new WaitForSeconds(courseUpdateTime);
            }
        }
    }
}

public interface IBotMovement
{
    bool InDistanceForAttack { get; }
    bool IsMoving { get; }
}