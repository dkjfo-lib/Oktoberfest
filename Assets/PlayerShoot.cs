using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Weapon[] allWeapons;
    public int currentWeaponId = 0;
    Weapon currentWeapon => allWeapons[currentWeaponId];
    [Space]
    public Transform gunpoint;

    bool canShoot = true;

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            currentWeaponId++;
            if (currentWeaponId > allWeapons.Length - 1)
                currentWeaponId = 0;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            currentWeaponId--;
            if (currentWeaponId < 0)
                currentWeaponId = allWeapons.Length - 1;
        }
        if (canShoot && currentWeapon.HasPrimary && Input.GetMouseButton(0))
        {
            StartCoroutine(Shoot(currentWeapon.primaryFire));
        }
        if (canShoot && currentWeapon.HasSecondary && Input.GetMouseButton(1))
        {
            StartCoroutine(Shoot(currentWeapon.secondaryFire));
        }
    }

    private IEnumerator Shoot(ShotInfo shotInfo)
    {
        canShoot = false;
        foreach (var projectile in shotInfo.projectiles)
        {
            var newProjectile = Instantiate(projectile, gunpoint.transform.position, transform.rotation);
            newProjectile.FactionToHit = Faction.OpponentTeam;
            newProjectile.transform.forward +=
                newProjectile.transform.right * shotInfo.GetRandomDeviation +
                newProjectile.transform.up * shotInfo.GetRandomDeviation;
        }

        yield return new WaitForSeconds(1 / shotInfo.shotsPerSecond);
        canShoot = true;
    }
}

[System.Serializable]
public struct ShotInfo
{
    public GunShot[] projectiles;
    [Tooltip("value of 1 generates deviation of up to 45 degrees from aim")]
    [Range(0, 1)] public float accuracity;
    public float shotsPerSecond;

    public ShotInfo(float accuracity, float shotsPerSecond) : this()
    {
        this.accuracity = accuracity;
        this.shotsPerSecond = shotsPerSecond;
    }

    public float GetDeviationValue => 1 - accuracity;
    public float GetRandomDeviation => Random.Range(-GetDeviationValue, GetDeviationValue);
}