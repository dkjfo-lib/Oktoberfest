using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerHittable : MonoBehaviour, IHittable
{
    public float hp = 3;
    public Faction faction = Faction.AlwaysHit;
    public Faction Faction => faction;
    [Space]
    public ClampedValue Addon_HPValueOutput;
    public ParticleSystem addon_onBodyPartDestroyParticles;
    public NavMeshAgent addon_BotNavMesh;
    [Space]
    public Pipe_SoundsPlay Pipe_SoundsPlay;
    public ClipsCollection sounds_hit;
    public ClipsCollection sounds_bodyPartDestroed;

    private void Awake()
    {
        if (Addon_HPValueOutput != null) Addon_HPValueOutput.maxValue = hp;
        if (Addon_HPValueOutput != null) Addon_HPValueOutput.value = hp;
    }

    public void GetHit(Hit hit)
    {
        hp -= hit.damage;
        if (Addon_HPValueOutput != null) Addon_HPValueOutput.value = hp;
        if (hp <= 0)
        {
            Pipe_SoundsPlay?.AddClip(new PlayClipData(sounds_bodyPartDestroed, transform.position));
            Die();
        }
        else
        {
            Pipe_SoundsPlay?.AddClip(new PlayClipData(sounds_hit, transform.position));
            if (addon_BotNavMesh != null)
            {
                addon_BotNavMesh.SetDestination(PlayerSinglton.PlayerPosition);
            }
        }
    }

    private void Die()
    {
        if (addon_onBodyPartDestroyParticles != null)
        {
            var praticles = Instantiate(addon_onBodyPartDestroyParticles, transform.position, Quaternion.identity);
            Destroy(praticles.gameObject, 3);
        }

        Destroy(transform.parent.parent.gameObject);
    }
}
