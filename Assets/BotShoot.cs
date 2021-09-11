using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotShoot : MonoBehaviour
{
    public Weapon weapons;
    public float shootDelay = .75f;
    [Space]
    public Pipe_SoundsPlay Pipe_SoundsPlay;
    public Transform gunpoint;
    [Space]
    public bool canShoot = true;
    [Space]
    public BotSight BotSight;
    public BotMovement BotMovement;
    public BotMeshAnimator BotMeshAnimator;

    void Update()
    {
        if (canShoot && BotSight.canSee && BotMovement.InDistanceForAttack)
        {
            StartCoroutine(ShootWeapon(weapons.primaryFire));
        }
    }

    IEnumerator ShootWeapon(ShotInfo shotInfo)
    {
        canShoot = false;
        BotMovement.inAttack = false;
        Vector3 shootDirection = BotSight.directionToPlayer;

        yield return new WaitForSeconds(shootDelay);

        Pipe_SoundsPlay.AddClip(new PlayClipData(shotInfo.fireSound, transform.position));
        BotMeshAnimator.Attack();

        foreach (var projectile in shotInfo.projectiles)
        {
            var newProjectile = Instantiate(projectile, gunpoint.transform.position, transform.rotation);
            newProjectile.transform.forward = shootDirection;
            newProjectile.FactionToHit = Faction.PlayerTeam;
            newProjectile.transform.forward +=
                newProjectile.transform.right * shotInfo.GetRandomDeviation +
                newProjectile.transform.up * shotInfo.GetRandomDeviation;

            if (shotInfo.delayBetweenProjectiles > 0)
                yield return new WaitForSeconds(shotInfo.delayBetweenProjectiles);
        }

        yield return new WaitForSeconds(1 / shotInfo.shotsPerSecond);
        canShoot = true;
        BotMovement.inAttack = true;
    }
}
