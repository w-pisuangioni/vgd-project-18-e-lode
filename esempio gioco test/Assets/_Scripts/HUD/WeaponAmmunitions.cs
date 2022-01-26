using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponAmmunitions : MonoBehaviour
{
    //Lo script gestisce la quantità di munizioni nell'HUD.
    public EquippedWeapon weapon;
    public Text testoCanvas; //var che gestisce il testo munizioni

    // Use this for initialization
    void Start()
    {
        testoCanvas = GetComponent<Text>(); //prendo il component Text
    }

    // Update is called once per frame
    void Update()
    {
        weapon = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().equippedWeapon;
        switch (gameObject.name)
        {
            case "Munizioni":
                testoCanvas.text = weapon.getCurAmmo() + "/" + weapon.getMaxAmmo() + " l " + weapon.getCaricatori();
                break;
            case "Arma":
                testoCanvas.text = weapon.name;
                break;
        }
    }
}
