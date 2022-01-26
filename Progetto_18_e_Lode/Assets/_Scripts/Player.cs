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
    private float fireRatio;
    public float distance;

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
    public static List<String> weaponList;//lista di pickup disponibili

    //Altro
    RaycastHit hit;//serve per far puntare gli oggetti dal mouse
    Enemies enemy;//enemy
    //ZombieAnimator enemy; DA RISISTEMARE

    //damage player scratch
    public GameObject blood;
    public GameObject lowhp;
    public Transform hud;
    private AudioSource pain;//audio 4

    void Start()
    {
        maxHealth = 100;
        MaximizeHealth();
        playerCam = GameObject.FindGameObjectWithTag("Player").GetComponent<Camera>();
        score = GameObject.Find("Score").GetComponent<Score>();//richiamo score
        audios = GetComponents<AudioSource>();//raccoglie Audio

        //assegno le armi
        weapons = new List<EquippedWeapon>();
        weapons.Add(playerCam.GetComponentInChildren<Gun>());//prende modello con nome specificato
        EquipWeapon();
        weaponList = new List<String>();
        weaponList.Add("GunPickup");
        weaponList.Add("FirstAidPickup");
        ContaArmi();//conta le armi in possesso
        
        pain = audios[2];
    }

    void Update()
    {
        FixHealth();//la vita corrente non andrà oltre maxHealth
        Shoot();//gestione sparo
        Reload();//gestione ricarica
        PlayerDeath();// con 0 hp si muore, ricarica il livello corrente (per ora)
        ContaArmi();//conta le armi in possesso
        SwapWeapon();
        EquipWeapon();//equipaggio l'arma
        LowHealth();//se il player ha poca vista crea canvas lowhp
    }

    public AudioSource findItemAudio()
    {
        return audios[0];
    }
    public AudioSource swapWeaponAudio()
    {
        return audios[1];
    }

    public int getcurHealth()
    {
        return this.curHealth;
    }

    public int getMaxHealth()
    {
        return this.maxHealth;
    }
    public void FixHealth()
    {
        if (curHealth > maxHealth)
            MaximizeHealth();
        if (curHealth < 0)
            curHealth = 0;
    }
    public void MaximizeHealth()//imposta la vita corrente a maxHealth
    {
        curHealth = maxHealth;
    }
    public void RecieveDamage(int damage)
    {
        if ((curHealth - damage) <= 0)//vedere se da togliere
            curHealth = 0;
        else
        {
            curHealth -= damage;//DA SISTEMARE I DANNI
            score.DecreaseScore(100);//se si riceve un danno si perdono 100 punti
        }
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
            SceneManager.LoadScene("GameOver"); //carica la scena GameOver
                                            // Application.LoadLevel(Application.loadedLevel);
    }

    public void Shoot()//gestisce lo sparo
    {
        fireRatio += Time.deltaTime;//gestisco fireRatio
        if (Physics.Raycast(playerCam.ScreenPointToRay(Input.mousePosition), out hit, rangeCamera))
        {
            if ((Input.GetMouseButton(0)) && !equippedWeapon.getReload().isPlaying && !hit.collider.tag.Equals("Pickup"))//spara col tasto sinistro
            {
                if (fireRatio > equippedWeapon.fireRatio)//gestisce tempo di sparo
                {
                    DealDamage();//fa danno
                    fireRatio = 0;//reset timer
                }
            }
            if (Input.GetKeyDown("e")) //raccogli oggetto
            {
                if (hit.collider.tag.Equals("Pickup") || hit.collider.tag.Equals("Weapon"))
                    PickUpItem();
            }
        }
       /* else//else per lo sparo al cielo senza collider
        {
            if ((Input.GetMouseButton(0) && !equippedWeapon.getReload().isPlaying))
            {
                if (fireRatio > equippedWeapon.fireRatio)//gestisce tempo di sparo
                {
                    fireRatio = 0;//reset timer
                    if (equippedWeapon.curAmmo > 0)
                    {
                        equippedWeapon.getSparo().Play();
                        equippedWeapon.DecreaseAmmo();
                    }
                    else
                        equippedWeapon.getScarica().Play();
                }
            }
        }*/
    }

    public void DealDamage()//Gestione del danno
    {
        if (equippedWeapon.curAmmo > 0)//decrementa contatore se ha munizioni da togliere
        {
            enemy = hit.transform.GetComponent<Enemies>();
            if (hit.collider.tag == "Enemy" && enemy.health > 0)
            {
                distance = Vector3.Distance(enemy.transform.position, this.transform.position);
                if (distance <= equippedWeapon.rangeWeapon)
                {
                    enemy.TakeDamage(equippedWeapon.damage);
                    score.IncreaseScore(100);
                }
                else
                {
                    enemy.TakeDamage(equippedWeapon.damage / 10);
                    score.IncreaseScore(10);
                }
            }
            if (hit.collider.tag == "Head" && enemy.health > 0) //headshot
            {
                distance = Vector3.Distance(enemy.transform.position, this.transform.position);
                if (distance <= equippedWeapon.rangeWeapon)
                {
                    enemy.TakeDamage(equippedWeapon.damage + (equippedWeapon.damage * 0.5f));
                    score.IncreaseScore(400);
                }
                else
                {
                    enemy.TakeDamage(equippedWeapon.damage / 10);
                    score.IncreaseScore(40);
                }
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
        string getName = hit.collider.name;//restituisce nome arma colpito

        //Debug.Log(hit.collider.GetComponent<EquippedWeapon>().name);

        switch (getName)//switch per riconoscere tipo d'arma
        {
            case "Gun":
            case "Gun(Clone)":
                gameObject.GetComponentInChildren<Gun>().isOwned = true;//settalo
                weapons.Add(gameObject.GetComponentInChildren<Gun>());//aggiungilo
                this.selectedWeapon = nWeapons; //setta counter arma a quella nuova
                weaponList.Add("GunPickup");
                break;
            case "Assault Rifle":
            case "AssaultRifle":
            case "AssaultRifle(Clone)":
            case "Assault Rifle(Clone)":
                gameObject.GetComponentInChildren<AssaultRifle>().isOwned = true;//settalo
                weapons.Add(gameObject.GetComponentInChildren<AssaultRifle>());//aggiungilo
                this.selectedWeapon = nWeapons; //setta counter arma a quella nuova
                weaponList.Add("AssaultRiflePickup");
                break;
            case "Shotgun":
            case "Shotgun(Clone)":
                gameObject.GetComponentInChildren<Shotgun>().isOwned = true;//settalo
                weapons.Add(gameObject.GetComponentInChildren<Shotgun>());//aggiungilo
                this.selectedWeapon = nWeapons; //setta counter arma a quella nuova
                weaponList.Add("ShotgunPickup");
                break;
            case "GunPickup":
            case "GunPickup(Clone)":
                foreach (EquippedWeapon temp in weapons)
                {
                    if (temp.name.Equals("Gun"))
                    {
                        temp.IncreaseCaricatori();
                    }
                }
                break;
            case "AssaultRiflePickup":
            case "AssaultRiflePickup(Clone)":
                foreach (EquippedWeapon temp in weapons)
                {
                    if (temp.name.Equals("Assault Rifle"))
                        temp.IncreaseCaricatori();
                }
                break;
            case "ShotgunPickup":
            case "ShotgunPickup(Clone)":
                foreach (EquippedWeapon temp in weapons)
                {
                    if (temp.name.Equals("Shotgun"))
                        temp.IncreaseCaricatori();
                }
                break;
            case "FirstAidPickup":
            case "FirstAidPickup(Clone)":
                curHealth += 25;
                break;
            default:
                break;
        }
        Destroy(hit.collider.gameObject);
        findItemAudio().Play();
    }

    void Reload()//ricarica l'arma
    {
        if (Input.GetKey("r") && !equippedWeapon.getReload().isPlaying && equippedWeapon.caricatori > 0 && !(equippedWeapon.getCurAmmo() == equippedWeapon.getMaxAmmo()))
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
    
    void LowHealth()
    {
        if (this.getcurHealth() <= 20 && !GameObject.FindGameObjectWithTag("LowHP"))
            Instantiate(lowhp, hud.position, hud.rotation);
    }
}
