using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour {//gestisce la lista dei drop di ogni mostro
    public List<GameObject> pickups = new List<GameObject>();
    private int randomPickup;//variabile di controllo, inutile
    private GameObject spawnedItem;
    public float rotationSpeed;
    
	void Start ()
    {
        pickups.Add((GameObject)Resources.Load("Weapons/_PrefabPickups/GunPickup"));
        pickups.Add((GameObject)Resources.Load("Weapons/_PrefabPickups/AssaultRiflePickup"));
        pickups.Add((GameObject)Resources.Load("Weapons/_PrefabPickups/ShotgunPickup"));
        pickups.Add((GameObject)Resources.Load("Weapons/_PrefabPickups/FirstAidPickup"));
        spawnedItem = RandomSpawn();
        rotationSpeed = 180f;
    }
	
	void Update ()
    {
        Rotate();//fa ruotare il gameObject
    }
    public void Rotate()
    {
        if (this.tag == "Pickup" || this.tag == "Weapon")//da lasciare
        {
            transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
        }
    }
    public GameObject RandomSpawn()
    {
        randomPickup = Random.Range(0, pickups.Count);
        return pickups[randomPickup];//sceglie un elemento a caso nella lista (da 0 a n-1)
    }
    public GameObject getSpawnedItem()
    {
        return this.spawnedItem;
    }
}
