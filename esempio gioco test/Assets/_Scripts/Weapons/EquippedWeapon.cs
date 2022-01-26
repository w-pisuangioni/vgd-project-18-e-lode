using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class EquippedWeapon : MonoBehaviour {
    //Variabili Arma
    public int curAmmo;//munizioni attuali
    protected int maxAmmo;//munizioni massime
    public int caricatori;
    protected int maxCaricatori;
    public float damage;
    public bool isOwned;
    //Audio
    public AudioSource[] audios;
    

    //tutorial
    //public GameObject gun, assaultRifle;
    //public bool weaponActive;

    void Start () {
        MaxAmmo();
        MaxCaricatori();
    }

    void Update()
    {
    }

    //Get() e Set()
    public AudioSource getSparo()
    {
        return audios[0];
    }
    public void setSparo(AudioSource sound)
    {
        this.audios[0] = sound;
    }
    public AudioSource getReload()
    {
        return audios[1];
    }
    public void setReload(AudioSource sound)
    {
        this.audios[1] = sound;
    }
    public AudioSource getScarica()
    {
        return audios[2];
    }
    public void setEmpty(AudioSource sound)
    {
        this.audios[2] = sound;
    }
    public int getCurAmmo()
    {
        return this.curAmmo;
    }
    public void setCurAmmo(int ammo)
    {
        this.curAmmo = ammo;
    }
    public int getMaxAmmo()
    {
        return this.maxAmmo;
    }
    public void setMaxAmmo(int ammo)
    {
        this.maxAmmo = ammo;
    }
    public int getCaricatori()
    {
        return this.caricatori;
    }
    public void setCaricatori(int caric)
    {
        this.caricatori = caric;
    }
    public int getMaxCaricatori()
    {
        return this.maxCaricatori;
    }
    public void setMaxCaricatori(int caric)
    {
        this.maxCaricatori = caric;
    }
    public float getDamage()
    {
        return this.damage;
    }
    public void setDamage(float dmg)
    {
        this.damage = dmg;
    }
    public EquippedWeapon getEquippedWeapon()
    {
        return this;
    }
    
    //Metodi utili
    public void Rotate()
    {
        if (this.tag == "Pickup")
            transform.Rotate(new Vector3(Time.deltaTime * 0, 2, 0));
    }
    public void DecreaseAmmo()//decrementa contatore munizioni
    {
        curAmmo--;  
    }
    public void DecreaseCaricatori()
    {
        if(caricatori > 0)
            caricatori -= 1;
    }
    public void MaxAmmo()
    {
        curAmmo = maxAmmo;
    }
    public void MaxCaricatori()
    {
        caricatori = maxCaricatori;
    }
    public void setEquippedWeapon(EquippedWeapon wpn)
    {
        setCurAmmo(wpn.getCurAmmo());
        setMaxAmmo(wpn.getMaxAmmo());
        setCaricatori(wpn.getCaricatori());
        setMaxCaricatori(wpn.getMaxCaricatori());
        setDamage(wpn.getDamage());
    }
    
}
