using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieAnimator : Enemies {

    void Start()
    {
        animator = GetComponent<Animator>();
        health = startHealth;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Attack();
    }

    public void Walk()
    {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
            animator.SetBool("Walk", true);
        else
            if (!this.animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
            animator.SetBool("Walk", false);
    }

}