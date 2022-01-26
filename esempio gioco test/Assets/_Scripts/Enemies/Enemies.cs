using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private float dropChance;

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
        Destroy(gameObject,2);
        dropChance = Random.Range(0, 10);
        if (dropChance >= 0 && dropChance <= 5)
        {
            pickup = Instantiate(drop, gameObject.transform.position, drop.transform.rotation);//crea il pickup
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
    protected void HitConstraints()
    {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Hit") ||
           this.animator.GetCurrentAnimatorStateInfo(0).IsName("HitAttack") ||
           this.animator.GetCurrentAnimatorStateInfo(0).IsName("HitWalk"))
        {
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }
        else
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }
}
