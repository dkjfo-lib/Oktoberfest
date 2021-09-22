using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMeshAnimator : MonoBehaviour
{
    public Animator Animator;

    public IBotMovement BotMovement;
    public BotSight BotSight;

    bool isMoving = false;
    bool isAlerted = false;

    private void Start()
    {
        BotMovement = transform.parent.GetComponent<IBotMovement>();
    }

    public void Attack()
    {
        Animator.SetTrigger("attack");
    }

    private void Update()
    {
        isMoving = BotMovement.IsMoving;
        isAlerted = BotSight.EnemyIsNear;

        Animator.SetBool("isMoving", isMoving);
        Animator.SetBool("isAlerted", isAlerted);
    }
}
