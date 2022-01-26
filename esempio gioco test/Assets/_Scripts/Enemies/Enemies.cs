using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemies : MonoBehaviour
{

    public float startHealth;
    public float health;

    public GameObject drop;
    protected GameObject pickup;
    public float deathTimeAmount;//quanto ci mette per morire

    protected Animator animator;
    protected Player player;
    public Image healthBar;

    protected int flagAttack = 0;
    public int damage;
    Scene m_Scene; 

    void Start()
    {
        this.deathTimeAmount = 2f;
    }   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetTrigger("Attack");
        }
    }

    //Funzione per far perdere vita ai mostri e distruggerli
    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        animator.SetTrigger("Hit");

        if (health <= 0f)
        {
            animator.SetFloat("Life", 0.0f);
            //Destroy(gameObject, 2);
            health = 0;
            Invoke("Drop", deathTimeAmount);//drop dopo due secondi
        }
    }

    public void Drop()
    {
        m_Scene = SceneManager.GetActiveScene();
        Destroy(gameObject,2);
        pickup = Instantiate(drop, gameObject.transform.position, drop.transform.rotation);//crea il 

        if (m_Scene.name.Equals ("Casa_abbandonata") )
        {
            pickup.transform.Translate(0, 1, 0);//lo sposta di y posizioni (non realmente di y) 
        }
        else { 
            pickup.transform.Translate(0, 5, 0);//lo sposta di y posizioni (non realmente di y) 
        }

    }

    //Con questa funzione i nemici fanno danno al player
    public void Attack()
    {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            animator.SetBool("Attacking", true);
            if (flagAttack == 0)
            {
                player.RecieveDamage(this.damage);
                flagAttack++;
            }
        }
        else
            if (!this.animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            animator.SetBool("Attacking", false);
            flagAttack = 0;
        }
    }
}
