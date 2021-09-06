using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSight : MonoBehaviour
{
    public float radius = 5;
    public float innerRadius = 1.2f;

    public PlayerSinglton thePlayer;
    public Vector3 vectorToPlayer => thePlayer.transform.position - transform.position;
    public Vector3 directionToPlayer => vectorToPlayer.normalized;
    public float distanceToPlayer => vectorToPlayer.magnitude;

    public Transform hitted;
    public bool canSee = false;

    void Start()
    {
        thePlayer = null;
        GetComponent<CircleCollider2D>().radius = radius;

        StartCoroutine(LookAtPlayer());
    }

    IEnumerator LookAtPlayer()
    {
        while (true)
        {
            yield return new WaitUntil(() => thePlayer != null);
            var hit = Physics2D.Raycast(transform.position + directionToPlayer * innerRadius, directionToPlayer, distanceToPlayer - innerRadius + .75f, Layers.CharactersAndGround);

            hitted = hit.transform;
            if (hit.transform != null)
            {
                canSee = hit.transform.GetComponent<PlayerSinglton>() != null;
            }
            else
            {
                canSee = false;
            }

            yield return new WaitForSeconds(.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerSinglton>();
        if (player == null) return;

        thePlayer = player;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerSinglton>();
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
            Gizmos.DrawLine(transform.position + directionToPlayer * innerRadius, transform.position + directionToPlayer * (distanceToPlayer - innerRadius + .75f));
        }
    }
}
