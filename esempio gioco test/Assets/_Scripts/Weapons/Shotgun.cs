using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : EquippedWeapon {
    
	void Start () {
        audios = GetComponents<AudioSource>();
        maxAmmo = 5;//munizioni massime
        MaxAmmo();
        maxCaricatori = 10;
        MaxCaricatori();
        damage = 50f;//danno
        isOwned = false;
    }
	
	void Update ()
    {
        Rotate();
    }
    /*
    public AudioSource getReloadAmmo()
    {

    }
    public AudioSource getReloadPump()
    {

    }*/
}
