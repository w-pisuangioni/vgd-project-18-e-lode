using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : EquippedWeapon
{

    void Start()
    {
        audios = GetComponents<AudioSource>();
        maxAmmo = 10;//munizioni massime
        MaxAmmo();
        maxCaricatori = 4;
        MaxCaricatori();
        damage = 20f;//danno
        fireRatio = 0.3f;
        isOwned = true;
        rangeWeapon = 80f;
    }

    void Update()
    {
    }
}