using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    None,
    ONEHANDMELEE,
    TWOHANDMELEE,
    PISTOL,
    RIFLE,
    SHOTGUN,
    SNIPERRIFLE
}
public enum FireType
{
    SINGLE,
    MULTIPLE
}

public class WeaponHandler : MonoBehaviour
{
    public WeaponType weaponType;
    public FireType fireType;
   
}
