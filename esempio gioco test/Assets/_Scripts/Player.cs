using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    //Player
    public int curHealth;//hp attuali
    public int maxHealth = 5;//hp totali (per ora)
    public AudioSource[] audios;

    //Variabili Camera
    public Camera playerCam;//camera del player
    public float rangeCamera = 100f;//range camera (conseguentemente pure dell'arma credo)

    //Score
    Score score;//punteggio della partita

    //Armi 
    public EquippedWeapon equippedWeapon;//oggetto dell'arma attualmente in uso
    public int nWeapons;//armi totali nel gioco
    public int selectedWeapon = 0;//indica arma attualmente in mano (0 = gun, 1 = assaultRifle, 2 = shotgun)
    public List<EquippedWeapon> weapons;//lista di EquippedWeapons

    //Altro
    RaycastHit hit;//serve per far puntare gli oggetti dal mouse
    Enemies enemy;//enemy
    //damage player scratch
    public GameObject blood;
    public Transform hud;
    private AudioSource pain;//audio 4

    void Start()
    {
        MaxHealth();
        playerCam = GameObject.FindGameObjectWithTag("Player").GetComponent<Camera>();
        score = GameObject.Find("Score").GetComponent<Score>();//richiamo score
        audios = GetComponents<AudioSource>();//raccoglie Audio

        //assegno le armi
        weapons.Add(playerCam.GetComponentInChildren<Gun>());//prende modello con nome specificato
        EquipWeapon();
        ContaArmi();//conta le armi in possesso

     
        
        pain = audios[2];
    }

    void Update()
    {
        Shoot();//gestione sparo
        Reload();//gestione ricarica
        PlayerDeath();// con 0 hp si muore, ricarica il livello corrente (per ora)
        ContaArmi();//conta le armi in possesso
        SwapWeapon();
        EquipWeapon();//equipaggio l'arma
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            RecieveDamage();
           
        }
    }

    public AudioSource findItemAudio()
    {
        return audios[0];
    }
    public AudioSource swapWeaponAudio()
    {
        return audios[1];
    }

    public void MaxHealth()
    {
        curHealth = maxHealth;
    }
    public void RecieveDamage()
    {
        curHealth--;
        score.DecreaseScore(100);//se si riceve un danno si perdono 100 punti
        if (!pain.isPlaying)
        {
            pain.Play();
            pain.loop = false;
        }
        if (!GameObject.FindGameObjectWithTag("Damage"))
        {
            Instantiate(blood, hud.position, hud.rotation);
        }

    }
    public void PlayerDeath()//ricarica la partita dal livello corrente alla morte
    {
        if (curHealth <= 0)
            SceneManager.LoadScene("Main"); //ricarica la scena Main (in questo caso)
                                            // Application.LoadLevel(Application.loadedLevel);
    }

    public void Shoot()//gestisce lo sparo
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire1")) && !equippedWeapon.getReload().isPlaying)//spara col tasto sinistro
        {
            if (Physics.Raycast(playerCam.ScreenPointToRay(Input.mousePosition), out hit, rangeCamera))
            {
                if (hit.collider.tag == "Pickup")
                {
                    PickUpItem();
                }
                else
                    DealDamage();//fa danno
            }
        }
    }
    public void DealDamage()//Gestione del danno
    {
        if (equippedWeapon.curAmmo > 0)//decrementa contatore se ha munizioni da togliere
        {
            enemy = hit.transform.GetComponent<Enemies>();
            if (hit.collider.tag == "Enemy" && enemy.health > 0)
            {
                enemy.TakeDamage(equippedWeapon.damage);
                score.IncreaseScore(10);
            }
            if (hit.collider.tag == "Head" && enemy.health > 0) //headshot
            {
                enemy.TakeDamage(enemy.health);
                score.IncreaseScore(400);
            }

            equippedWeapon.getSparo().Play();
            equippedWeapon.DecreaseAmmo();
        }
        else
            equippedWeapon.getScarica().Play();
        //Debug.Log(hit.collider.tag);//mostra il collider name nella
    }
    public void PickUpItem()//raccoglie l'arma
    {
        string getClass = hit.collider.name;//restituisce nome arma colpito
                                            //Debug.Log(hit.collider.GetComponent<EquippedWeapon>().name);

        switch (getClass)//switch per riconoscere tipo d'arma
        {
            case "Gun":
                gameObject.GetComponentInChildren<Gun>().isOwned = true;//settalo
                weapons.Add(gameObject.GetComponentInChildren<Gun>());//aggiungilo
                break;
            case "AssaultRifle":
                gameObject.GetComponentInChildren<AssaultRifle>().isOwned = true;//settalo
                weapons.Add(gameObject.GetComponentInChildren<AssaultRifle>());//aggiungilo
                break;
            case "Shotgun":
                gameObject.GetComponentInChildren<Shotgun>().isOwned = true;//settalo
                weapons.Add(gameObject.GetComponentInChildren<Shotgun>());//aggiungilo
                break;
            default:
                break;
        }

        this.selectedWeapon = nWeapons; //setta counter arma a quella nuova
        Destroy(hit.collider.gameObject);
        findItemAudio().Play();
    }
    void Reload()//ricarica l'arma
    {
        if (Input.GetKey("r") && equippedWeapon.curAmmo == 0 && equippedWeapon.caricatori > 0)
        {
            if (!equippedWeapon.getReload().isPlaying)//se non è già in play
                equippedWeapon.getReload().Play(); //avvia suono ricarica arma
            equippedWeapon.DecreaseCaricatori();
            equippedWeapon.MaxAmmo();
        }
    }
    public void ContaArmi()//conta armi possedute
    {
        nWeapons = 0;
        foreach (EquippedWeapon selector in weapons)//di base si parte con "Gun"
        {
            if (selector.isOwned)
                nWeapons++;
        }
    }
    public void EquipWeapon()//equipaggia un'arma
    {
        foreach (EquippedWeapon selector in weapons)//di base si parte con "Gun"
        {
            if (selector.isOwned && selector.isActiveAndEnabled)//se la possiedo, ed è attiva, la equipaggio
            {
                selector.gameObject.SetActive(true);
                equippedWeapon = selector;
            }
            else
                selector.gameObject.SetActive(false);
        }
    }
    public void SwapWeapon()//aumenta o decrementa il contatore dell'arma corrente
    {
        if (!this.swapWeaponAudio().isPlaying && nWeapons > 1)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                selectedWeapon = (selectedWeapon + 1) % nWeapons;
                swapWeaponAudio().Play();
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                if (selectedWeapon <= 0)
                    selectedWeapon = nWeapons - 1;
                else
                    selectedWeapon--;
                swapWeaponAudio().Play();
            }
            SelectWeapon(selectedWeapon);//seleziona arma in base al contatore
        }

    }
    void SelectWeapon(int select)
    {
        for (int i = 0; i < nWeapons; i++)
        {
            if (weapons[i] == weapons[select] && weapons[i].isOwned)
                weapons[i].gameObject.SetActive(true);
            else
                weapons[i].gameObject.SetActive(false);
        }
    }
}
