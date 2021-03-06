using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieAnimator : Enemies
{
    private int constr;
    void Start()
    {
        animator = GetComponent<Animator>();
        startHealth = 110f;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        damage = 20;
        health = startHealth;
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Attack();
        drop = GetComponentInParent<Pickup>().getSpawnedItem();
        HitConstraints();



    }

    public void Walk()
    {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
            animator.SetBool("Walk", true);
        else
            if (!this.animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
            animator.SetBool("Walk", false);
    }

    //Constraints sul colpo ricevuto
   
}