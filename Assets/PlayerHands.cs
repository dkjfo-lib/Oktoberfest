using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHands : MonoBehaviour
{
    public Animator Animator;

    public void AnimShoot()
    {
        Animator.SetTrigger("shoot");
    }

    public void AnimReload()
    {
        Animator.SetTrigger("reload");
    }

    public void AnimChangegun(int newId)
    {
        Animator.SetInteger("gunId", newId);
        Animator.SetTrigger("changeGun");
    }
}
