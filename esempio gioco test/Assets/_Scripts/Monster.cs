using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : Enemies{

    //the speed you want your player to move with.
    public float speed;
    

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        health = startHealth;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void FixedUpdate()
    {
        WalkForward();
        Attack();
    }

    void WalkForward()
    {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
        {
            animator.SetBool("Walk", true);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else
            if (!this.animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
            animator.SetBool("Walk", false);
    }
}
