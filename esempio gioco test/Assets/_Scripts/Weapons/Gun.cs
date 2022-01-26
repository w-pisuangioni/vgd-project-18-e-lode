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
        maxCaricatori = 2;
        MaxCaricatori();
        damage = 10f;//danno
        fireRatio = 0.3f;
        isOwned = true;
        rangeWeapon = 80f;
    }

    void Update()
    {
    }
}