using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSight : MonoBehaviour, IBotSight
{
    public float radius = 5;
    public float innerRadius = 1.2f;

    public PlayerSinglton thePlayer;
    // "Vector3.up * 1" due to error in character's y coordinate
    public Vector3 vectorToPlayer => thePlayer.transform.position + Vector3.up * 1 - transform.position;
    public Vector3 directionToPlayer => vectorToPlayer.normalized;
    public float distanceToPlayer => vectorToPlayer.magnitude;

    public Transform hitted;
    public bool canSee = false;

    public bool CanSee => canSee;
    public bool EnemyIsNear => thePlayer != null;

    void Start()
    {
        thePlayer = null;
        GetComponent<SphereCollider>().radius = radius;

        StartCoroutine(LookAtPlayer());
    }

    IEnumerator LookAtPlayer()
    {
        while (true)
        {
            yield return new WaitUntil(() => thePlayer != null);

            Vector3 origin = transform.position + directionToPlayer * innerRadius;
            Vector3 direction = directionToPlayer;
            RaycastHit raycastHit;
            float castRadius = distanceToPlayer - innerRadius + .75f;
            var hit = Physics.Raycast(origin, direction, out raycastHit, castRadius, Layers.CharactersAndGround);

            if (hit)
            {
                hitted = raycastHit.transform;
                if (raycastHit.transform != null)
                {
                    canSee = raycastHit.transform.GetComponent<PlayerSinglton>() != null;
                }
                else
                {
                    canSee = false;
                }
            }
            else
            {
                canSee = false;
            }

            yield return new WaitForSeconds(.5f);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!PlayerSinglton.IsGood) return;

        var player = collision.transform.parent.parent.
            GetComponent<PlayerSinglton>();
        if (player == null) return;

        thePlayer = player;
    }

    private void OnTriggerExit(Collider collision)
    {
        if (!PlayerSinglton.IsGood) return;

        var player = collision.transform.parent.parent.
            GetComponent<PlayerSinglton>();
        if (player == null) return;

        thePlayer = null;
        canSee = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, innerRadius);

        if (thePlayer != null)
        {
            Gizmos.color = Color.red;

            Vector3 origin = transform.position + directionToPlayer * innerRadius;
            float castDistance = distanceToPlayer - innerRadius + .75f;
            Vector3 end = transform.position + directionToPlayer * castDistance;
            Gizmos.DrawLine(origin, end);
        }
    }
}

public interface IBotSight
{
    bool CanSee { get; }
    bool EnemyIsNear { get; }
}