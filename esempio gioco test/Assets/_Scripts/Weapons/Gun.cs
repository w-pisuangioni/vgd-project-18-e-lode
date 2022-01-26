using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : EquippedWeapon {
    
	void Start () {
        audios = GetComponents<AudioSource>();
        maxAmmo = 10;//munizioni massime
        MaxAmmo();
        maxCaricatori = 2;
        MaxCaricatori();
        damage = 5f;//danno
        isOwned = true;
    }
	
	void Update ()
    {
        Rotate();
    }
}
