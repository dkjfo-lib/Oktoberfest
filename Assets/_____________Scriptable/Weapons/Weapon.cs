using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "My/Weapon")]
public class Weapon : ScriptableObject
{
    public string weaponName;
    public ShotInfo primaryFire;
    public ShotInfo secondaryFire;

    public bool HasPrimary => primaryFire.bursts.Length > 0;
    public bool HasSecondary => secondaryFire.bursts.Length > 0;
}
