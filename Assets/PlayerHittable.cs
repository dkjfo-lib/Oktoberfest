using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHittable : MonoBehaviour, IHittable
{
    public float hp = 3;
    public Faction faction = Faction.AlwaysHit;
    public Faction Faction => faction;
    [Space]
    public ClampedValue value;
    [Space]
    public bool isHead = false;
    public GameObject Headfull;
    public GameObject Headless;
    [Space]
    public ParticleSystem addon_onBodyPartDestroyParticles;
    [Space]
    public Pipe_SoundsPlay Pipe_SoundsPlay;
    public ClipsCollection sounds_hit;
    public ClipsCollection sounds_bodyPartDestroed;

    private void Awake()
    {
        if (value != null) value.maxValue = hp;
        if (value != null) value.value = hp;
    }

    public void GetHit(Hit hit)
    {
        hp -= hit.damage;
        if (value != null) value.value = hp;
        if (hp <= 0)
        {
            Pipe_SoundsPlay?.AddClip(new PlayClipData(sounds_bodyPartDestroed, transform.position));
            Die();
        }
        else
        {
            Pipe_SoundsPlay?.AddClip(new PlayClipData(sounds_hit, transform.position));
        }
    }

    private void Die()
    {
        if (Headless != null || Headfull != null)
        {
            var corpse = Instantiate(isHead ? Headless : Headfull, transform.position, Quaternion.identity);
            corpse.transform.localScale = new Vector3(transform.localScale.x, 1, 1);
        }

        if (addon_onBodyPartDestroyParticles != null)
        {
            var praticles = Instantiate(addon_onBodyPartDestroyParticles, transform.position, Quaternion.identity);
            Destroy(praticles.gameObject, 3);
        }

        Destroy(transform.parent.parent.gameObject);
    }
}
