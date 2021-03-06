using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        Resize();
    }
    public void Rotate()
    {
        if (this.tag == "Pickup" || this.tag == "Weapon")//da lasciare
        {
            transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
        }
        StartCoroutine(DestroyPick());
    }
    public GameObject RandomSpawn()
    {
        randomPickup = Random.Range(0, pickups.Count);
        while (!Player.weaponList.Contains(pickups[randomPickup].name))//se non va bene
        {
            randomPickup = Random.Range(0, pickups.Count);
        }
        return pickups[randomPickup];//sceglie un elemento a caso nella lista (da 0 a n-1)
    }
    public GameObject getSpawnedItem()
    {
        return this.spawnedItem;
    }

    IEnumerator DestroyPick()
    {
        yield return new WaitForSeconds(20f);
        if(this.tag =="Pickup")
             Destroy(this.gameObject);
    }
    public void Resize()
    {
        if (SceneManager.GetActiveScene().name != ("Casa_abbandonata"))
            switch (this.name)
            {
                case "GunPickup":
                case "GunPickup(Clone)":
                    this.transform.localScale = new Vector3(10f, 10f, 10f);
                    break;
                case "FirstAidPickup":
                case "FirstAidPickup(Clone)":
                    this.transform.localScale = new Vector3(1f, 1f, 1f);
                    break;
                case "AssaultRiflePickup":
                case "AssaultRiflePickup(Clone)":
                    this.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                    break;
                case "ShotgunPickup":
                case "ShotgunPickup(Clone)":
                    this.transform.localScale = new Vector3(20f, 20f, 20f);
                    break;
            }
    }
}
