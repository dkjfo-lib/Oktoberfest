using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Pipe_SoundsPlay Pipe_SoundsPlay;
    public ClipsCollection Heal_Sound;

    private void Update()
    {
        transform.Rotate(Vector3.up, 90 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerSinglton.PlayerHealth.Heal(PlayerSinglton.PlayerHealth.maxhp);
        Pipe_SoundsPlay.AddClip(new PlayClipData(Heal_Sound, Camera.main.transform.position, Camera.main.transform));
        Destroy(gameObject);
    }
}
