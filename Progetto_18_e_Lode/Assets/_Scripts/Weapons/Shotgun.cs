using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : EquippedWeapon
{

    void Start()
    {
        audios = GetComponents<AudioSource>();
        maxAmmo = 5;//munizioni massime
        MaxAmmo();
        maxCaricatori = 6;
        MaxCaricatori();
        damage = 50f;//danno
        fireRatio = 2f;
        isOwned = false;
        rangeWeapon = 40f;
    }

    void Update()
    {
    }
}
