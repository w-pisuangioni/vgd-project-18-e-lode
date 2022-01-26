using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Pickup_Litle : MonoBehaviour {//gestisce la lista dei drop di ogni mostro
    public List<GameObject> pickups_Litle = new List<GameObject>();
    private int randomPickup_Litle;//variabile di controllo, inutile
    private GameObject spawnedItem_Litle;
    public float rotationSpeed_Litle;
    
	void Start ()
    {
        pickups_Litle.Add((GameObject)Resources.Load("Weapons/_PrefabPickups/GunPickup_Lite"));
        pickups_Litle.Add((GameObject)Resources.Load("Weapons/_PrefabPickups/AssaultRiflePickup_Litle"));
        pickups_Litle.Add((GameObject)Resources.Load("Weapons/_PrefabPickups/ShotgunPickup_Litle"));
        pickups_Litle.Add((GameObject)Resources.Load("Weapons/_PrefabPickups/FirstAidPickup_Litle"));
        spawnedItem_Litle = RandomSpawn_Litle();
        rotationSpeed_Litle = 180f;
    }
	
	void Update ()
    {
        Rotate_Litle();//fa ruotare il gameObject
    }
    public void Rotate_Litle()
    {
        if (this.tag == "Pickup" || this.tag == "Weapon_Lite")//da lasciare
        {
            transform.Rotate(new Vector3(0, rotationSpeed_Litle * Time.deltaTime, 0));
        }
    }
    public GameObject RandomSpawn_Litle()
    {
        randomPickup_Litle = Random.Range(0, pickups_Litle.Count);
        return pickups_Litle[randomPickup_Litle];//sceglie un elemento a caso nella lista (da 0 a n-1)
    }
    public GameObject getSpawnedItem()
    {
        return this.spawnedItem_Litle;
    }
}
