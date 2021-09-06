using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GunShot projectile;
    public float primariShootsPerSecond = 4;
    bool canShootPrimary = true;
    [Space]
    public GunShot projectileSecondary;
    public float secondaryShootsPerSecond = 4;
    [Space]
    public SpriteRenderer gunpoint;

    void Update()
    {
        if (canShootPrimary && Input.GetMouseButton(0))
        {
            StartCoroutine(ShootPrimary());
        }
        if (canShootPrimary && Input.GetMouseButton(1))
        {
            StartCoroutine(ShootSecondary());
        }
    }

    private IEnumerator ShootPrimary()
    {
        canShootPrimary = false;
        var newShot = Instantiate(projectile, gunpoint.transform.position, transform.rotation);
        newShot.FactionToHit = Faction.OpponentTeam;

        gunpoint.color = Color.white;
        yield return new WaitForSeconds(Mathf.Min(1 / primariShootsPerSecond, .05f));
        gunpoint.color = new Color(0, 0, 0, 0);

        yield return new WaitForSeconds(1 / primariShootsPerSecond);
        canShootPrimary = true;
    }

    private IEnumerator ShootSecondary()
    {
        canShootPrimary = false;
        var newShot = Instantiate(projectileSecondary, gunpoint.transform.position, transform.rotation);
        newShot.FactionToHit = Faction.OpponentTeam;

        gunpoint.color = Color.white;
        yield return new WaitForSeconds(Mathf.Min(1 / secondaryShootsPerSecond, .05f));
        gunpoint.color = new Color(0, 0, 0, 0);

        yield return new WaitForSeconds(1 / secondaryShootsPerSecond);
        canShootPrimary = true;
    }
}
