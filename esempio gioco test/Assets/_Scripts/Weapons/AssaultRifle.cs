using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : EquippedWeapon {//Proprietà del fucile
    
    void Start()
    {
        audios = GetComponents<AudioSource>();
        maxAmmo = 20;//munizioni massime
        MaxAmmo();
        maxCaricatori = 4;
        MaxCaricatori();
        damage = 20f;//danno
        isOwned = false;
    }

    void Update ()
    {
        Rotate();
    }
    
}
