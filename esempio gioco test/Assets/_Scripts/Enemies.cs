using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemies : MonoBehaviour
{

    public float startHealth = 100f;
    public float health;

    protected Animator animator;
    protected Player player;
    public Image healthBar;

    protected int flagAttack = 0;

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
            Destroy(gameObject, 2);
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
                player.RecieveDamage();
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
